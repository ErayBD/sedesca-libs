# Sedesca Libs
SedescaLibs is a robust and flexible library management application developed using the ASP.NET Core MVC framework, based on .NET 7 version. The application encompasses all the tools required for smooth and effective management of a library's operations.

<br>

<p align="center"><img src="https://github.com/ErayBD/libmanage/assets/71061070/cf1baf9b-1d5e-4c6e-8d24-bc1962755ddc" style="width: 30%;"></p>

## Introduction
SedescaLibs is a modern library management application developed on the ASP.NET platform. The primary purpose of the application is to manage books, students, and their interrelationships within the library, streamlining this process effectively.

With various tables like Students, Books, StudentBooks, Author, Genre, MyBooks, and ReturnBook, the application can manage one-to-many and many-to-many relationships. For instance, a student can be associated with multiple books, or a book can be assigned to multiple students. These operations are easily managed through the "Borrow" and "Return" actions.

Logic and database operations executes in the Service layer, while MVC operations are performed in the Interface layer. The application also utilizes the ASP.NET Identity feature, thereby enabling users to carry out advanced authentication and authorization operations.

The application is designed with a user-friendly interface that allows users to effortlessly access and perform their tasks. This interface, created using Razor Pages, HTML, CSS, and Bootstrap technologies, enables users to easily perform CRUD operations on books, students, and their relationships.

Moreover, within the scope of security precautions, access to certain pages by users is controlled based on roles, and if no operation is performed for 5 minutes, the session is automatically terminated. This design aims to optimize the user experience and provide an application in line with the "clean code" principle.  

## How to Use
The application requires the ASP.NET platform and .NET Core 7 SDK on a local machine. After cloning the code from GitHub and installing the necessary dependencies, the project can be run with Visual Studio or the .NET CLI.
