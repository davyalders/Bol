using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class VforVendetta : System.Web.UI.Page
{
    /// <summary>
    /// Hier laadt ik de Sessions die nodig zijn om de pagina te vullen met de juiste informatie uit de database.
    /// </summary>
    protected void Page_Load(object sender, EventArgs e)
    {
      
        MasterPage master = (MasterPage)this.Master;
        master.GetAanbevolen("V for Vendetta");
        master.GetBeschrijving("V for Vendetta");
        master.GetPrijs("V for Vendetta");
        master.GetTitel("V for Vendetta");
       
       
        lbTitel.Text = (string)Session["Titel"];
        lbBeschrijving.Text = (string)Session["Beschrijving"];
        lbPrijs.Text = "€ " + (string)Session["Prijs"];
        lbAanbevolenTitel.Text = "Aanbevolen bij " + (string)Session["Titel"] + ": ";
        lbAanbevolenPrijs.Text = (string)Session["Titel2"] + " € " + (string)Session["Prijs2"];
    }
    protected void btnAddToCart_Click(object sender, EventArgs e)
    {
        MasterPage master = (MasterPage)this.Master;
        master.AddToWinkelwagen((string)Session["Titel"]);
    }
}