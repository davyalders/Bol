/// <summary>
///    Deze klasse houdt de account data bij.
/// </summary>
public abstract class Account
{
    public Account(int id_account, string accountnaam, string wachtwoord, string email)
    {
        Id_Account = id_account;
        Accountnaam = accountnaam;
        Wachtwoord = wachtwoord;
        Email = email;
    }

    public int Id_Account { get; set; }
    public string Accountnaam { get; set; }
    public string Wachtwoord { get; set; }
    public string Email { get; set; }
}

