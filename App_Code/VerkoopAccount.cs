/// <summary>
///     Dit is een subklasse van Account
/// </summary>
public class VerkoopAccount : Account
{
    public VerkoopAccount(int id_account, string accountnaam, string wachtwoord, string email, int rekeningnummer,
        int telefoonnummer)
        : base(id_account, accountnaam, wachtwoord, email)
    {
        Rekeningnummer = rekeningnummer;
        Telefoonnummer = telefoonnummer;
    }

    public int Rekeningnummer { get; set; }
    public int Telefoonnummer { get; set; }
}