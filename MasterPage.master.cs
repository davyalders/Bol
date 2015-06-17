﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.EnterpriseServices;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Oracle.DataAccess.Client;

public partial class MasterPage : System.Web.UI.MasterPage
{
    
    private DBC dbConnect;


    protected void Page_Load(object sender, EventArgs e)
    {
        dbConnect = new DBC();
        getMenu();
    }
    /// <summary>
    /// Methode om dynamisch een menu op te halen
    /// Eerst gaan we de database in, halen we een categorie tabel op en zetten we deze in een datarow.
    /// Hierna lezen we deze datarow uit en zetten we de items in de Menubar.
    /// WERKT OP DIT MOMENT NIET
    /// </summary>
    private void getMenu()
    {
        
        dbConnect.Open();
        DataSet ds = new DataSet();
        DataTable dt = new DataTable();
        string sql = "select * from categorie";
        OracleDataAdapter da = new OracleDataAdapter();
        da = dbConnect.OracleDA(sql);
        da.Fill(ds);
        dt = ds.Tables[0];
        DataRow[] drowpar = dt.Select("TOPCATEGORIE_ID_PARENT=null");

        foreach (DataRow dr in drowpar)
        {
            menuBar.Items.Add(new MenuItem(dr["Titel"].ToString()   ));
                 
        }
     
        dbConnect.Close();

    }

    public void GetTitel(string naam)
    {

        DBC dbConnect = new DBC();
        OracleDataReader reader1 = dbConnect.Query("Select * from Product where naam ='" + naam + "'");

        while (reader1.Read())
        {
            Session["Titel"] = Convert.ToString(reader1["Naam"]);
     
        }
        dbConnect.Close();
    }
  

    public void GetBeschrijving( string naam)
    {
        DBC dbConnect = new DBC();
        OracleDataReader reader1 = dbConnect.Query("Select * from Product where naam ='" + naam + "'");

        while (reader1.Read())
        {
             Session["Beschrijving"] = Convert.ToString(reader1["Beschrijving"]);

        }
        dbConnect.Close();
    }

    public void GetPrijs(string naam)
    {
        DBC dbConnect = new DBC();
        OracleDataReader reader1 = dbConnect.Query("Select * from Product where naam ='" + naam + "'");

        while (reader1.Read())
        {
            Session["Prijs"] = Convert.ToString(reader1["Prijs"]) + ",00";

        }
        dbConnect.Close();
    }

    public void GetAanbevolen(string naam)
    {
        DBC dbConnect = new DBC();
        string id = "";
        string aanbevolenID = "";
        string sql = "Select * from Product where naam ='" + naam + "'";
        OracleDataReader reader1 = dbConnect.Query(sql);

        while (reader1.Read())
        {
           id = Convert.ToString(reader1["ID_product"]);

        }
        dbConnect.Close();

        OracleDataReader reader2 = dbConnect.Query("Select * from Aanbevolen where ID_product1 ='" + id + "'");

        while (reader2.Read())
        {
            aanbevolenID = Convert.ToString(reader2["ID_product2"]);

        }
        dbConnect.Close();

        OracleDataReader reader3 = dbConnect.Query("Select * from Product where ID_product ='" + aanbevolenID + "'");

        while (reader3.Read())
        {
            Session["Titel2"] = Convert.ToString(reader3["Naam"]);
            Session["Prijs2"] = Convert.ToString(reader3["Prijs"]) + ",00";
        }
        dbConnect.Close();
    }

    public void AddToWinkelwagen(string naam)
    {
        DBC dbConnect = new DBC();
        string sql = "Select * from Product where naam ='" + naam + "'";
        OracleDataReader reader1 = dbConnect.Query(sql);

        while (reader1.Read())
        {
            Session["AddProductWinkelwagen"] = Convert.ToString(reader1["naam"]);

        }
        dbConnect.Close();
    }
    protected void btnZoek_Click1(object sender, EventArgs e)
    {
         string naam = tbZoek.Text;
        GetTitel(naam);
        GetBeschrijving(naam);
        GetPrijs(naam);
        GetAanbevolen(naam);
        if ((string)Session["Titel"] == "Harry potter : The Goblet of Fire")
        {
            Response.Redirect("GobletOfFire.aspx");
        }
        if ((string)Session["Titel"] == "V for Vendetta")
        {
            Response.Redirect("VforVendetta.aspx");
        }
    
    }
}
