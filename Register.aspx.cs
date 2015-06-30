using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Oracle.DataAccess.Client;

public partial class Register : System.Web.UI.Page
{
    private Administratie Administratie;
    protected void Page_Load(object sender, EventArgs e)
    {
        
    }

    /// <summary>
    /// Hiermaken we een nieuwe account aan in de databse als de boxes die ingevult moeten worden zijn gevalideerd.
    /// </summary>
    private void NewAccount()
    {
        Administratie.AddAccount(tbUsername.Text,tbPassword.Text,tbEmail.Text);
    }

    /// <summary>
    /// Hier roepen we de methode aan om de account toe te voegen aan de database.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnRegister_Click(object sender, EventArgs e)
    {
        NewAccount();
    }
}