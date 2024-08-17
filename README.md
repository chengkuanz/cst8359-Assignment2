# Fan Club Web Application

## Overview

This project is a comprehensive **Fan Club Web Application** developed using **ASP.NET Core MVC** and **Entity Framework**. The application facilitates the management of fan subscriptions across various sports clubs, the administration of sports-related news, and the execution of CRUD (Create, Read, Update, Delete) operations for fans, clubs, and news.

You can access the deployed web app [here](https://chengkuanassg2-hcenbtb4gjdjg0gs.canadacentral-01.azurewebsites.net/).

## Features

### Fan Management
- **View Fans**: Display a list of all fans with options to view detailed profiles and associated subscriptions.
- **Add Fans**: Register new fans by providing essential details such as name, birthdate, and sports club subscriptions.
- **Edit Fans**: Update existing fan information and manage their subscriptions to different sport clubs.
- **Delete Fans**: Safely remove fans from the database, along with all their associated subscriptions.

### Sport Club Management
- **Create Sport Clubs**: Add new sport clubs with unique registration numbers, titles, and membership fees.
- **View Sport Clubs**: List all sport clubs with options to view detailed information, including current news and subscribed fans.
- **Edit Sport Clubs**: Update sport club details and manage related news postings.
- **Delete Sport Clubs**: Safely remove sport clubs from the database, ensuring all associated news is deleted first to maintain data integrity.

### Subscription Management
- **Manage Subscriptions**: Fans can subscribe or unsubscribe from sport clubs through a user-friendly interface.
- **Sorting Logic**: Enhance user experience by displaying current subscriptions first, followed by other clubs sorted alphabetically.

### News Management
- **Upload News**: Authorized users can upload news images related to sport clubs.
- **View News**: Display news items associated with a specific sport club, including the file name and images.
- **Delete News**: Safely remove news items from the database, with checks to ensure integrity before deletion.

## Technologies Used

- **ASP.NET Core MVC**: For developing the web application following the Model-View-Controller pattern.
- **Entity Framework Core**: As an ORM (Object-Relational Mapper) to interact with the database using .NET objects.
- **Azure SQL Database**: For secure and scalable data storage.
- **Azure Blob Storage**: For storing media files (news images).
- **Azure Web App**: For deploying the application to the cloud.
- **Bootstrap**: For responsive design and a consistent user interface.
- **C#**: The primary programming language used for back-end development.
- **LINQ (Language Integrated Query)**: For querying the database in a more readable and concise manner.
- **Razor Pages**: For generating dynamic web content using C# and HTML.
- **Data Annotations**: For model validation and enforcing rules on the data input.
- **Dependency Injection**: To inject services into controllers, following the SOLID principles.

## Requirements

- **.NET 8.0 SDK** or higher
- **Microsoft Visual Studio 2022** or a compatible IDE
- **Azure SQL Database** for data storage
- **Azure Blob Storage** for media file storage
- **Azure account** for web app deployment (optional)

## Contributors

This web application was developed by [Chengkuan Zhao](https://github.com/chengkuanz) and [Thi Thanh Van Le](https://github.com/Le-Vivian) between June 2022 and August 2022 as part of the **NET Enterprise Application Development** course (CST8359) at Algonquin College.
