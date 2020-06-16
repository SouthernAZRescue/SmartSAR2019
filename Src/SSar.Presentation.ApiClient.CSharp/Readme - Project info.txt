SSar.Presentation.ApiClient.CSharp Readme
---------------------

This project is a self-contained API client for the SmartSAR API. It can 
be published separately via NuGet for use by other related projects.

The Client and Contracts classes are built automatically by NSwag.MsBuild
on each build unless AutoGenerate is set to false in the client .csproj
file or on the dotnet build command line.

To disable client auto-generation on each build in the CI/CD pipeline it 
is recommended to either set an environment condition in the project file 
or modify the dotnet build command in the pipeline.