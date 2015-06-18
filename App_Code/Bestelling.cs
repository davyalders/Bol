using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Bestelling
/// </summary>
public class Bestelling
{
    public DateTime Leverdatum { get; set; }
    public bool Bezorgmanier { get; set; }

	public Bestelling(DateTime leverdatum, bool bezorgmanier)
	{
	    Leverdatum = leverdatum;
	    Bezorgmanier = bezorgmanier;
	}
}