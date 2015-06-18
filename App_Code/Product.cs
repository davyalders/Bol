using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Product
/// </summary>
public class Product
{
    public int Id_Product { get; set; }
    public string Naam { get; set; }
    public int Prijs { get; set; }
    public int Gewicht { get; set; }
    public string Beschrijving { get; set; }
    public Categorie Categorie { get; set; }



    public Product(int id_product, string naam, int prijs, int gewicht, string beschrijving, Categorie categorie)
	{
	    Id_Product = id_product;
	    Naam = naam;
	    Prijs = prijs;
	    Gewicht = gewicht;
	    Beschrijving = beschrijving;
	    Categorie = categorie;
	}

    public Product(int id_product)
    {
        
    }
    
    

}