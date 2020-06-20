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

If you clean/rebuild the project you may need to run dotnet restore and/or
run build twice to regenerate DLLs upon which auto-generation is dependent.

NOTE: During normal development and in most commits AutoGenerate has been
left at False to speed project builds. If you make changes that affect the
API make sure to re-enable client auto-generation when building the project.