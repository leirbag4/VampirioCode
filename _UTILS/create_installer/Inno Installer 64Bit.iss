; -- 64Bit.iss --
; Demonstrates installation of a program built for the x64 (a.k.a. AMD64)
; architecture.
; To successfully run this installation and the program it installs,
; you must have a "x64" edition of Windows or Windows 11 on Arm.

; SEE THE DOCUMENTATION FOR DETAILS ON CREATING .ISS SCRIPT FILES!

[Setup]
AppName=Vampirio Code
AppVersion=0.6.7
AppPublisher=Vampirio Studio
AppPublisherURL=https://vampiriostudio.com
AppSupportURL=https://vampiriostudio.com/contact
AppUpdatesURL=https://github.com/leirbag4/VampirioCode
WizardStyle=modern
DefaultDirName={autopf}\VampirioCode
DefaultGroupName=VampirioCode
UninstallDisplayIcon={app}\VampirioCode.exe
Compression=lzma2
SolidCompression=yes
OutputDir=.
OutputBaseFilename=vampirio_code_setup
SetupIconFile=res\icon_64_multiple.ico
; "ArchitecturesAllowed=x64compatible" specifies that Setup cannot run
; on anything but x64 and Windows 11 on Arm.
ArchitecturesAllowed=x64compatible
; "ArchitecturesInstallIn64BitMode=x64compatible" requests that the
; install be done in "64-bit mode" on x64 or Windows 11 on Arm,
; meaning it should use the native 64-bit Program Files directory and
; the 64-bit view of the registry.
ArchitecturesInstallIn64BitMode=x64compatible

[Files]
; Copy all files and dirs except .iss
Source: "release\*"; DestDir: "{app}"; Flags: recursesubdirs createallsubdirs; Excludes: "config.cfg;*.iss"
;Source: "VampirioCode.exe"; DestDir: "{app}"; DestName: "VampirioCode.exe"
;Source: "MyProg.chm"; DestDir: "{app}"
;Source: "Readme.txt"; DestDir: "{app}"; Flags: isreadme

[Tasks]
Name: "desktopicon"; Description: "Create an icon on the Desktop"; GroupDescription: "Additional Icons"; Flags: unchecked


[Icons]
Name: "{group}\Vampirio Code"; Filename: "{app}\VampirioCode.exe"
; Add optional shortcut to the desktop
Name: "{commondesktop}\Vampirio Code"; Filename: "{app}\VampirioCode.exe"; Tasks: desktopicon

; Remove 'AppData\Roaming\VampirioCode'
[UninstallDelete]
Type: filesandordirs; Name: "{userappdata}\VampirioCode"