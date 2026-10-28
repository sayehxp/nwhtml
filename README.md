# nw — quick HTML project scaffolder for Windows

`nw` is a tiny command-line tool that creates a ready-to-code HTML5 starter folder in one command, and adds a few helpers for opening VS Code, dropping in Bootstrap, and grabbing the Font Awesome CDN link.

## Install

1. Download and run [`installation.exe`](installation.exe).
2. Open a new terminal (CMD / PowerShell) and type `nw` to confirm it's available.

> Requires Windows with .NET Framework 4.0 or later.

## Usage

### Create a new HTML project

```bash
nw html              # creates a folder named "New html"
nw html my-page      # creates a folder named "my-page"
nw my-page           # shorthand, same as above
```

Each new folder contains:

```
my-page/
├── index.html   # HTML5 boilerplate linked to style.css and script.js
├── style.css
└── script.js
```

- The folder is created in the current directory.
- If you run it from your user home folder (the default terminal location), the folder goes to your **Desktop** instead.
- If a folder with the same name exists, a numbered one is created: `my-page (2)`, `my-page (3)`, …
- Invalid filename characters (`\ / : * ? " > |`) are stripped from the name.

### Helpers

| Command            | What it does                                                           |
| ------------------ | ---------------------------------------------------------------------- |
| `nw vs`            | Opens the current folder in VS Code (user install).                    |
| `nw bs`            | Copies Bootstrap files into a `bootstrap/` folder in the current dir.  |
| `nw font-awesome`  | Prints the Font Awesome 6.4.0 CDN `<link>` tag to paste into `<head>`. |

### Typical workflow

```bash
cd Projects
nw html portfolio
cd portfolio
nw bs
nw vs
```

## Build from source

Open `nwhtml.sln` in Visual Studio and build. The output executable is `nw.exe` (C#, .NET Framework 4.0, x86).

For `nw bs` to work, the Bootstrap files must sit next to the executable at:

```
nw\bootstrap\bootstrap.min.css
```

## Project structure

```
nwhtml.sln            # Visual Studio solution
installation.exe      # Windows installer
nwhtml/
├── Program.cs        # all CLI logic
└── nwhtml.csproj
```
