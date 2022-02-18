# SpecFlow with Selenium Google and Youtube search feature test

This repository contains SpecFlow's BDD with Selenium with the aim to test the search feature in Google and Youtube platforms.

# Technologies

- [Dotnet](https://docs.microsoft.com/en-us/dotnet/)
- [C#](https://docs.microsoft.com/en-us/dotnet/csharp/)
- [SpecFlow](https://docs.specflow.org/en/latest/)
- [LivingDoc](https://docs.specflow.org/projects/specflow-livingdoc/en/latest/?_ga=2.198613416.687440730.1645182274-1718536208.1645017009&_gl=1*1ojsfhr*_ga*MTcxODUzNjIwOC4xNjQ1MDE3MDA5*_ga_BZ55XKTXC6*MTY0NTE5NDg0MS4xMi4xLjE2NDUxOTUxMzEuMA..)
- [Gherkin](https://cucumber.io/docs/gherkin/)
- [Selenium](https://www.selenium.dev/documentation/)

# Setup

## Clone repository

Create and go to the directory where you want to place the repository

```bash
  cd my-directory
```

Clone the project

```bash
  git clone https://github.com/pncsoares/specflow-selenium-search.git
```

Go to the project directory

```bash
  cd specflow-selenium-search
```

# Build

## Using IDE

Click in the `Build` button

## Using CLI

Open terminal and execute the following commands:

```bash
# run in SpecFlowCalculator directory
dotnet build
```

# Test

## Using IDE

Click in `Run all tests` button

## Using CLI

Open terminal and execute the following commands:

```bash
# run in SpecflowSelenium directory
dotnet test
```

## Generate test results

> You need to have livingdoc installed in your computer

Open terminal and execute the following commands:

```bash
# run in SpecflowSelenium directory
livingdoc test-assembly SpecflowSelenium/bin/Debug/net6.0/SpecflowSelenium.dll -t SpecflowSelenium/bin/debug/net6.0/TestExecution.json
```

## See test results

Open the `LivingDoc.html` that livingdoc created in the root of `SpecflowSelenium` directory.

# License

MIT