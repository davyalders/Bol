using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Oracle.DataAccess.Client;

public partial class Register : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    /// <summary>
    /// Hiermaken we een nieuwe account aan in de databse als de boxes die ingevult moeten worden zijn gevalideerd.
    /// </summary>
    protected void NewAccount()
    {
        DBC dbConnect = new DBC();
        int id = 0;
        string username = tbUsername.Text;
        string password = tbPassword.Text;
        string email = tbEmail.Text;
        if (IsValid)
        {
           OracleDataReader reader1 = dbConnect.Query("select MAX(id_account)as id from account");

            while (reader1.Read())
            {
                id = Convert.ToInt32(reader1["id"]);
            }
            dbConnect.Close();
            id++;
            string sql = "insert into account values ('"+ id + "','"+username+"','"+ password+"','"+email+"')";
            dbConnect.NonQuery(sql);
        }
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