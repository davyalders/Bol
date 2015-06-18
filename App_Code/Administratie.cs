using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Administratie
/// </summary>
public class Administratie
{
    private DBC dbConnect = new DBC();
	public Administratie()
	{
		
	}

    public void AddAccount(string username, string password, string email)
    {
        dbConnect.NewAccount(username, password, email);
    }
}