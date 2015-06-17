using System;
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
    private Winkelwagen winkelwagen;


    protected void Page_Load(object sender, EventArgs e)
    {
        winkelwagen = new Winkelwagen();
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
    /// <summary>
    /// Hier halen we de titel op van een product en zetten hem in een session, hierdoor kunnen we de data op een andere pagina gebruiken.
    /// </summary>
    /// <param name="naam"></param> We geven de naam van het product mee.
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
  
    /// <summary>
    /// Hier halen we de beschrijving op van een product en zetten hem in een session, hierdoor kunnen we de data op een andere pagina gebruiken. 
    /// </summary>
    /// <param name="naam"></param> We geven de naam van het product mee.
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
    /// <summary>
    /// Hier halen we de prijs op van een product en zetten hem in een session, hierdoor kunnen we de data op een andere pagina gebruiken.
    /// </summary>
    /// <param name="naam"></param> We geven de naam van het product mee.
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
    /// <summary>
    /// Hier halen we het aanbevolen product op en zetten hem in een session, hierdoor kunnen we de data op een andere pagina gebruiken.
    /// </summary>
    /// <param name="naam"></param> We geven de naam van het product mee.
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

 
    /// <summary>
    /// Wanneer de zoek knop wordt ingedrukt gaan we op zoek naar de bijbehorende pagina, we controleren welke het is en sturen het door naar de juiste pagina.
    /// </summary>

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
    protected void menuBar_MenuItemClick(object sender, MenuEventArgs e)
    {

    }
    /// <summary>
    /// Haalt de data van winkelwagen op uit de klasse winkelwagen en geeft hem door aan de web page.
    /// </summary>
    /// <returns></returns> Geeft een lijst terug van poducten als string.
    public void GetWinkelWagen()
    {
        try
        {
            
            Session["WinkelwagenList"] = winkelwagen.winkelwagens;

        }
        catch (Exception)
        {       
          Response.Write("Winkelwagen is leeg");
      
        }
        
    }
    /// <summary>
    /// Geeft aan de winkelwagan klasse door welk product moet worden toegevoegd aan de lijst.
    /// </summary>
    /// <param name="product"></param> Het product dat moet worden toegevoegd.
    public void AddToWinkelwagen(string product)
    {
        List<string> winkelwagens = new List<string>();
        winkelwagens.Add(product);
        Session["WinkelwagenList"] = winkelwagens;
    }
}
