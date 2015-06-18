using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

/// <summary>
/// Deze klasse wordt gebruikt om het inloggen te realiseren.
/// </summary>
public partial class Login : System.Web.UI.Page
{
    private DBC dbConnect;
    protected void Page_Load(object sender, EventArgs e)
    {
        dbConnect = new DBC();
    }

    /// <summary>
/// Roept de login methode aan om in te loggen.
/// </summary>
/// <param name="sender">parameter s</param>
/// <param name="e">parameter e</param>
    protected void btnLogin_Click(object sender, EventArgs e)
    {
        this.LogIn();
    }

    /// <summary>
    /// Controleert of de  boxes voldoen aan de validators, daarna wordt de username en password met elkaar vergeleken. 
    /// Wanneer dit klopt wordt er verwezen naar de homepage.
    /// </summary> 
    protected void LogIn()
    {
        if (this.IsValid)
        {   
            string username = tbUsername.Text;
            string password = tbPassword.Text;
            dbConnect.LogIn(username, password);
            if (dbConnect.LogIn(username, password))
            {
                this.Session["Login"] = tbUsername.Text;
                Response.Redirect("Default.aspx");

                if (Session["Login"] != null)
                {
                    Response.Write("Login succesful");
                }
            }
        }
    }
}