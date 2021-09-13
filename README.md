# RegexReplacer
A simple C# program that you can use to replace text in a specified regex/blob pattern of files.

## Download
Visit [Releases](https://github.com/UserR00T/RegexReplacer/releases/latest) for an binary. Linux users can download the binary directly, and windows users have to extract the zip file to run it. This will be changed in the future when I have access to an .NET 5 windows VM to compile with again. Tracking in #1.

## Building
Execute `dotnet build` on either the `sln` or `RegexReplacer.csproj`. 

## Why
I needed this for a massive replace on a large scale project based on a specific regex and blob. I thought others may find this useful as well and decided to release it. For that reason don't expect the best documentation nor support on this project.

## Running
By default, you can just run the `.exe` on windows and the binary directly on linux. If no arguments are provided it will use `regexreplacer.json` in the same folder as configuration file.
If an argument was provided however, it'll use that path/file for settings.

## Configuration
By default, running the program once without an `regexreplacer.json` file in the working directory will create an example file. Using that file, you can configure how RegexReplacer will work.

`regexreplacer.json`:
```json
{
  "patterns": [
    {
      "path": "/tmp/your_directory",
      "searchBlob": "*.*",
      "matcher": "aa\/",
      "replace": [
        {
          "from": "hello",
          "to": "goodbye",
        }
      ],
      "searchOptions": 1
    }
  ]
}
```
This pattern will change all files (recursively) inside the folder `/tmp/your_directory` where the path matches the regex `aa/`. Once it lists these files, it will try to replace the word `hello` with `goodbye`.

_Note_ `patterns` is an array and multiple patterns are allowed.

`/tmp/your_directory/aa/afile.txt`
```txt
hello world, this is my great test file!
```
Will get changed to:
```txt
goodbye world, this is my great test file!
```

While `/tmp/your_directory/adifferentfile.txt` will not get changed.
