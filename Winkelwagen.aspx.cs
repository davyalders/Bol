using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Oracle.DataAccess.Client;

public partial class Winkelwagen : System.Web.UI.Page
{
   
    protected void Page_Load(object sender, EventArgs e)
    {
        int productprijs = 0;
        int prijs = 0;
        List<string> producten = (List<string>) Session["WinkelwagenList"];

        if (producten != null)
        {
            foreach (string product in producten)
            {
                lbProducten.Items.Add(product);
            }

            foreach (string product in producten)
            {

                DBC dbconnect = new DBC();
                OracleDataReader reader1 = dbconnect.Query("select prijs from product where naam ='" + product + "'");
                while (reader1.Read())
                {
                    productprijs = Convert.ToInt32(reader1["prijs"]);
                }
                prijs = + productprijs;
                dbconnect.Close();
            }
            lbTotaal.Text = Convert.ToString(prijs);
        }
    }
}