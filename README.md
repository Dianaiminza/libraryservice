# Library API Service
A company is launching a library management service. The service will be a web API layer built using .NET, with an existing prepared infrastructure.

## Environment
- .NET version: 6.0

## Read-Only Files
- LibraryService.Tests/IntegrationTests.cs

## Commands
- run:  
```
dotnet clean && dotnet restore && dotnet run --project LibraryService.WebAPI
```
- install:  
```
dotnet clean && dotnet build
```
- test: 
```
dotnet restore && dotnet build && dotnet test --logger xunit --results-directory ./reports/
```
