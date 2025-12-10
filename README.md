# 🚗 DVLD Management System

A desktop application for managing **driving licenses**, **tests**, **renewals**, and **international licenses**.  
Built using **C# (.NET Framework)**, **WinForms**, **SQL Server**, and **3-Tier Architecture**.

---

## 📌 Features

###  ✔ People & Users Management
- Add People & Users
- Update Information
- Delete
- Search & Filtering

### ✔ License Management
- Apply for **local** and **international** driving licenses  
- Renew licenses  
- Manage license tests  
- Detain and release licenses

### ✔ Test Management
- Passed 3 Tests (Vision - Writte - Street)
- Validation For Each Test
- Appointment a Test For Each Applicant
- Update The Appointment Date

### ✔ Additional System Features
- Login/Register module  
- Date displayed on all screens  
- OOP-based structure  
- Input validation using template functions  

---

## 🛠️ Technologies Used

- C# (.NET Framework)  
- WinForms  
- SQL Server  
- SSMS (SQL Server Management Studio)  
- ADO.NET  
- 3-Tier Architecture  
- OOP Concepts  

---

# 📥 Installation & Setup

Follow these steps carefully to run the project.

---

## 1️⃣ Restore the Database

1. Navigate to the project folder → `Database/`
2. Copy **DVLD2.bak** to the **C:\** drive
3. Open **SQL Server Management Studio (SSMS)**
4. Run this script:

```sql
RESTORE DATABASE DVLD
FROM DISK = 'C:\DVLD2.bak'
WITH REPLACE;
```

**Make sure that:**
- SQL Server service is running  
- You have permission to restore databases  

---

## 2️⃣ Run the Application

1. Open **DVLD.sln** in Visual Studio  
2. Build the solution  
3. Run the application  

---

## 🔐 Login Credentials

Use the following credentials to access the system:

- **Username:** `Mohamed15`  
- **Password:** `12345`  

---

# 📂 Project Architecture (3-Tier)

```
📁 Presentation Layer (UI)
   → WinForms Screens & Controls

📁 Business Layer (BL)
   → Business logic
   → Validation
   → Rules & permissions

📁 Data Access Layer (DAL)
   → SQL queries
   → Database connection
   → CRUD operations
```

This architecture ensures:
- Clean separation of concerns  
- Easy maintenance  
- Higher scalability  
- Professional software engineering standards  

---

# 📄 License

This project is for educational and training purposes.  

---

# 🙌 Author

**Mohamed Kissame**  
