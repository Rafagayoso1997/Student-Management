# Student-Management

# Introduction

This is a C# project to show how persist students data in several databases, in this case **.txt files**, **.json files** and **.xml files**.

------------------------------------------------

# Getting Started

This system presents an architecture based on Domain Driven Design (DDD) as shown below:

![DDD Diagram](Images/DDD.jpg)

And the following UML Diagram shows the relationship between the classes. In this project the abstract factory design pattern is used for the construction of the different classes for data 
persistence.

![UML Diagram](Images/UML%20Diagram.jpg)


# How to use the application

1. Installation process
The software is available at [Github](https://github.com/Rafagayoso1997/Student-Management/releases/download/v1.0.0/StudentManagement.rar) and also by cloning this repository. 
2. Latest releases
The latest release corresponds to the v1.0.0 version.
3. Running the application.
Once the source code is clone, open the application on Visual Studio and run it. The application will show a windows where the user would see the data depends on what database was choosen.
the application allows the modification, deletion and insertion of new data on each database.

## Main Menu

![UML Diagram](Images/MainWindow.png)

## Insert Data Menu

![UML Diagram](Images/InsertWindow.png)
