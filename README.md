# ASP.NET Core 7.0 project from ELSA
## Technologies
- ASP.NET Core 7.0
- Entity Framework Core 7.0
## Install Tools
- .NET Core SDK 7.0
- Git client
- Visual Studio 2022
- Jetbrain Rider 2022
- SQL Server 2018
## How to configure and run
- Clone code from Github: git clone https://github.com/teduinternational/eShopSolution
- Open solution eShopSolution.sln in Visual Studio 2022
- Set startup project is eShopSolution.Data
- Change connection string in Appsetting.json in eShopSolution.Data project
- Open Tools --> Nuget Package Manager -->  Package Manager Console in Visual Studio
- Run Update-database and Enter.
- After migrate database successful, set Startup Project is eShopSolution.WebApp
- Change database connection in appsettings.Development.json in eShopSolution.WebApp project.
- You need to change 3 projects to self-host profile.
- Set multiple run project: Right click to Solution and choose Properties and set Multiple Project, choose Start for 3 Projects: BackendApi, WebApp and AdminApp.
- Choose profile to run or press F5
## How to contribute
- Fork and create your branch
- Create Pull request to us.

## Admin template: https://startbootstrap.com/templates/sb-admin/
## Portal template: https://www.free-css.com/free-css-templates/page194/bootstrap-shop

## I18N (Internalization)
- References: https://medium.com/swlh/step-by-step-tutorial-to-build-multi-cultural-asp-net-core-web-app-3fac9a960c43
- Source code: https://github.com/LazZiya/ExpressLocalizationSampleCore3
