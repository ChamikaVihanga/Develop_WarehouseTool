# Workspace Solution...

## Must Follow these steps - VERY IMPORTANT
1. Clone Git Repo to New Location ( Rename the Old project location )
2. Switch to your Branch
3. Update Your connection string
4. Only push to your branch

<!-- 
[![GitHub issues open](https://img.shields.io/github/issues/network-tools/shconfparser.svg?maxAge=2592000)](http://git.workspace.vsag.ch/Dev_Team/Workspace/issues)
-->



> Current Version 1.5.0

> Project track in [GitV](http://git.workspace.vsag.ch/Dev_Team/Workspace/projects) *[Self-Hosted]*

> Project repository in [GitV](http://git.workspace.vsag.ch/Dev_Team/Workspace) *[Self-Hosted]*

> Project Documentation in [Notion](https://hiruna.notion.site/VS-Workspace-ab113a9758d14836b37e2d16f4b7dbed) *[Temp]*

-----

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
**Dev_DeveloperName** - Developer has separate branch and only admin should branches to Develop and master branches


## Implementing a new feature in Workspace

<details><summary>Test</summary>
<p>
Test

```CSharp
	Console.WriteLine("Hello World!");
```

</p>
</details>

1. **Workspace.Shared Project**
	- All namespaces should : Workspace.Shared.Entities
    - Add Entities


2. **In Server Project**
    - Services Folder
		- All namespaces should : Workspace.server.services
        - Interface class
        - Implimentation Class	
	- Program.cs
		- Add Services with Interfaces
	- Controller Folder
		- All namespaces should : Workspace.Server.Controllers
		- API Endponts

2. **In Client Project**
	- Services Folder
		- All namespaces should : Workspace.client.services
		- Interface class
		- Implimentation Class
	- Program.cs
		- Add Services with Interfaces
	- Pages Folder
		- Features

