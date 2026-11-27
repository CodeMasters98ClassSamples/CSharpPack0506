# معماری پروژه (3-Layer / N-Tier)

این پروژه بر اساس معماری سه لایه (3-Layer Architecture) و اصول Clean Code مرتب شده است.
قاعده طلایی: **وابستگی ها فقط یک طرفه و از بالا به پایین است.**

```
Presentation  ->  Business  ->  Data
(UI)              (BLL)        (DAL)
```

- لایه بالاتر به Interface لایه پایین وابسته است، نه به کلاس Concrete.
- هیچ لایه ای به لایه بالاتر خود وابسته نیست.
- لایه Presentation هیچ اطلاعی از SQL / فایل / Connection String ندارد.

---

## 1) Data Layer (DAL) — `CSharpPack0506.DataLayer`

قرارداد: «اگر کد به بانک اطلاعاتی/فایل/دیتاسورس می‌خورد، جای آن فقط اینجاست.»

```
CSharpPack0506.DataLayer/
├── Configuration/
│   └── DatabaseOptions.cs          // Holder برای Connection String (بدون Hard Code)
├── Data/
│   └── MockData/                   // students.json , logins.txt  (Embedded Resource)
├── Database/
│   ├── scripts/data.sql            // Query های T-SQL آموزش
│   └── tables/*.sql                // Script ساخت جداول
├── Enums/
│   ├── LastDocumentTypes.cs
│   └── RegistrationStatus.cs
├── Models/                         // Entity ها
│   ├── Course.cs  Master.cs  Student.cs  StudentTerm.cs  Term.cs  User.cs
└── Repositories/
    ├── Abstract/                   // Interface ها (قرارداد)
    │   ├── ILoginRepository.cs
    │   └── IStudentRepository.cs
    └── Concrete/                   // پیاده سازی (SQL Server / File / Mock)
        ├── LoginRepository.cs
        ├── StudentMockRepository.cs
        └── StudentRepository.cs
```

نکات مهم:
- تنها این لایه `Microsoft.Data.SqlClient` و `Newtonsoft.Json` را نصب کرده است.
- همه Query ها با **Parameter** نوشته می‌شوند (جلوگیری از SQL Injection).
- `SqlConnection` / `SqlCommand` / `SqlDataReader` با `using` مدیریت می‌شوند.
- فایل های Mock به عنوان Embedded Resource هستند؛ بنابراین هیچ لایه ای مسیر فایل (`Path`) را نمی‌شناسد.

## 2) Business Layer (BLL) — `CSharpPack0506.BusinessLayer`

قرارداد: «قوانین کسب و کار، اعتبارسنجی و تبدیل Dto↔Model، بدون دانش از نوع دیتاسورس.»

```
CSharpPack0506.BusinessLayer/
├── BusinessLayerExtensions.cs      // ثبت وابستگی ها در ServiceCollection (Composition)
├── Businesses/
│   ├── Abstract/
│   │   ├── IAuthBusiness.cs
│   │   └── IStudentBusiness.cs
│   ├── AuthBusiness.cs             // منطق ورود (قبلا داخل LoginForm بود)
│   └── StudentBusiness.cs          // منطق ثبت نام/ویرایش/حذف دانشجو
├── Dtos/                           // Data Transfer Objects
│   ├── LoginResultDto.cs  RegisterDto.cs  RegisterStudentByAdminDto.cs  UpdateStudentDto.cs
├── Extensions/
│   └── StringExtensions.cs         // ToMobileFormat
└── Validations/
    └── MobileValidation.cs
```

نکات مهم:
- کلاس های Business فقط **Interface** های Repository را می‌شناسند (Dependency Inversion).
- Repository از طریق Constructor تزریق می‌شود؛ هیچ `new StudentRepository()` داخل متدها وجود ندارد.
- اعتبارسنجی ها (طول نام، شماره همراه، تاریخ تولد) اینجا انجام می‌شود؛ لایه UI فقط پیام نتیجه را نشان می‌دهد.
- مدیریت خطا متمرکز است (متد `Execute` و `LoginResultDto.Unavailable`).

## 3) Presentation Layer — پروژه های UI

```
CSharpPack0506.MyWinFormsApp/       // WinForms (Composition Root در Program.cs)
CSharpPack0506.MyConsole/           // Console
CSharpPack0506.MyWebApplication/    // ASP.NET Core Razor Pages
```

قواعد لایه نمایش:
- هیچ `using Microsoft.Data.SqlClient` یا `System.IO.File` در فرم ها وجود ندارد.
- فرم ها Interface می‌گیرند: `LoginForm(IAuthBusiness)`, `RegisterUserForm(IStudentBusiness)`.
- ساخت فرم ها و سرویس ها فقط در Composition Root انجام می‌شود (`Program.cs`).
- Connection String از `App.config` (WinForms) یا `appsettings.json` (Web) خوانده می‌شود.

---

## نمودار جریان یک درخواست (مثال: ثبت نام دانشجو)

```
RegisterUserForm.createUserButton_Click()
        |  RegisterStudentByAdminDto
        v
IStudentBusiness.RegisterByAdmin(dto)          [Business Layer]
        |  اعتبارسنجی + تبدیل Dto به Student
        v
IStudentRepository.Insert(student)             [Data Layer]
        |  INSERT INTO dbo.Student ...
        v
SQL Server
```

## نحوه اجرای پروژه

- **WinForms**: `dotnet run --project CSharpPack0506.MyWinFormsApp` (نیازمند SQL Server و دیتابیس `CSharpPack0506DB`)
- **Console**: `dotnet run --project CSharpPack0506.MyConsole` (با داده ماک اجرا می‌شود؛ نیازی به DB نیست)
- **Web**: `dotnet run --project CSharpPack0506.MyWebApplication`

## تعویض نوع دیتاسورس

برای تغییر دیتاسورس یا استفاده از داده ماک، فقط کافی است پیاده سازی دیگری از `IStudentRepository` ثبت شود:

```csharp
// Composition Root
services.AddBusinessLayerWithMockData();            // داده ماک (فایل JSON)
// یا
services.AddBusinessLayer(new DatabaseOptions { ConnectionString = "..." }); // SQL Server
```

هیچ خطی از Business Layer و Presentation Layer تغییر نمی‌کند (Open/Closed Principle).

## قدم های بعدی پیشنهادی

- اضافه کردن **Unit Test** برای `StudentBusiness` با یک `IStudentRepository` جعلی (Fake).
- جایگزینی ADO.NET با **Entity Framework Core** (فقط داخل `Repositories/Concrete`).
- انتقال سرویس اطلاع رسانی (Bale/SMS) به یک Interface جدا (`INotificationService`) و تزریق آن به Business.
