1.1) Prerequisites

install-package Autofac
install-package Microsoft.EntityFrameworkCore
install-package Microsoft.EntityFrameworkCore.Relational
install-package Microsoft.EntityFrameworkCore.SqlServer

1.2) References

CM.Services.Exchange.Contract

2) Recreating library

2.1) Run `dotnet new classlib  -o CM.Services.Exchange.Infrastracture -f netcoreapp2.1`
2.2) Move: 
	- directories:
		- *
	- files:
		- readme.recreating.txt

3) Initialization

Ensure that connection string is added to appSettings.json of CM.Services.Exchange.API project. Also ensure that DbContext is included in Startup.cs.
Set CM.Services.Exchange.API as startup project and CM.Services.Exchange.Infrastracture as default project and run command

add-migration "Initial"