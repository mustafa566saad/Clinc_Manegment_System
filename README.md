# Clinic Management System

## 📌 Overview

The **Clinic Management System** is a backend project built with **ASP.NET Core** that helps manage clinic operations. Patients can register, log in, book appointments, while doctors can view their assigned appointments, add diagnoses, and provide treatment plans. The project uses **ASP.NET Identity Scaffolding** for secure user authentication and integrates with a **SQL Server database** using Entity Framework Core.

---

## 🚀 Features

### 👤 Patient Features

* Register and log in using ASP.NET Identity
* Manage personal profile
* Book appointments with doctors
* View appointment status (Pending / Approved / Completed)
* View siagoonsis
* Veiw medication 

### 🩺 Doctor Features

* View appointments assigned to them
* Add diagnosis and treatment plans
* Update appointment status

### 🔐 Security & Authentication

* ASP.NET Identity Scaffolding (password hashing, login, roles)
* Role-based access control (Admin / Doctor / Patient)
* Secured API endpoints

---

## 🛠 Tech Stack

### Backend

* ASP.NET Core 10
* Entity Framework Core (Code-First)
* Identity Scaffolding

### Database

* SQL Server

### API

* RESTful endpoints compatible with any frontend (Flutter, React, Angular, etc.)

---

## 📁 Project Structure

```text
Clinic_Manegment_System/
├── Controllers/
│   ├── AccountController.cs
│   ├── AppointmentController.cs
│   ├── DiagonsisController.cs
│   ├── MedicationController.cs
│   ├── RolesController.cs
│   └── DepartmentController.cs
├── Models/
│   ├── ApplicationUser.cs
│   ├── Appointment.cs
│   ├── Diagnosis.cs
│   ├── Department.cs
│   ├── Doctors.cs
│   ├── Patient.cs
│   ├── Mefication.cs
├── Data/
│   └── ClincContext.cs
├── Repositories/
│   ├── AccountRepo.cs
│   ├── AppointmentRepo.cs
│   ├── DiagnosisRepo.cs
│   ├── DeptRepo.cs
│   ├── RolesRepo.cs
│   ├── Patient.cs
│   └── MeficationRepo.cs
├── Services/
│   └── LoginServices.cs
├── Migrations/
└── Program.cs
```

---

## 🔐 Authentication Flow

1. User registers → Stored in Identity database
2. User logs in → Identity issues authentication cookie/token
3. Authenticated user can:

   * Book appointments
   * View their reservations
   * Access protected API endpoints

---

## 📝 API Endpoints

### 🔑 Authentication

| Method | Endpoint             | Description                     |
| ------ | -------------------- | ------------------------------- |
| POST   | `/api/auth/register` | Register a new user             |
| POST   | `/api/auth/login`    | Login and obtain authentication |

### 🗓 Appointments

| Method | Endpoint                     | Description                        |
| ------ | ---------------------------- | ---------------------------------- |
| POST   | `/api/appointments/book`     | Book an appointment                |
| GET    | `/api/appointments/user`     | Get logged-in patient appointments |
| GET    | `/api/appointments/doctor`   | Get doctor-specific appointments   |

### 🗓 Department

| Method | Endpoint                     | Description                        |
| ------ | ---------------------------- | ---------------------------------- |
| POST   | `/api/Department/Add`        | Add Department                     |
| POST   | `/api/Department/Delete`     | Delete Department                  |
 

### 🗓 Diagonsis

| Method | Endpoint                     | Description                        |
| ------ | ---------------------------- | ---------------------------------- |
| POST   | `/api/Diagonsis/Add`        | Add Department                      |
| POST   | `/api/Diagonsis/Update`     | Update Department                   |

### 🗓 Medication

| Method | Endpoint                     | Description                        |
| ------ | ---------------------------- | ---------------------------------- |
| POST   | `/api/Medication/Add`        | Add Medication                     |
| GET    | `/api/Medication/getMedication`| Get Medication per user          |

### 🗓 Roles

| Method | Endpoint                     | Description                        |
| ------ | ---------------------------- | ---------------------------------- |
| POST   | `/api/Roles/Add`             | Add Roles                          |
| POST   | `/api/Roles/ChangeUserRole`  | Change Roles per user              |

---

## 🧪 How to Run

### 1️⃣ Clone the Repository

```bash
git clone https://github.com/mustafa566saad/Clinc_Manegment_System.git
cd Clinc_Manegment_System
```

### 2️⃣ Configure Database

Update `appsettings.json`:

```json
"ConnectionStrings": {
    "cs": "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=ClincManegment;Integrated Security=True;Connect Timeout=30;Encrypt=False"
}
```

### 3️⃣ Apply Migrations

```bash
dotnet ef database update
```

### 4️⃣ Run the Project

```bash
dotnet run
```

---

## 🤝 Contributing

Contributions are welcome!
If you plan major changes, please open an issue first to discuss them.

---

## 📄 License

This project is licensed under the **MIT License**.

---

## ✨ Author

**Mostafa Mohamed** – Backend Developer
