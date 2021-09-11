# Order Processor
Order processing app that handles multiple rules.

<br>

## Prerequisites
.NET 5 SDK 
```
https://download.visualstudio.microsoft.com/download/pr/c1bfbb13-ad09-459c-99aa-8971582af86e/61553270dd9348d7ba29bacfbb4da7bd/dotnet-sdk-5.0.400-win-x64.exe
```
<br>

## Build
Build project and its dependencies using Release configuration:
```PowerShell
dotnet build --configuration Release
```
eg. PS C:\OrderProcessor\src\OrderProcessor.Consumer> dotnet build --configuration Release

<br>

## Run App
Using Windows PowerShell navigate to the project output path and run following commands 
```PowerShell
.\OrderProcessor.Consumer.exe
```
<br>

## Running Test Cases
Run the tests in the project in the current directory:
```PowerShell
dotnet test
```
eg. PS C:\OrderProcessor\tests\OrderProcessor.UnitTests> dotnet test
