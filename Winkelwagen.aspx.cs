using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Winkelwagen : System.Web.UI.Page
{
   
    protected void Page_Load(object sender, EventArgs e)
    {
        List<string> producten = (List<string>) Session["WinkelwagenList"];

        foreach (string product in producten)
        {
            lbProducten.Items.Add(product);
        }
    }
}