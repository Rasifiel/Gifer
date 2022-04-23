using Gifer;
using Newtonsoft.Json.Linq;
using System;
using System.Net.Http;
using System.Text.RegularExpressions;

namespace Gifer {
  public class PlayerState {

    public String filePath;
    public int position;
    public String state;

    public PlayerState(string filePath, int position, string state) {
      this.filePath = filePath;
      this.position = position;
      this.state = state;
    }
  }
  public interface VideoPlayerAPI {
    PlayerState GetPlayerState();
  }

  public class VideoPlayerAPIFactory {
    public static VideoPlayerAPI CreateVideoPlayerAPI() {
      switch (Configuration.CurrentPlayer) {
        case VideoPlayer.MPC: return new MPCAPI();
        case VideoPlayer.VLC: return new VLCAPI();
      }
      throw new ArgumentException();
    }
  }

  class MPCAPI : VideoPlayerAPI {
    public PlayerState GetPlayerState() {
      HttpClient httpClient = new HttpClient();
      try {
        var response = httpClient.GetAsync("http://127.0.0.1:13579/status.html").Result;
        if (response.IsSuccessStatusCode) {
          var content = response.Content.ReadAsStringAsync().Result.Replace("\"", "'");
          Regex matcher = new Regex("OnStatus\\('.*', '(.*)', (\\d+), '.*', \\d+, '.*', \\d+, \\d+, '(.*)'\\)");
          var match = matcher.Match(content);
          var position = match.Groups[2].Value;
          var state = match.Groups[1].Value;
          var filePath = match.Groups[3].Value;
          return new PlayerState(filePath, int.Parse(position), state);
        }
        return new PlayerState("", -1, "");
      } catch (Exception) {
        return new PlayerState("", -1, "");
      }
    }
  }

  class VLCAPI : VideoPlayerAPI {

    private String QueryVLC(String url) {
      HttpClient httpClient = new HttpClient();
      HttpRequestMessage httpRequest = new HttpRequestMessage(HttpMethod.Get, url);
      httpRequest.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", System.Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(":" + Configuration.VLCPassword)));
      var response = httpClient.SendAsync(httpRequest).Result;
      if (response.IsSuccessStatusCode) {
        return response.Content.ReadAsStringAsync().Result;
      }
      throw new InvalidOperationException();
    }
    public PlayerState GetPlayerState() {
      try {
        var statusStr = QueryVLC("http://127.0.0.1:8080/requests/status.json");
        JObject statusObj = JObject.Parse(statusStr);
        double position = (double)statusObj["position"];
        int currentplid = (int)statusObj["currentplid"];
        int length = (int)statusObj["length"];
        String status = (String)statusObj["status"];
        var playlistStr = QueryVLC("http://127.0.0.1:8080/requests/playlist.json");
        var playlistObj = JObject.Parse(playlistStr);
        String fileUri = "";
        foreach (var child in playlistObj["children"]) {
          foreach (var element in child["children"]) {
            if ((String)element["current"] == "current") {
              fileUri = (String)element["uri"];
            }
          }
        }
        Uri uri = new Uri(fileUri);
        String filePath = uri.LocalPath;
        return new PlayerState(filePath, (int)(length * 1000.0 * position), status);
      } catch (Exception) {
        return new PlayerState("", -1, "");
      }
    }
  }
}
