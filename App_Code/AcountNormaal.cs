using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for AcountNormaal
/// </summary>
public class AcountNormaal : Account
{
    public AcountNormaal(int id_account, string accountnaam, string wachtwoord, string email) : base (id_account,accountnaam,wachtwoord,email)
	{
		
	}
}