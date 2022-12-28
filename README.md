# Amazon
This is similar to Amazon website that is having sub functionality like Products page with Searching Items and Ensuing the data integrity, consistency and redundancy by using distributed data base
<!-- TABLE OF CONTENTS -->
### Table of Contents
  <ol>
    <li>
      <a href="#about-the-project">About The Project</a>
      <ul>
        <li><a href="#built-with">Built With</a></li>
      </ul>
    </li>
    <li>
      <a href="#getting-started">Getting Started</a>
      <ul>
        <li><a href="#prerequisites">Prerequisites</a></li>
        <li><a href="#installation">Installation</a></li>
      </ul>
    </li>
    <li><a href="#Test code">Test code</a></li>
    <li><a href="#references">References</a></li>
  </ol>
  
<!-- ABOUT THE PROJECT -->
## About The Project
We have worked on developing an similar Amazon website to ensure data integrity, consistency and redundancy using distributed data base.
![image](https://user-images.githubusercontent.com/43805517/196080147-bb2e9ccd-6878-49ef-bd59-621e56f82fc0.png)

### Built With
This section is going to list down all the frameworks/libraries used to build our project. Here are a few examples.
* .NET 6.0
* ASP.NET
* C#
* Azure SQL Server and Database

<!-- GETTING STARTED -->
## Getting Started
This is an example of how you may give instructions on setting up your project locally.
To get a local copy up and running follow these simple example steps.
### Prerequisites
Following list of softwares are required to run this application.
* Visual Studio/Visual Studio Code
* .NET 6.0
* Nuget packages
* Entity Framework
* Azure SQL Server
* Azure SQL Database

### Installation
_Below is an example of how you can instruct your audience on installing and setting up your app._
1. Clone the repo
   ```sh
   git clone https://github.com/your_username_/Amazon.git
   ```
2. Install nuget packages (if required)
3. Open Visual studio
4. Get the Connection string for database and add into solution
5. Build the solution by Clicking on 'CTRL + SHIFT + B'
6. Select Amazon project as startup project in the Solution Explorer and
7. Run the solution

<!-- TEST CODE -->
## Test code
We can test the application code by using two types of Tests:
1. Unit Tests
2. Functional Tests

**1. Unit Tests**
We have created few unit tests to test the each component of the project.
Select Amazon.Tests project as startup project.
Open Tests Explorer in Visual Studio
There are 10 unit tests available to test the application
Right click on Amazon.Tests and click on Run
Unit Tests will be executed

**2. Functional Tests**
```sh 
Test 1:
Verify Username and Password fields with invalid input text. 
Expected Result – It should display error message as “Invalid Username or Password” 
```
```sh
Test 2:
Verify Sign in button works for valid credentials 
Expected Result – Sign in button should work
```
```sh
Test 3:
Verify Sign up account button works for valid credentials 
Expected Result – Sign up button should work for new account creation and we can verify this by logging into application
```
```sh
Test 4:
Verify search products by product name
Expected Result – Products should be displayed as per product name.
```
```sh
Test 5:
Verify search products by product description
Expected Result – Products should be displayed as per product description.
```
<!-- LICENSE -->
## License
Distributed under the MIT License.
<!-- REFERENCES -->
## References
Following are few references used for developing our application.
* .NET 6.0 - https://dotnet.microsoft.com/en-us/download/dotnet/6.0
* MIT License - https://opensource.org/licenses/MIT
