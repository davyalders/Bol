/// <summary>
///   Dit is een subklasse van Account
/// </summary>
public class AcountNormaal : Account
{
    public AcountNormaal(int id_account, string accountnaam, string wachtwoord, string email)
        : base(id_account, accountnaam, wachtwoord, email)
    {
    }
}