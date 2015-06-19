using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.EnterpriseServices;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Oracle.DataAccess.Client;

public partial class MasterPage : System.Web.UI.MasterPage
{
    
    private DBC dbConnect;
    private Administratie administratie;
    
    public List<string> winkelwagens
    {
        get
        {
            return (List<string>)Session["WinkelwagenList"] ?? new List<string>();
        }
        set
        {
            Session["WinkelwagenList"] = value;
        }
    }


    protected void Page_Load(object sender, EventArgs e)
    {
        administratie = new Administratie();
        if (Session["Login"] != null)
        {
            Account.Visible = false;
            LoggedIn.Visible = true;
        }

        if (Session["Login"] == null)
        {
            Account.Visible = true;
            LoggedIn.Visible = false;
        }

        if (!this.IsPostBack)
        {
            this.GetMenuData();

            this.dbConnect = new DBC();
        }
        else
        {
           
            this.dbConnect = new DBC();
        } 
    }

    /// <summary>
    /// Laad het menu uit de database, zet het in een table en haal de data daar uit om een lijst mee te maken.
    /// </summary>
    private void GetMenuData()
    {
        DBC dbConnect = new DBC();
        dbConnect.Open();
        DataTable dt = new DataTable();
        string sql = "select * from categorie";
        OracleDataAdapter da = new OracleDataAdapter();
        da = dbConnect.OracleDA(sql);
        da.Fill(dt);
        DataView view = new DataView(dt);
        view.RowFilter = "TOPCATEGORIE_ID_PARENT is NULL";
        foreach (DataRowView row in view)
        {
            MenuItem menuItem = new MenuItem(row["Titel"].ToString(),
            row["ID_categorie"].ToString());

            Menu1.Items.Add(menuItem);
            AddChildItems(dt, menuItem);
        }
        dbConnect.Close();
    }
    /// <summary>
    /// Hier kijken we welke categorie bij welke parent hoort.
    /// </summary>
    /// <param name="table"> De table waar het in staat</param>
    /// <param name="menuItem"> het Item dat we gaan vergelijken</param>
    private void AddChildItems(DataTable table, MenuItem menuItem)
    {
        DataView viewItem = new DataView(table);
        viewItem.RowFilter = "TOPCATEGORIE_ID_PARENT=" + menuItem.Value;
        foreach (DataRowView childView in viewItem)
        {
            MenuItem childItem = new MenuItem(childView["Titel"].ToString(),
            childView["ID_Categorie"].ToString());
            childItem.NavigateUrl = childView["URL"].ToString();
            menuItem.ChildItems.Add(childItem);
            AddChildItems(table, childItem);
        }
    }

   /// <summary>
    /// Hier halen we de titel op van een product en zetten hem in een session, hierdoor kunnen we de data op een andere pagina gebruiken.
    /// </summary>
    /// <param name="naam"></param> We geven de naam van het product mee.
    public void GetTitel(string naam)
    {
        this.Session["Titel"] = dbConnect.GetTitel(naam);
    }

  
    /// <summary>
    /// Hier halen we de beschrijving op van een product en zetten hem in een session, hierdoor kunnen we de data op een andere pagina gebruiken. 
    /// </summary>
    /// <param name="naam"></param> We geven de naam van het product mee.
    public void GetBeschrijving(string naam)
    {
        this.Session["Beschrijving"] = dbConnect.GetBeschrijving(naam);
    }
    /// <summary>
    /// Hier halen we de prijs op van een product en zetten hem in een session, hierdoor kunnen we de data op een andere pagina gebruiken.
    /// </summary>
    /// <param name="naam"></param> We geven de naam van het product mee.
    public void GetPrijs(string naam)
    {
            this.Session["Prijs"] = dbConnect.GetPrijs(naam);

    }
    /// <summary>
    /// Hier halen we het aanbevolen product op en zetten hem in een session, hierdoor kunnen we de data op een andere pagina gebruiken.
    /// </summary>
    /// <param name="naam"></param> We geven de naam van het product mee.
    public void GetAanbevolen(string naam)
    {
        dbConnect = new DBC();
        this.Session["Titel2"] = dbConnect.GetAanbevolenTitel(naam);
        this.Session["Prijs2"] = dbConnect.GetAanbevolenPrijs(naam);
    }

 
    /// <summary>
    /// Wanneer de zoek knop wordt ingedrukt gaan we op zoek naar de bijbehorende pagina, we controleren welke het is en sturen het door naar de juiste pagina.
    /// </summary>

    protected void btnZoek_Click1(object sender, EventArgs e)
    {
        string naam = tbZoek.Text;
        this.GetTitel(naam);
        this.GetBeschrijving(naam);
        this.GetPrijs(naam);
        this.GetAanbevolen(naam);

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
    protected void btnLogout_Click(object sender, EventArgs e)
    {
        Session["Login"] = null;
        Response.Redirect("Default.aspx");
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        Response.Redirect("AddProduct.aspx");
    }

  
    protected void Menu1_MenuItemClick(object sender, MenuEventArgs e)
    {
        Session["Select"] = Menu1.SelectedItem.Text;
        Response.Redirect("Productlist.aspx");
    
    }
}
