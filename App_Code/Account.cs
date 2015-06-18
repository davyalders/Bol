using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Account
/// </summary>
abstract public class Account 
{
   
    public int Id_Account { get; set; }
    public string Accountnaam { get; set; }
    public string Wachtwoord { get; set; }
    public string Email { get; set; }

	public Account(int id_account, string accountnaam, string wachtwoord, string email)
	{
	    Id_Account = id_account;
	    Accountnaam = accountnaam;
	    Wachtwoord = wachtwoord;
	    Email = email;
	}


}