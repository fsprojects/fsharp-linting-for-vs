del .\src\bin\* -Recurse
markdown '.\Release Notes.md' > src\Resources\ReleaseNotes.html
msbuild .\src\FSharpLintVs.sln -p:Configuration=Release
copy .\src\bin\Release\FSharpLintVs.vsix .\