set /p VERSION_NUMBER=Version Number: 

SET ORIGINAL_RELEASE_DIR="..\VampirioCode\bin\Release\net8.0-windows"
SET NEW_RELEASE_DIR=".\VampirioCode"
SET ZIP_NAME="vampirio-code-ver-%VERSION_NUMBER%.zip"

xcopy /y /e /i %ORIGINAL_RELEASE_DIR% %NEW_RELEASE_DIR%

powershell -NoProfile -ExecutionPolicy Bypass -File "_create_release_.ps1"
rmdir /s /q %NEW_RELEASE_DIR%

ren "VampirioCode.zip" %ZIP_NAME%


pause