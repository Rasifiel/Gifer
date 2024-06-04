# Changelog

## 1.14 2024-06-04

### Added
- Button "Download FFmpeg". It will download shared binary version of FFmpeg to app folder.

## 1.13 2022-08-22

### Fixed
- Crash of app initialization.

## 1.12 2022-08-22

### Changed
- Subtitles font size replaces with subtitles scaling.

## 1.11 2022-06-07

### Fixed
- Crop dialog works correctly.

## 1.10 2022-04-24

### Fixed
- DVD subtitles should work correctly on any locale.
- Notification window will not grab input focus (for real this time).

## 1.9 2022-04-24

### Added
- Selection of input streams.
- Support for DVD subtitles.

### Fixed
- Notification window will not grab input focus.
- Notification window will not be shown in alt+tab selector.

## 1.8 2022-04-23

### Changed
- Changed notification from Windows native to custom form based.

### Fixed
- Fixed possible delay for all operations for IPv4-only config.

## 1.7 2022-04-23

### Added
- Logging. Gifer will produce 'Gifer.log' file with debug information.

### Fixed
- Fixed building gifs with subtitles when filepath contains '(quote character).

## 1.6 2022-04-11

### Added
- Render "gif" with custom properties. Can toggle full resolution, keeping audio track and keeping subtitles in options.  
  Use Ctrl+Alt+Shift+B to start rendering.

### Changed
- Upgraded from .NET Framework to .NET Core 6.
- Changed notifications to native Windows toast notifications.
- Dropped support of Windows 7.

## 1.5 2022-01-13

### Fixed
- Fixed support for video with odd height and width less than 800 pixels.

## 1.4 2021-07-14

### Added
- Hotkey configuration.

## 1.3 2021-04-26

### Changed
- Notification from tray tooltips to toster notifications. It should improve app resonse times.

## 1.2 2021-04-25

### Added
- Render "gif" with subtitles.  
  Use Ctrl+Alt+Shift+V to start rendering.

## 1.1 2021-04-18

Initial release

