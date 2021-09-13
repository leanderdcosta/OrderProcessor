# Order Processor

Problem Statement : Business Rules Engine
<br>
Imagine You’re writing an order processing application for a large company. In the past, this company used a fairly random mixture of manual and ad-hoc automated business practices to handle orders; they now want to put all these various ways of handling orders together into one whole: your application. After a full day of workshops you have gathered the following set of rules which need to be managed by the new system.
*	If the payment is for a physical product, generate a packing slip for shipping.
*	If the payment is for a book, create a duplicate packing slip for the royalty department.
*	If the payment is for a membership, activate that membership.
*	If the payment is an upgrade to a membership, apply the upgrade.
*	If the payment is for a membership or upgrade, e-mail the owner and inform them of the activation/upgrade.
*	If the payment is for the video “Learning to Ski,” add a free “First Aid” video to the packing slip (the result of a court decision in 1997).
*	If the payment is for a physical product or a book, generate a commission payment to the agent.

Implement a system which can handle these rules and is designed in a way that is open to extension with more new rules.

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
