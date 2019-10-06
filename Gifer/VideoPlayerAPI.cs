using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Gifer {
  class PlayerState {

    public String filePath;
    public int position;
    public String state;

    public PlayerState(string filePath, int position, string state) {
      this.filePath = filePath;
      this.position = position;
      this.state = state;
    }
  }
  interface VideoPlayerAPI {
    PlayerState GetPlayerState();
  }
  class MPCAPI : VideoPlayerAPI {
    public PlayerState GetPlayerState() {
      HttpClient httpClient = new HttpClient();
      try {
        var response = httpClient.GetAsync("http://localhost:13579/status.html").Result;
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
}
