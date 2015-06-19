using System.Collections.Generic;
using System.Web;

/// <summary>
///  Hier worden de meeste methodes gekoppeld.
/// </summary>
public class Administratie
{
    private readonly DBC dbConnect = new DBC();
    public List<Categorie> CategorieList = new List<Categorie>();
    public List<Product> Products = new List<Product>(); 
    /// <summary>
    /// Hier geef je door aan de database klasse dat je een account wil toevoegen.
    /// </summary>
    /// <param name="username"> Gebruukersnaam</param>
    /// <param name="password"> wachtwoord</param>
    /// <param name="email"> email </param>
    public void AddAccount(string username, string password, string email)
    {
        dbConnect.NewAccount(username, password, email);
    }
    /// <summary>
    /// Hier geef je door daan de database klasse dat je een product wil toevoegen.
    /// </summary>
    /// <param name="naam"> naam van het product</param>
    /// <param name="prijs"> prijs van het product</param>
    /// <param name="gewicht"> geicht van het product in kg</param>
    /// <param name="beschrijving"> beschrijving van het product</param>
    /// <param name="categorie"> de categorie waar het product bij hoort</param>
    public void AddProduct(string naam, int prijs, int gewicht, string beschrijving, string categorie)
    {
        dbConnect.AddProduct(naam, prijs, gewicht, beschrijving, categorie);
    }
    /// <summary>
    /// Hier geef je door aan de database klasse dat je de categorien wilt ophalen.
    /// </summary>
    public void GetCategories()
    {
        CategorieList = dbConnect.GetCategories();      
    }
    /// <summary>
    /// Hier geef je door aan de datgabase klasse dat je de producten op wilt halen die bij een categorie horen.
    /// </summary>
    /// <param name="categorie"></param>
    public void GetProducten( string categorie)
    {
        Products = dbConnect.GetProductsCategorie(categorie);
        
    }
}