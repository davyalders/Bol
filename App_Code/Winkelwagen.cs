using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Oracle.DataAccess.Client;

/// <summary>
/// Dit is een klasse die wordt gebruike om de winkelwagendata op te slaan of op te halen
/// </summary>
public class Winkelwagen
{
    public int WinkelwagenId { get; set; }

    public Winkelwagen(int id)
    {
        WinkelwagenId = id;
    }

  
}