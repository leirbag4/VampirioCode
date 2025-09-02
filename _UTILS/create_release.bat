:: App version: use it if automatic parsing from below doesn't work
::set /p VERSION_NUMBER=Version Number: 

:: ============================
:: Get version number from .csproj
:: ============================

for /f "tokens=3 delims=<>" %%a in ('findstr /I "<Version>" "..\VampirioCode\VampirioCode.csproj"') do (
    set "VERSION_NUMBER=%%a"
)

echo Detected version: %VERSION_NUMBER%
echo.

:: ============================
:: COPY files and struct
:: ============================
SET ORIGINAL_RELEASE_DIR="..\VampirioCode\bin\Release\net8.0-windows"
SET NEW_RELEASE_DIR=".\VampirioCode"
SET ZIP_NAME="vampirio-code-ver-%VERSION_NUMBER%.zip"

xcopy /y /e /i %ORIGINAL_RELEASE_DIR% %NEW_RELEASE_DIR%
del %NEW_RELEASE_DIR%\config.cfg
del %NEW_RELEASE_DIR%\VampirioCode.pdb
rmdir /s /q "%NEW_RELEASE_DIR%\temp_build"
rmdir /s /q "%NEW_RELEASE_DIR%\temp_files"
:: ============================
:: CREATE Portable or Installable version
:: ============================
::powershell -NoProfile -ExecutionPolicy Bypass -File "_set_to_installable.ps1"
:: CREATE Portable or Installable version
if "%~1"=="" (
    echo No .ps1 script provided! Please call this batch with a parameter.
	pause
    exit /b 1
)

powershell -NoProfile -ExecutionPolicy Bypass -File "%~1"

:: ============================
:: COMPRESS to ZIP file
:: ============================
powershell -NoProfile -ExecutionPolicy Bypass -File "_create_release_.ps1"
rmdir /s /q %NEW_RELEASE_DIR%

ren "VampirioCode.zip" %ZIP_NAME%


pause