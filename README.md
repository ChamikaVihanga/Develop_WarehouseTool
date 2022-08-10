# Workspace Solution...

> Current Version 1.3.0

> Project track in [Jira](https://workspaceapp.atlassian.net/jira/software/projects/WS/boards/2) *[Cloud]*

> Project repository in [GitV](http://git.workspace.vsag.ch/Dev_Team/Workspace) *[Local Hosted]*

> Project Documentation in [Notion](https://hiruna.notion.site/VS-Workspace-ab113a9758d14836b37e2d16f4b7dbed) *[Temp]*

### Technologies

* Net Core 6
* ASP.NET Core 6
* Entity Framework 6
* Blazor
* MS SQL Server 2016
* Visual Studio 2022

### Main Implimentations
- [x] Blazor Wasm-Hosted
- [x] Repository Patterns
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
- [ ] Background Services : https://Services.workspace.vsag.ch/

-----

## Repo Branches

**Master** - Main Solution

**Release** - Creating temporary when going to realse develop branch features

**Develop** - ??

**Current_Sprint** - Working Sprint ( All developers commites are mearch to this)

**Sample_Fearture_Name** - Developer should create new branch from base Current_Sprint for Implement new feature


## Implementing a new feature in Workspace

1. **Workspace.Shared Project**
    - Add Entities

2. **In Server Project**
    - Services Folder
        - Interface class
        - Implimentation Class	
	- Program.cs
		- Add Services
	- Controller Folder
		- API Endponts

2. **In Client Project**
	- Services Folder
		- Interface class
		- Implimentation Class
	- Program.cs
		- Add Services
	- Pages Folder
		- Features