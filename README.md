# Workspace Solution...

[![GitHub issues open](https://img.shields.io/github/issues/network-tools/shconfparser.svg?maxAge=2592000)](http://git.workspace.vsag.ch/Dev_Team/Workspace/issues)



> Current Version 1.3.0

> Project track in [GitV](http://git.workspace.vsag.ch/Dev_Team/Workspace/projects) *[Self-Hosted]*

> Project repository in [GitV](http://git.workspace.vsag.ch/Dev_Team/Workspace) *[Self-Hosted]*

> Project Documentation in [Notion](https://hiruna.notion.site/VS-Workspace-ab113a9758d14836b37e2d16f4b7dbed) *[Temp]*

### Technologies

:white_check_mark:
.Net 6
:white_check_mark:
C#
:white_check_mark:
ASP.NET Core 6
:white_check_mark:
Entity Framework 6
:white_check_mark:
Blazor
:white_check_mark:
MS SQL Server 2016
:white_check_mark:
Visual Studio 2022


### Main Implimentations
- [x] Blazor Wasm-Hosted #30
- [x] Repository Patterns #31
- [x] AD Login
- [ ] Policy Base Athorization
- [ ] Localization
- [ ] Globalization
- [x] Git Repository
- [ ] Background Services
- [ ] Workspace admin portal

### Project URLs
- [x] Workspace Solution : http://workspace.vsag.ch
- [x] Authenticating Service : https://auth.workspace.vsag.ch
- [ ] Workspace Admin : https://admin.workspace.vsag.ch/

-----

## Repo Branches

**Master** - Main Solution

**Release** - Creating temporary when going to realse a develop branch features

**Develop** - Working Sprint ( All developers commites are mearch to here)

**Dev_DeveloperName_Fearture_Name** - Developer should create new branch from base Develop branch for Implement new feature


## Implementing a new feature in Workspace

<details><summary>CLICK ME</summary>
<p>

#### We can hide anything, even code!

```ruby
   puts "Hello World"
```

</p>
</details>

1. **Workspace.Shared Project**
    - Add Entities

2. **In Server Project**
    - Services Folder
        - Interface class
        - Implimentation Class	
	- Program.cs
		- Add Services with Interfaces
	- Controller Folder
		- API Endponts

2. **In Client Project**
	- Services Folder
		- Interface class
		- Implimentation Class
	- Program.cs
		- Add Services with Interfaces
	- Pages Folder
		- Features

