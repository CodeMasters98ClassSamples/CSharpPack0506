using CSharpPack0506.BusinessLayer.Businesses.Abstract;
using CSharpPack0506.BusinessLayer.Dtos;
using CSharpPack0506.BusinessLayer.Extensions;
using CSharpPack0506.BusinessLayer.Validations;
using CSharpPack0506.DataLayer.Enums;
using CSharpPack0506.DataLayer.Models;
using CSharpPack0506.DataLayer.Repositories.Abstract;

namespace CSharpPack0506.BusinessLayer.Businesses;

/// <summary>
/// منطق کسب و کار دانشجو: اعتبارسنجی، تبدیل Dto به Model و فراخوانی Repository.
/// هیچ کد مربوط به بانک اطلاعاتی یا فایل در این کلاس وجود ندارد (اصل Single Responsibility).
/// </summary>
public class StudentBusiness : IStudentBusiness
{
    private readonly IStudentRepository _studentRepository;

    // Dependency Injection از طریق Constructor (به جای new کردن دسترسی به داده داخل متدها)
    public StudentBusiness(IStudentRepository studentRepository)
    {
        _studentRepository = studentRepository;
    }

    //Register
    public bool Register(RegisterDto dto)
    {
        if (!IsValid(dto.name, dto.lastName, dto.mobile))
            return false;

        Student st = new Student(
            name: dto.name.Trim(),
            lastName: dto.lastName.Trim(),
            mobile: dto.mobile.ToMobileFormat(),
            nationalCode: dto.nationalCode?.Trim() ?? string.Empty)
        {
            LastDocument = ParseLastDocument(dto.LastDocument),
        };

        return Execute(() => _studentRepository.Insert(st));
    }

    // ثبت نام توسط ادمین
    public bool RegisterByAdmin(RegisterStudentByAdminDto dto)
    {
        if (!IsValid(dto.name, dto.lastName, dto.mobile))
            return false;

        if (dto.birthDate == DateTime.MinValue)
        {
            // Log -> File , Db , ...
            Console.WriteLine("Error: تاریخ تولد نامعتبر است.");
            return false;
        }

        Student st = new Student(
            name: dto.name.Trim(),
            lastName: dto.lastName.Trim(),
            mobile: dto.mobile.ToMobileFormat(),
            nationalCode: dto.nationalCode?.Trim() ?? string.Empty,
            birthDate: dto.birthDate);

        bool isSuccess = Execute(() => _studentRepository.Insert(st));

        if (isSuccess)
            NotifyManager();

        return isSuccess;
    }

    public bool Update(UpdateStudentDto dto)
    {
        if (!IsValid(dto.Name, dto.LastName, mobile: null, validateMobile: false))
            return false;

        Student st = new Student
        {
            Id = dto.UserId,
            Name = dto.Name.Trim(),
            LastName = dto.LastName.Trim(),
        };

        return Execute(() => _studentRepository.Update(st));
    }

    public bool HardDelete(int id)
    {
        return Execute(() => _studentRepository.HardDelete(id));
    }

    public bool SoftDelete(int id)
    {
        return Execute(() => _studentRepository.SoftDelete(id));
    }

    public Student? GetById(int id)
    {
        return Execute(() => _studentRepository.GetById(id));
    }

    public List<Student> GetStudents()
    {
        return Execute(() => _studentRepository.GetAll()) ?? new List<Student>();
    }

    // داده ماک: خواندن از دیتاسورس شبیه سازی شده در Data Layer
    public List<Student> LoadStudentMockData()
    {
        return Execute(() => _studentRepository.GetAll()) ?? new List<Student>();
    }

    private static bool IsValid(string? name, string? lastName, string? mobile, bool validateMobile = true)
    {
        if (string.IsNullOrWhiteSpace(name) || name.Trim().Length < 2)
            return false;

        if (string.IsNullOrWhiteSpace(lastName) || lastName.Trim().Length < 2)
            return false;

        // ترتیب مهم است: ابتدا شماره همراه به فرم استاندارد تبدیل و سپس اعتبارسنجی می شود
        // مثلا "+989129564205" ابتدا به "09129564205" تبدیل می شود و سپس معتبر شناخته می شود.
        if (validateMobile && (mobile is null || !MobileValidation.Validate(mobile.ToMobileFormat())))
            return false;

        return true;
    }

    /// <summary>
    /// اطلاع رسانی به مدیر (Bale / SMS / Email).
    /// فعلا پیاده سازی نشده است؛ در آینده با یک سرویس Notification جایگزین می شود.
    /// </summary>
    private static void NotifyManager()
    {
        //
    }

    private static LastDocumentTypes ParseLastDocument(string? lastDocument)
    {
        return Enum.TryParse(lastDocument, ignoreCase: true, out LastDocumentTypes result)
            ? result
            : LastDocumentTypes.NONE;
    }

    /// <summary>
    /// مدیریت متمرکز خطا (DRY): پیام خطا یک بار لاگ می شود و خروجی متد false/null می گردد.
    /// </summary>
    private static T Execute<T>(Func<T> action)
    {
        try
        {
            return action();
        }
        catch (Exception ex)
        {
            // Log -> File , Db , ...
            Console.WriteLine($"Error: {ex.Message}");
            return default!;
        }
    }
}
