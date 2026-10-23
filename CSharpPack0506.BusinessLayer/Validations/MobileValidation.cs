namespace CSharpPack0506.BusinessLayer.Validations;

public static class MobileValidation
{

    public static bool Validate(string mobile)
    {
        if (mobile == null)
            return false;

        mobile = mobile.Trim();
        if (mobile.Length != 11)
        {
            return false;
        }
        else
        {
            return true;
        }
    }
}
