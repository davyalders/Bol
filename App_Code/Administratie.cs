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
    DBC dbConnect = new DBC();
    public List<Categorie> CategorieList = new List<Categorie>(); 
	public Administratie()
	{
		
	}

    public void AddAccount(string username, string password, string email)
    {
        dbConnect.NewAccount(username, password, email);
    }

    public void AddProduct(string naam, int prijs, int gewicht, string beschrijving, string categorie)
    {
        dbConnect.AddProduct(naam, prijs, gewicht,beschrijving,categorie);
    }

    public List<Categorie> GetCategories()
    {
        CategorieList = dbConnect.GetCategories();
       return CategorieList;
    }
    
}