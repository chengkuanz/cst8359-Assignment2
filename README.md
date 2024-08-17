# Fan Club Web Application

## Overview

This project involves developing a Fan Club Web Application using **ASP.NET Core MVC** and **Entity Framework**. The application allows users to manage fan subscriptions to various sports clubs, upload and manage news related to sports clubs, and perform CRUD (Create, Read, Update, Delete) operations.

### Features

#### Fan Management
- **View Fans**: Display a list of all fans with options to view detailed profiles.
- **Add Fans**: Register new fans with fields like name, birthdate, and subscriptions.
- **Edit Fans**: Update existing fan information and manage their subscriptions to different sport clubs.
- **Delete Fans**: Remove fans from the database, including all related subscriptions.

#### Sport Club Management
- **Create Sport Clubs**: Add new sport clubs with unique registration numbers, titles, and membership fees.
- **View Sport Clubs**: List all sport clubs with options to view detailed information, including current news and subscribed fans.
- **Edit Sport Clubs**: Update sport club details and manage news postings.
- **Delete Sport Clubs**: Safely remove sport clubs from the database, ensuring all associated news is deleted first to maintain data integrity.

#### Subscription Management
- **Manage Subscriptions**: Fans can subscribe or unsubscribe from sport clubs through a user-friendly interface.
- **Sorting Logic**: Display current subscriptions first, followed by other clubs sorted alphabetically, enhancing user experience.

#### News Management
- **Upload News**: Authorized users can upload news items related to sport clubs, including text and images.
- **View News**: Display news items associated with a sport club, with details like the date posted and content.
- **Delete News**: Remove news items from the database, with checks to ensure integrity before deletion.

---

## Requirements

- **.NET 8.0 SDK** or higher
- **Microsoft Visual Studio 2022** or a compatible IDE
- **SQL Server** (Local or Azure SQL Database)
- **Azure account** for deployment (optional)

---

## Contributors

This web application was developed by [Chengkuan Zhao](https://github.com/chengkuanz) and [Thi Thanh Van Le](https://github.com/Le-Vivian) between June 2022 and August 2022 as part of the **NET Enterprise Application Development** course (CST8359) at Algonquin College.
