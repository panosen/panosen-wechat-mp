@echo off

dotnet restore

dotnet build --no-restore -c Release

move /Y Panosen.Wechat.Mp\bin\Release\Panosen.Wechat.Mp.*.nupkg D:\LocalSavoryNuget\

pause