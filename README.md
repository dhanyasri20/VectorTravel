<img width="1893" height="903" alt="Screenshot 2025-09-16 235458" src="https://github.com/user-attachments/assets/39824526-cf00-4948-87b6-ed274a45c37a" /># VectorTravel <img width="500" height="500" alt="VectorTravellogo" src="https://github.com/user-attachments/assets/5df120f9-6ee9-45c6-b2a1-c823116a75da" /> 
### Your Direction to the World.

![.NET](https://img.shields.io/badge/.NET-512BD4?style=for-the-badge&logo=dotnet&logoColor=white)
![C#](https://img.shields.io/badge/C%23-239120?style=for-the-badge&logo=c-sharp&logoColor=white)
![Bootstrap](https://img.shields.io/badge/Bootstrap-563D7C?style=for-the-badge&logo=bootstrap&logoColor=white)
![Microsoft SQL Server](https://img.shields.io/badge/Microsoft%20SQL%20Server-CC2927?style=for-the-badge&logo=microsoft%20sql%20server&logoColor=white)

A full-stack flight booking web application built with ASP.NET Core MVC that demonstrates a complete, end-to-end user workflow from searching for flights to generating a PDF e-ticket.

<img width="1893" height="910" alt="Screenshot 2025-09-16 235406" src="https://github.com/user-attachments/assets/1a5160d5-e6c6-49b8-8aef-b088ea78c833" />
<img width="1890" height="904" alt="Screenshot 2025-09-16 235427" src="https://github.com/user-attachments/assets/674f16b2-374a-4c96-b13e-bca56e761173" />
<img width="1893" height="903" alt="Screenshot 2025-09-16 235458" src="https://github.com/user-attachments/assets/8f14f1f5-21eb-4ad5-a8af-26232c659b44" />
<img width="1895" height="909" alt="Screenshot 2025-09-16 235519" src="https://github.com/user-attachments/assets/22c91732-7409-4eec-beb8-87802c80424e" />

---
## Table of Contents
* [About The Project](#about-the-project)
* [Built With](#built-with)
* [Key Features](#key-features)
* [Getting Started](#getting-started)

---

## About The Project

VectorTravel was created to showcase a comprehensive, portfolio-ready web application. It handles complex back-end logic, including secure user authentication, database management with Entity Framework, and dynamic PDF generation, all presented through a clean, modern, and responsive user interface.

---

## Built With

This project was built using a modern, robust tech stack:
* **Backend:** ASP.NET Core MVC, C#
* **Database:** Entity Framework Core & Microsoft SQL Server
* **Frontend:** HTML, CSS, Bootstrap, JavaScript
* **Authentication:** ASP.NET Core Identity
* **Libraries:** IronPDF (for PDF generation), QRCoder (for QR codes)

---

## Key Features

* ✅ **Full User Authentication:** Secure user registration and login system.
* ✅ **Flight Search:** Users can search for available flights based on their criteria.
* ✅ **End-to-End Booking:** A complete workflow from selecting a flight to a final confirmation page.
* ✅ **My Bookings Management:** A dedicated page for users to view their past bookings and cancel them.
* ✅ **Payment Integration:** Integrating a real payment system is an excellent "next-level" feature for your project. Here’s how it works.
* ✅ **Dynamic PDF E-Tickets:** After booking, a professional PDF e-ticket with a unique QR code is automatically generated.
* ✅ **Holiday Package Showcase:** A section to display and detail special holiday packages.
* ✅ **Professional UI/UX:** Features a custom brand identity and a modern, transparent-on-scroll navigation bar.  
---

## Getting Started

To get a local copy up and running, follow these simple steps.

### Prerequisites
* [.NET 9 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/9.0) 
* [Microsoft SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads)

### Installation
1. Clone the repo
   ```sh
   git clone [https://github.com/dhanyasri20/VectorTravel.git](https://github.com/dhanyasri20/VectorTravel.git)
    ```
2. Open the project in Visual Studio.
3. In the appsettings.json file, update the database connection string to point to your local SQL Server instance.
4. Open the Package Manager Console and run the database migration:
    ```sh
    Update-Database
     ```
5. Run the project by pressing F5 or the green 'Play' button.

### Usage
This application provides a seamless user experience for booking travel.

1. Search for Flights on the Homepage

2. View and Select from Search Results

3. Confirm Booking and Payment

4. View Bookings and Download PDF E-Ticket
   
## License

Distributed under the MIT License. See `LICENSE` file for more information.
