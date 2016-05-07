cd /d %~dp0

for /f "delims=;" %%i in ('dir /b /od /s screenshot\*.png') do (
 cd ..\..\python\
 python detect.py %%i %~dp0
 cd /d %~dp0
)
