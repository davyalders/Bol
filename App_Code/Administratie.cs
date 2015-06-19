﻿using System.Collections.Generic;
using System.Web;

/// <summary>
///     Summary description for Administratie
/// </summary>
public class Administratie
{
    private readonly DBC dbConnect = new DBC();
    public List<Categorie> CategorieList = new List<Categorie>();
    public List<Product> Products = new List<Product>(); 

    public void AddAccount(string username, string password, string email)
    {
        dbConnect.NewAccount(username, password, email);
    }

    public void AddProduct(string naam, int prijs, int gewicht, string beschrijving, string categorie)
    {
        dbConnect.AddProduct(naam, prijs, gewicht, beschrijving, categorie);
    }

    public void GetCategories()
    {
        CategorieList = dbConnect.GetCategories();
        
    }

    public void GetProducten( string categorie)
    {
        Products = dbConnect.GetProductsCategorie(categorie);
        
    }
}