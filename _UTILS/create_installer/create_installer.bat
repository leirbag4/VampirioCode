::set /p VERSION_NUMBER=Version Number: 

@echo off
setlocal

:: ============================
:: Configuration
:: ============================

:: App version: use it if automatic parsing from below doesn't work
::set VERSION_NUMBER=0.6.7

:: ============================
:: Get version number from .csproj
:: ============================

for /f "tokens=3 delims=<>" %%a in ('findstr /I "<Version>" "..\..\VampirioCode\VampirioCode.csproj"') do (
    set "VERSION_NUMBER=%%a"
)

echo Detected version: %VERSION_NUMBER%
echo.

:: Paths
set ORIGINAL_RELEASE_DIR=..\..\VampirioCode\bin\Release\net8.0-windows
set NEW_RELEASE_DIR=.\release
set ISS_FILE="Inno Installer 64Bit.iss"
set INNO_PATH="C:\Program Files (x86)\Inno Setup 6\ISCC.exe"

:: ============================
:: Copy clean build
:: ============================

echo.
echo === Copying files from %ORIGINAL_RELEASE_DIR% to %NEW_RELEASE_DIR%...
if exist %NEW_RELEASE_DIR% rmdir /s /q %NEW_RELEASE_DIR%
xcopy /y /e /i %ORIGINAL_RELEASE_DIR% %NEW_RELEASE_DIR%

:: Remove unwanted files
del %NEW_RELEASE_DIR%\config.cfg >nul 2>&1
del %NEW_RELEASE_DIR%\VampirioCode.pdb >nul 2>&1

:: ============================
:: Build installer with Inno Setup
:: ============================

echo.
echo === Compiling installer with Inno Setup...
%INNO_PATH% %ISS_FILE% /DAppVersion=%VERSION_NUMBER%

:: ============================
:: Rename setup.exe
:: ============================
ren vampirio_code_setup.exe vampirio-code-%VERSION_NUMBER%-setup.exe

:: ============================
:: Remove 'release' dir
:: ============================
rmdir /s /q %NEW_RELEASE_DIR%


:: ============================
:: Done
:: ============================

echo.
echo === Build finished. Press any key to exit...
pause >nul
endlocal
