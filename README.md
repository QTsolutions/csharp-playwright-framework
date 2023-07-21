
```
This is the basic project of C#,Sekenium and NUnit. I have tried to build a framework based on Page Object Model
```
## Technology Used
```
  1. C#
  2. Selenium
  3. Nunit
  4. Playwright
  5. Visual Studio
```

## Installation 
```
1. dotnet add package Microsoft.Playwright.NUnit
2. dotnet build
3. bin/Debug/netX/playwright.ps1 install
```

## Detailed explanation on Automation Framework
## How To Run
```
Using Visual Studio
1.Go to Build option at top navigation bar and Build Framwork
2. After Successful build, Go to Test optin at top naivigation bar
3. Select Test Explorer
4. To Run all tests, select the first icon on left on Test Explorer window
5. To Run single feature file, Select the feature file first and the select the second icon on Test Explorer window

Using Termianl
```
 A.dotnet test
 ```
 ```
 B 1.Go to sourceFolder>bin>Debug>net6.0
   2. Run command - vstest.console.exe POM_Basic.dll 
```

```
using Different Commands
1. Running a Single Test File
`dotnet test --filter "MyClassName" `

2. Running the Test with Title
`dotnet test --filter "Name~TestMethod1"`

3. Running Test on specific Browser
`dotnet test -- Playwright.BrowserName=webkit`
```

### Framework type: Page Object Model flavored with Specflow
```
Contains  UI tests
```

### Project Structure
```
Drivers:-
This package contains the chrome driver and seleniumWebDriver class. Currently, these scripts are running on chrome of windows. If you want to execute on chrome of Mac then you need to add the chrome driver for mac in this folder
```
```
Pages:-
Contains locators of objects involved in pages of website
```
```
Tests:-
This package contains all tests.
```
Utilities:-
This package contains Json Reader.
```