@echo off
setlocal

rem Pulls latest from all GIT repositories
rem 
rem Usage
rem =====
rem put this script into the folder where all your git repositories are located (so outside the folder where
rem the .git folder is located) and just run it. 
rem The script will assume all subfolders containing a ".git" folder are git repositories and try to run "git pull"
rem

for /f "delims=" %%i in ('dir /ad /b') do (
  if exist %%i\.git (
    echo --- %%i ---
    cd %%i
    git pull
    cd ..
  )
)

pause

endlocal