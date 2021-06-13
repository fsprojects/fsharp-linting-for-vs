# Linting For F# 

This is a full-featured Visual Studio integration for the [**FSharpLint**](https://github.com/fsprojects/FSharpLint) project.

## Features

- Live error tagging
- Shows warnings in Quick Info tooltip
- Filterable warnings in errors panel
- Links to issues
- Code fixes 
- Warning suppression in smart actions
- Fast, in-process linting
- Fully asynchronous

## Configuration

We look for a `fsharplint.json` in this order:

- In the same folder as the current document
- In the project (`.fsproj`) directory
- In the solution (`.sln`) directory
- In the directory above the solution directory, if it exists

## In action

![fslint](https://user-images.githubusercontent.com/2375486/90334848-1f62ca80-dfee-11ea-932d-af0d330e4e8c.gif)

## Options

Linter options can be found in `F# Tools > Linting`

![FsLintOptions](https://user-images.githubusercontent.com/2375486/96405667-6beba180-11fb-11eb-821d-aff9e858a7d8.jpg)

## See an issue?

If you see an issue with the Visual Studio integration or with configuration, please [file it here](https://github.com/deviousasti/fsharp-linting-for-vs/issues).

## License

This project is licensed under the MIT license, a copy of which can be found [here](src/Resources/License.txt).
