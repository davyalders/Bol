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


    // The static constructor is called as soon as the class is loaded into memory 
    public  static Winkelwagen GetShoppingCart()
    {
        // If the cart is not in the session, create one and put it there
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


    public void SetItemQuantity(int productId,int quantity)
    {
        // If we are setting the quantity to 0, remove the item entirely
        if (quantity == 0)
        {
            RemoveItem(productId);
            return;
        }

        // Find the item and update the quantity
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

    public void RemoveItem(int productId) {
        Winkelwagenitem removedItem = new Winkelwagenitem(productId);
        Items.Remove(removedItem);
    
    }

    public decimal GetSubTotal()
    {
        decimal subTotal = 0;
        foreach (Winkelwagenitem item in Items)
            subTotal += item.TotalPrice;

        return subTotal;
    }
}