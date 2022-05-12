# BasicMvc

A basic .NET Core out-of-the-box MVC application use for simple deployments in Kubernetes.

## dotnet CLI

dotnet CLI used to create this project:

```ps1: In C:\src\github.com\ongzhixian\BasicMvc
dotnet new sln -n BasicMvc
dotnet new mvc -n BasicMvc.WebApp
dotnet sln .\BasicMvc.sln add .\BasicMvc.WebApp\
```

## Focal branch

This is the same as the main branch with the following differences:
1.  its uses Ubuntu Focal Fossa build.
2.  uses nlog

```ps1: In C:\src\github.com\ongzhixian\BasicMvc
dotnet add .\BasicMvc.WebApp\ package NLog.Web.AspNetCore
dotnet add .\BasicMvc.WebApp\ package NLog
```
