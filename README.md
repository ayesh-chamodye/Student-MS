# Student Management System 🎓

A comprehensive Student Management System built with .NET and Microsoft SQL Server, featuring advanced QR code scanning functionality for streamlined student operations and enhanced security.

## 🌟 Features

### Core Functionality
- **Student Registration & Profile Management**
  - Complete student information storage
  - Academic record tracking
  - Personal and contact information management
  - Document upload and storage

- **QR Code Integration**
  - Generate unique QR codes for each student
  - Quick student identification and verification
  - Attendance tracking via QR scanning
  - Access control for facilities and events

- **Academic Management**
  - Course enrollment and management
  - Grade tracking and reporting
  - Semester/term management
  - Academic calendar integration

- **Administrative Tools**
  - Staff and teacher management
  - Role-based access control
  - Report generation and analytics
  - Data export capabilities

### Advanced Features
- **Real-time QR Code Scanning**
- **Automated Attendance System**
- **Digital ID Card Generation**
- **Comprehensive Reporting Dashboard**
- **Data Security & Backup**

## 🛠️ Technology Stack

| Component | Technology |
|-----------|------------|
| **Backend** | .NET Framework/Core |
| **Database** | Microsoft SQL Server (MSSQL) |
| **Frontend** | Windows Forms / WPF / ASP.NET |
| **QR Processing** | ZXing.NET or similar QR library |
| **Reporting** | Crystal Reports / RDLC |

## 📋 Prerequisites

Before running this project, ensure you have the following installed:

- [.NET Framework 4.7.2+](https://dotnet.microsoft.com/download/dotnet-framework) or [.NET Core 3.1+](https://dotnet.microsoft.com/download)
- [Microsoft SQL Server 2016+](https://www.microsoft.com/en-us/sql-server/sql-server-downloads) or SQL Server Express
- [Visual Studio 2019+](https://visualstudio.microsoft.com/) or Visual Studio Code
- [SQL Server Management Studio (SSMS)](https://docs.microsoft.com/en-us/sql/ssms/download-sql-server-management-studio-ssms)

## 🚀 Installation & Setup

### 1. Clone the Repository
```bash
git clone https://github.com/ayesh-chamodye/Student-MS.git
cd Student-MS
```

### 2. Database Setup
1. Open SQL Server Management Studio
2. Create a new database named `StudentManagementDB`
3. Execute the database scripts in the following order:
   ```sql
   -- Run these scripts from the /Database folder
   1. CreateTables.sql
   2. InsertSampleData.sql (optional)
   3. CreateStoredProcedures.sql
   ```

### 3. Configure Connection String
Update the connection string in `app.config` or `appsettings.json`:
```xml
<connectionStrings>
  <add name="DefaultConnection" 
       connectionString="Data Source=localhost;Initial Catalog=StudentManagementDB;Integrated Security=True" 
       providerName="System.Data.SqlClient" />
</connectionStrings>
```

### 4. Build and Run
```bash
# Restore NuGet packages
dotnet restore

# Build the solution
dotnet build

# Run the application
dotnet run
```

## 📊 Database Schema

### Core Tables
- **Students** - Student personal information and academic details
- **Courses** - Course catalog and descriptions
- **Enrollments** - Student-course relationships
- **Attendance** - QR-based attendance records
- **Staff** - Faculty and administrative staff
- **QRCodes** - Generated QR code mappings

### Key Relationships
```
Students (1) -----> (M) Enrollments (M) <----- (1) Courses
Students (1) -----> (M) Attendance
Students (1) -----> (1) QRCodes
```

## 🎯 Usage Guide

### Student Registration
1. Navigate to **Students > Add New Student**
2. Fill in required information
3. Upload student photo (optional)
4. System automatically generates QR code
5. Print student ID card with QR code

### QR Code Scanning
1. Use the built-in scanner or external QR reader
2. Scan student QR code
3. System displays student information instantly
4. Mark attendance or grant access as needed

### Generating Reports
1. Go to **Reports** section
2. Select report type (Attendance, Enrollment, etc.)
3. Set date range and filters
4. Export as PDF, Excel, or print directly

## 🔐 Security Features

- **Role-Based Access Control (RBAC)**
- **Encrypted QR Code Data**
- **Secure Database Connections**
- **User Authentication & Authorization**
- **Audit Trail Logging**

## 📱 QR Code Features

### Student QR Codes Include:
- Student ID
- Full Name
- Current Semester
- Enrollment Status
- Emergency Contact (optional)

### Scanning Capabilities:
- **Attendance Marking** - Quick check-in/check-out
- **Identity Verification** - Instant student lookup
- **Access Control** - Library, labs, dormitories
- **Event Management** - Seminar and activity attendance

## 🤝 Contributing

We welcome contributions! Please follow these steps:

1. Fork the repository
2. Create a feature branch (`git checkout -b feature/AmazingFeature`)
3. Commit your changes (`git commit -m 'Add some AmazingFeature'`)
4. Push to the branch (`git push origin feature/AmazingFeature`)
5. Open a Pull Request

### Development Guidelines
- Follow C# coding conventions
- Write unit tests for new features
- Update documentation for API changes
- Ensure database changes include migration scripts

## 📝 License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.

## 👨‍💻 Author

**Ayesh Chamodye**
- GitHub: [@ayesh-chamodye](https://github.com/ayesh-chamodye)
- Email: [your-email@example.com]

## 🐛 Bug Reports & Feature Requests

If you encounter any bugs or have suggestions for new features:

1. Check existing [Issues](https://github.com/ayesh-chamodye/Student-MS/issues)
2. Create a new issue with detailed description
3. Include steps to reproduce (for bugs)
4. Add relevant labels

## 📞 Support

For additional support or questions:
- Create an issue on GitHub
- Email: [support-email@example.com]
- Documentation: [Wiki](https://github.com/ayesh-chamodye/Student-MS/wiki)

## 🏆 Acknowledgments

- Thanks to all contributors who have helped improve this project
- Special thanks to the .NET and SQL Server communities
- QR code functionality powered by ZXing.NET library

---

## 🚀 Future Enhancements

- [ ] Mobile app integration
- [ ] Cloud deployment support
- [ ] REST API development
- [ ] Real-time notifications
- [ ] Advanced analytics dashboard
- [ ] Multi-language support
- [ ] Integration with learning management systems

---

⭐ **Star this repository if you find it helpful!**
