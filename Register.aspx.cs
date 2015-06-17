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
    protected void btnRegister_Click(object sender, EventArgs e)
    {
        NewAccount();
    }
}