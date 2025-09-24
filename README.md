# VectorTravel: A Full-Stack Travel Booking Platform

<p align="center">
  <img width="200" height="200" alt="VectorTravel Logo" src="https://github.com/user-attachments/assets/5df120f9-6ee9-45c6-b2a1-c823116a75da">
</p>
<h3 align="center">Your Direction to the World.</h3>

<p align="center">
<img src="https://img.shields.io/badge/.NET-512BD4?style=for-the-badge&logo=dotnet&logoColor=white" />
<img src="https://img.shields.io/badge/c%23-%23239120.svg?style=for-the-badge&logo=c-sharp&logoColor=white" />
<img src="https://img.shields.io/badge/Microsoft%20SQL%20Server-CC2927?style=for-the-badge&logo=microsoft%20sql%20server&logoColor=white" />
<img src="https://img.shields.io/badge/Bootstrap-563D7C?style=for-the-badge&logo=bootstrap&logoColor=white" />
</p>

A comprehensive flight and holiday package booking platform built with ASP.NET Core MVC. This project showcases a complete, end-to-end web application, from an "inspiration-first" discovery gallery to dynamic, QR-coded e-ticket generation after secure payment.

---
## 📸 Screenshots

 ## Homepage                                                                              
<img width="1891" height="896" alt="image" src="https://github.com/user-attachments/assets/16e2a1d3-0573-4b89-8850-0d22afaac3cf" />
<img width="1914" height="902" alt="image" src="https://github.com/user-attachments/assets/56be5dae-bba8-45a7-a934-879c83dbae24" />
<img width="1909" height="906" alt="image" src="https://github.com/user-attachments/assets/374e0c96-d4bc-4e78-9ea0-13bcab2708b2" />

## Inspiration Gallery       
<img width="1913" height="911" alt="image" src="https://github.com/user-attachments/assets/c8382374-7b87-4f7d-ab00-51c9a80d3c10" />
<img width="1899" height="901" alt="image" src="https://github.com/user-attachments/assets/c1a68058-98fa-4763-a13d-00e973065f68" /> 

## HolidayPackages Page  
<img width="1898" height="915" alt="image" src="https://github.com/user-attachments/assets/f4fb2338-4d12-491d-b027-e6e86a5fa44a" />
<img width="1905" height="911" alt="image" src="https://github.com/user-attachments/assets/94db0bdc-f082-4bf5-86a4-cd41b5f4571b" />

## ✨ Key Features

* ✅ **Secure User Registration & Login:** A complete user authentication system using ASP.NET Core Identity, allowing users to create accounts and manage their profiles.
* 🎨 **Aesthetic "Inspiration-First" Gallery:** A Pinterest-style, dark-themed gallery with interactive filters to help users discover new travel destinations.
* ✈️ **Dynamic Flight Search:** Users can search for flights based on departure/arrival cities and date from a comprehensive flight database.
* 📦 **Holiday Package Showcase:** A dedicated section to display and detail special, curated holiday packages with descriptions and pricing.
* 💺 **Interactive Seat Selection:** A visual seat map allows users to select their preferred seat, which is then locked upon booking.
* 💳 **Secure Payments with Razorpay:** End-to-end payment processing handled securely via the Razorpay API.
* 🎫 **Dynamic PDF E-Tickets:** After a successful booking, a professional PDF e-ticket with a unique **QR code** is automatically generated for the user to download.
* 📋 **My Bookings Dashboard:** A dedicated, protected section for users to view their booking history, see ticket details, and manage their trips.
* 📱 **Fully Responsive UI:** A clean and modern user interface built with Bootstrap 5, ensuring a seamless experience on all devices.

---

## 🛠️ Tech Stack

| Category           | Technologies & Tools                                       |
| ------------------ | ---------------------------------------------------------- |
| **Backend** | C#, ASP.NET Core MVC, .NET 9                                      |
| **Database** | Entity Framework Core, Microsoft SQL Server                      |
| **Frontend** | HTML5, CSS3, JavaScript, jQuery, Bootstrap 5                     |
| **Authentication** | ASP.NET Core Identity                                      |
| **Payments** | Razorpay API                                                     |
| **PDF & QR Codes** | IronPDF, QRCoder                                           |
| **IDE** | Visual Studio 2022                                                    |

---

## ⚙️ Getting Started

To get a local copy up and running, follow these simple steps.

### Prerequisites
* .NET 9 SDK
* Microsoft SQL Server

### Installation
1.  Clone the repo:
    ```sh
    git clone [https://github.com/dhanyasri20/VectorTravel.git](https://github.com/dhanyasri20/VectorTravel.git)
    ```
2.  Open the project in Visual Studio.
3.  In the `appsettings.json` file, update the `DefaultConnection` string to point to your local SQL Server instance.
4.  Open the **Package Manager Console** and run the database migration:
    ```sh
    Update-Database -Context ApplicationDbContext
    ```
5.  **(Optional) Seed Initial Data:** Run the SQL scripts in the project to populate the database with initial flights, inspiration images, etc.
6.  Run the project by pressing `Ctrl + F5` or the "Start Without Debugging" button.

 ---
## 📜 License

Distributed under the MIT License. See `LICENSE` for more information.
