@echo off

SET signtool="C:\Program Files (x86)\Windows Kits\10\bin\10.0.22621.0\x64\signtool.exe"
SET file="..\VampirioCode\bin\Release\net8.0-windows\VampirioCode.exe"


%signtool% sign /a /fd SHA256 %file%
%signtool% timestamp /tr http://timestamp.digicert.com /td SHA256 %file%
%signtool% verify /pa %file%

pause