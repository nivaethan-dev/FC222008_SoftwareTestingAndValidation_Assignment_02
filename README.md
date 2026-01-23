# CSE2522: Software Testing and Validation - Assignment 02

## Student Information
- **Name:** R. Nivaethan
- **Index Number:** FC222008
- **Registration Number:** FC115565
- **Course ID:** CSE2522

---

## Project Overview
This repository contains the automated test suite for **Assignment 02** of the **Software Testing and Validation (CSE2522)** course. The project implements automated web testing scenarios using the **Page Object Model (POM)** pattern.

The tests target the [UI Testing Playground](https://uitestingplayground.com/), focusing on various web interactions such as alerts, text inputs, client-side delays, and sample application flows.

## Tech Stack
- **Language:** C#
- **Framework:** .NET 8.0
- **Testing Framework:** NUnit 3
- **Automation Tool:** Selenium WebDriver
- **Web Browser:** Google Chrome (via ChromeDriver)

## Project Structure
The project is organized following best practices for test automation:

- **`Framework/`**: Contains core utility classes and base configurations.
  - `BasePage.cs`: Base class for all Page Objects.
  - `TestDriver.cs`: Manages WebDriver initialization and lifecycle.
  - `TestDataHelper.cs` & `TestCaseSourceHelper.cs`: Utilities for handling data-driven testing.
- **`Pages/`**: Implements the Page Object Model (POM). Each page on the website has a corresponding class defining its elements and operations.
- **`Tests/`**: Contains the NUnit test classes categorized by functionality.
  - `AlertsPageTests/`: Tests for Alerts page.
  - `ClientSideDelayPageTests/`: Tests for Client-side Delay page.
  - `SampleAppPageTests/`: Tests for SampleAppPage.
  - `TextInputPageTests/`: Tests for TextInputPage.
- **`DataFiles/`**: External JSON data files used for data-driven test scenarios.

## Key Features
- **Page Object Model (POM):** Decouples test logic from UI locators for better maintainability and readability.
- **Data-Driven Testing:** Utilizes external JSON files to execute tests with multiple datasets, ensuring comprehensive coverage.
- **Robust Synchronization:** Implements Selenium explicit waits to handle dynamic web elements and asynchronous page behaviors.
- **Scalable Architecture:** A modular framework designed to be easily extensible for additional test scenarios.

## Getting Started

### Prerequisites
- [.NET 8.0 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- [Google Chrome](https://www.google.com/chrome/) browser.

### Repository Clone
Clone the repository to your local machine:
   ```bash
   git clone git@github.com:nivaethan-dev/FC222008_SoftwareTestingAndValidation_Assignment_02.git
   ```
## Test Cases Covered
The following test cases are automated in this project, matching the implementation in the source code:

### 1. Text Input Tests (`TextInputPageTests`)
- **TC001_1:** Verification of page display and dynamic button text update.
- **TC001_2:** Verification of UI element (textbox and button) visibility. (Additional)
- **TC001_3:** Verification that the textbox correctly retains user input. (Additional)

### 2. Sample App Tests (`SampleAppPageTests`)
- **TC002_1:** Verification of the Sample App page display.
- **TC002_2:** Verification of successful login with valid credentials (using JSON data).
- **TC002_3:** Verification of unsuccessful login with invalid credentials (using JSON data).

### 3. Client Side Delay Tests (`ClientSideDelayPageTests`)
- **TC003_1:** Verification of the page, loading indicator appearance, and delayed banner text after client-side calculation.

### 4. Alerts Tests (`AlertsPageTests`)
- **TC004_1:** Verification of the Alerts page and interaction buttons display.
- **TC004_2:** Verification of alert appearance and message text.
- **TC004_3:** Verification of confirmation alerts and the resulting dependent second alert (Accept/Dismiss).
- **TC004_4:** Verification of prompt alerts, including user input handling and secondary validation alerts.

## Author
**R. Nivaethan**  
*Student at University of Sri Jayawardenepura*
