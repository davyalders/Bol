using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Login : System.Web.UI.Page
{
    /// <summary>
    /// Deze klasse wordt gebruikt om het inloggen te realiseren.
    /// </summary>
    protected void Page_Load(object sender, EventArgs e)
    {
        DBC dbConnect = new DBC();
    
        
        // test de database connectie
       if (dbConnect.CheckConnection())
        {
           Response.Write("database connection succesful");
        }
       else
       {
           Response.Write("database connection failed");
       }
    }

  /// <summary>
  /// Roept de login methode aan om in te loggen.
  /// </summary>
    protected void btnLogin_Click(object sender, EventArgs e)
    {
        LogIn();
    }
    /// <summary>
    /// Controleerd of de ingegeven boxes voldoen aan de validators, daarna wordt de username en password met elkaar vergeleken. 
    /// Wanneer dit klopt wordt er verwezen naar de homepage.
    /// </summary>
    protected void LogIn()
    {
        string password = "";
        DBC dbConnect = new DBC();
        if (IsValid)
        {
            if (tbUsername.Text != null)
            {
                dbConnect.Query("Select password from Account where gebruikersnaam='" + tbUsername.Text + "'");
            }
            dbConnect.Close();
            if (tbPassword.Text != null)
            {
                Session["Login"] = tbUsername.Text;
                Response.Redirect("Default.aspx");
            }
        }
    }
}