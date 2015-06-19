using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Productlist : System.Web.UI.Page
{
    private Administratie administratie;

    protected void Page_Load(object sender, EventArgs e)
    {
        administratie = new Administratie();
        string text = Convert.ToString(Session["Select"]);
        administratie.GetProducten(text);
        lbProducts.Items.Clear();
        foreach (Product pro in administratie.Products)
        {
            lbProducts.Items.Add(pro.ToString());
        }
    }
}