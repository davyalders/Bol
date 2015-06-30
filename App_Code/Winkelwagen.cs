using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Oracle.DataAccess.Client;

/// <summary>
/// Dit is een klasse die wordt gebruikt om de winkelwagendata op te slaan of op te halen
/// </summary>
public class Winkelwagen
{
    private object _items;

    public List<Winkelwagenitem> Items { get; private set; }


    // Static constructor
    public  static Winkelwagen GetShoppingCart()
    {
        
        // Als de cart nog niet in de sessie zit, maak er een aan.
        if (HttpContext.Current.Session["ASPNETShoppingCart"] == null)
        {
            Winkelwagen cart = new Winkelwagen();
            cart.Items = new List<Winkelwagenitem>();
            HttpContext.Current.Session["ASPNETShoppingCart"] = cart;
        }

        return (Winkelwagen)HttpContext.Current.Session["ASPNETShoppingCart"];
    }

    /// <summary>
    /// Voeg een item toe aan de winkelwagen
    /// </summary>
    /// <param name="productId">ID van het product</param>
    /// <param name="naam">Productnaam</param>
    /// <param name="prijs">Productprijs</param>
    /// <param name="gewicht">Gewicht in kg</param>
    /// <param name="beschrijving">Beschrijving van het product</param>
    /// <param name="categorie">Categorie van het product</param>
    public void AddItem(int productId)
    {
        // Maak een nieuw product om in de winkelwagen te stoppen
        Winkelwagenitem newItem = new Winkelwagenitem(productId);

        // Als dit item al bestaat in de lijst, verhoog dan de Quantitiy
        // Zo niet, voeg het dan toe aan de lijst.
        if (Items.Contains(newItem))
        {
            foreach (Winkelwagenitem item in Items)
            {
                if (item.Equals(newItem))
                {
                    item.Quantity++;
                    return;
                }
            }
        }
        else
        {
            newItem.Quantity = 1;
            Items.Add(newItem);
        }
    }

    /// <summary>
    /// Zet de quantiteit van een item
    /// </summary>
    /// <param name="productId"> ID van het product</param>
    /// <param name="quantity"> De quantiteit</param>
    public void SetItemQuantity(int productId,int quantity)
    {
        // Als de quantity naar 0 gaat, verwijder het dan.
        if (quantity == 0)
        {
            RemoveItem(productId);
            return;
        }

        // Vind en update de quantiteit
        Winkelwagenitem updatedItem = new Winkelwagenitem(productId);

        foreach (Winkelwagenitem item in Items)
        {
            if (item.Equals(updatedItem))
            {
                item.Quantity = quantity;
                return;
            }
        }
    }
    /// <summary>
    /// Verwijder een item
    /// </summary>
    /// <param name="productId"> Id van het product</param>
    public void RemoveItem(int productId) {
        Winkelwagenitem removedItem = new Winkelwagenitem(productId);
        Items.Remove(removedItem);
    
    }
    /// <summary>
    /// Tel de prijs op
    /// </summary>
    /// <returns>Geeft het subtotaal terug</returns>
    public decimal GetSubTotal()
    {
        decimal subTotal = 0;
        foreach (Winkelwagenitem item in Items)
            subTotal += item.TotalPrice;

        return subTotal;
    }
}