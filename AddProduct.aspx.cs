using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AddProduct : System.Web.UI.Page
{
    private Administratie administratie;
    /// <summary>
    /// Wanneer de pagina wordt geladen vullen we de dropdown list
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Page_Load(object sender, EventArgs e)
    {
       
        administratie = new Administratie();
        administratie.GetCategories();
        DropDownList1.Items.Clear();
        foreach (Categorie cat in administratie.CategorieList)
        {
            DropDownList1.Items.Add(Convert.ToString(cat.Titel));
        }
        
    }


    /// <summary>
    /// Hier wanneer je op de knop drukt ga je een product aan de database toeveoegen
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Button1_Click(object sender, EventArgs e)
    {
        if (IsValid)
        {
            int prijs = Convert.ToInt32(tbPrijs.Text);
            int gewicht = Convert.ToInt32(tbGewicht.Text);
            string cat = DropDownList1.SelectedValue;
            Administratie administratie = new Administratie();

            administratie.AddProduct(tbProductNaam.Text, prijs, gewicht, tbBeschrijving.Text, cat);
        }
    }
}