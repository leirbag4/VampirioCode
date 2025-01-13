@echo off

SET origin="..\VampirioCode\bin\Debug\net8.0-windows\VampirioCode.exe"
SET origin2="..\VampirioCode\bin\Debug\net8.0-windows\VampirioCode.dll"
SET dest="\\DESKTOP-SFHM6G6\programs\vampirio_12\VampirioCode.exe"
SET dest2="\\DESKTOP-SFHM6G6\programs\vampirio_12\VampirioCode.dll"

xcopy /y %origin% %dest%
xcopy /y %origin2% %dest2%

pause
