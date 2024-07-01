namespace FinancialRevenues.Base;

public static class DisplayContent
{
    public static string LanguageSwitcher(string nameAr,string nameEn)
    {
        return Thread.CurrentThread.CurrentUICulture.TwoLetterISOLanguageName.ToLower() == "en" ? nameEn  : nameAr;
    }
}