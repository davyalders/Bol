using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.ServiceModel.Security.Tokens;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Oracle.DataAccess.Client;

/// <summary>
/// Dit is de klasse om de database connectie op te zetten, wanneer deze klasse word aangeroepen kan er gebruikt worden gemaakt van de local database.
/// </summary>
public class DBC
{

    private OracleConnection conn;
    private String user = "System";
    private String pw = "klabnupac098";
    
    
	public DBC()
	{
	    
        conn = new OracleConnection();
        conn.ConnectionString = "User Id=" + user + ";Password=" + pw + ";Data Source= " +
                                "//localhost:1521/xe" + ";";
        CheckConnection();
	}
    /// <summary>
    /// Hier controleren we of de connectie werkt
    /// </summary>
    /// Wanneer de connectie lukt, returned de methode true, anders false.
    public bool CheckConnection()
    {
        try
        {
            conn.Open();

            conn.Close();
        }
        catch
        {
            
            return false;

        }
        return true;
    }
    /// <summary>
    /// Deze methode is gemaakt als wrapper voor een SQL Query, dit voorkomt het vaak typen van deze code.
    /// </summary>
    /// <param name="q"></param> De Q variabele is een SQL command als string.
    /// <returns></returns> De methode geeft DataReader terug, deze kan dan worden uitgelezen in de methode die hem aanroept.
    public OracleDataReader Query(String q)
    {
        try
        {
            OracleCommand command = new OracleCommand(q, conn);
            conn.Open();
            return command.ExecuteReader();
        }
        catch (Exception e)
        {
          
            return null;
        }
        

    }
    /// <summary>
    /// Deze methode is gemaakt als wrapper voor SQL commands niet iets opvragen, maar een verandering maken aan de database. 
    /// Het verschil met de bovenstaande is dat deze dus niets teruggeeft.
    /// </summary>
    /// <param name="q"></param> De Q variabele is een SQL command als string.
    public void NonQuery(String q)
    {

        try
        {
            OracleCommand command = new OracleCommand(q, conn);
            conn.Open();
            command.ExecuteNonQuery();
            conn.Close();
        }
        catch (Exception e)
        {
     
        }
        finally
        {
            conn.Close();
        }
    }
    /// <summary>
    /// Opent de connectie met de database.
    /// </summary>
    public void Open()
    {
        conn.Open();
    }
    /// <summary>
    /// Sluit de connectie met de database
    /// </summary>
    public void Close()
    {
        conn.Close();
    }
    /// <summary>
    /// Word waarschijnlijk niet gebruikt, het is een methode om een Adapter te krijgen in plaats van een reader.
    /// Dit is een work in progress.
    /// </summary>
    /// <param name="q"></param>De Q variabele is een SQL command als string.
    /// <returns></returns> Geeft een dataAdapter terug.
    public OracleDataAdapter OracleDA(string q)
    {
        OracleDataAdapter da = new OracleDataAdapter(q, conn);
        return da;
    }
    /// <summary>
    /// Deze methode wordt gebruikt om een parameter toe te voegen zonder elke keer de code te hoeven typen.
    /// </summary>
    public static OracleParameter AddParameter(string parameterName, object value, OracleDbType dbType, int size)
    {
        OracleParameter param = new OracleParameter();
        param.ParameterName = parameterName;
        param.Value = value.ToString();
        param.OracleDbType = dbType;
        param.Size = size;
        param.Direction = ParameterDirection.Input;
        return param;

    }
    /// <summary>
    /// Dit is een methode om een connectie te maken met de database, en daarna een stored procedure aan te roepen.
    ///  De connectie moet worden aangemaakt omdat het een static methode is.
    /// </summary>
    public static DataTable ExecuteDTByProcedure(string procedurename, OracleParameter[] param)
    {
        String user = "System";
        String pw = "klabnupac098";
        OracleConnection conn = new OracleConnection("User Id=" + user + ";Password=" + pw + ";Data Source= " +
                                "//localhost:1521/xe" + ";");
        OracleCommand cmd = new OracleCommand();
        cmd.Connection = conn;
        cmd.CommandText = procedurename;
        cmd.Parameters.AddRange(param);
        cmd.CommandType = CommandType.StoredProcedure;
        OracleDataAdapter adapter = new OracleDataAdapter(cmd);
        DataTable dtTable = new DataTable();

        try
        {
            adapter.Fill(dtTable);
        }
        catch (Exception)
        {

            throw;
        }
        finally
        {
            adapter.Dispose();
            cmd.Parameters.Clear();
            cmd.Dispose();
            conn.Dispose();
        }
        return dtTable;


    }
    /// <summary>
    /// Controleerd de gegevens inde database
    /// </summary>
    /// <param name="Username">Gebruikersnaam</param>
    /// <param name="password">Wachtwoord</param>
    /// <returns> Return true wanneer de data klopt</returns>
    public bool LogIn(string Username, string password)
    {
        bool waar = false;
        string wachtwoord = string.Empty;
        try
        {
            OracleDataReader reader1 =
            Query("Select wachtwoord from Account where accountnaam='" + Username + "'");

            while (reader1.Read())
            {
                wachtwoord = Convert.ToString(reader1["wachtwoord"]);
            }
            if (password == wachtwoord)
            {
                waar = true;
            }
        }
        catch (Exception)
        {
            return false;
            
        }
      
        Close();
        return waar;
    }
    /// <summary>
    /// Haalt de titel op van meegegeven string
    /// </summary>
    /// <param name="naam"></param>
    /// <returns>Returned de titel</returns>
    public string GetTitel(string naam)
    {
        string titel = string.Empty;
       
        OracleDataReader reader1 = Query("Select * from Product where naam ='" + naam + "'");

        while (reader1.Read())
        {
            titel = Convert.ToString(reader1["Naam"]);
        }
        Close();
        return titel;
    }
    /// <summary>
    /// Haalt de beschrijving op van meegegeven string
    /// </summary>
    /// <param name="naam"></param>
    /// <returns>Returned de beschrijving</returns>
    public string GetBeschrijving(string naam)
    {
        string beschrijving = string.Empty;
        OracleDataReader reader1 = Query("Select * from Product where naam ='" + naam + "'");

        while (reader1.Read())
        {
           beschrijving =Convert.ToString(reader1["Beschrijving"]);
        }
       Close();
        return beschrijving;
    }

    /// <summary>
    /// Haalt de Prijs op van meegegeven string
    /// </summary>
    /// <param name="naam"></param>
    /// <returns>Returned de prijs</returns>
    public string GetPrijs(string naam)
    {
        string prijs = string.Empty;
        OracleDataReader reader1 = Query("Select * from Product where naam ='" + naam + "'");

        while (reader1.Read())
        {
            prijs = Convert.ToString(reader1["Prijs"]) + ",00";
        }
        Close();
        return prijs;
    }

    public string GetAanbevolenPrijs(string naam)
    {
        string id = string.Empty;
        string aanbevolenID = string.Empty;
        string prijs = string.Empty;
        string sql = "Select * from Product where naam ='" + naam + "'";
        OracleDataReader reader1 = Query(sql);

        while (reader1.Read())
        {
            id = Convert.ToString(reader1["ID_product"]);

        }
        Close();

        OracleDataReader reader2 = Query("Select * from Aanbevolen where ID_product1 ='" + id + "'");

        while (reader2.Read())
        {
            aanbevolenID = Convert.ToString(reader2["ID_product2"]);

        }
        Close();

        OracleDataReader reader3 = Query("Select * from Product where ID_product ='" + aanbevolenID + "'");

        while (reader3.Read())
        {
            prijs = Convert.ToString(reader3["Prijs"]) + ",00";
        }
       Close();
        return prijs;
    }

    public string GetAanbevolenTitel(string naam)
    {
        string id = string.Empty;
        string aanbevolenID = string.Empty;
        string titel = string.Empty;
        string sql = "Select * from Product where naam ='" + naam + "'";
        OracleDataReader reader1 = Query(sql);

        while (reader1.Read())
        {
            id = Convert.ToString(reader1["ID_product"]);

        }
        Close();

        OracleDataReader reader2 = Query("Select * from Aanbevolen where ID_product1 ='" + id + "'");

        while (reader2.Read())
        {
            aanbevolenID = Convert.ToString(reader2["ID_product2"]);

        }
        Close();

        OracleDataReader reader3 = Query("Select * from Product where ID_product ='" + aanbevolenID + "'");

        while (reader3.Read())
        {
            titel = Convert.ToString(reader3["Naam"]);
        }
        Close();
        return titel;
    }
    /// <summary>
    /// Voegt een nieuwe account toe aan de database
    /// </summary>
    /// <param name="username"> Gebruikersnaam</param>
    /// <param name="password">Wachtwoord</param>
    /// <param name="email">Email</param>
     public void NewAccount(string username, string password, string email)
    {
       
        int id = 0;
         string Username = username;
         string Password = password;
         string Email = email;
     
            OracleDataReader reader1 =Query("select MAX(id_account)as id from account");

            while (reader1.Read())
            {
                id = Convert.ToInt32(reader1["id"]);
            }
            Close();
            id++;
            string sql = "insert into account values ('" + id + "','" + Username + "','" + Password + "','" + Email + "')";
            NonQuery(sql);
        
    }
    /// <summary>
    /// Voegt een product toe aan de database
    /// </summary>
    /// <param name="naam">De naam van het product</param>
    /// <param name="prijs">De prijs van het product</param>
    /// <param name="gewicht"> Het gewicht van het product</param>
    /// <param name="beschrijving"> De beschrijving van het product</param>
    /// <param name="categorie"> De categorie van het product</param>
     public void AddProduct(string naam, int prijs, int gewicht, string beschrijving, string categorie)
     {
         int id = 0;
         int PCid = 0;
         int catID = 0;
         OracleDataReader reader1 = Query("select MAX(id_product)as id from product");
         while (reader1.Read())
         {
             id = Convert.ToInt32(reader1["id"]);
         }
         Close();
         id++;
         string sql = "insert into product values ('" + id + "','" + naam + "','" + prijs + "','" + gewicht + "','"+beschrijving+"')";
         NonQuery(sql);

         string cat = categorie;
         OracleDataReader reader2 = Query("select MAX(id_productcategorie)as id from productcategorie");
          while (reader2.Read())
         {
             PCid = Convert.ToInt32(reader2["id"]);
         }
         Close();
         OracleDataReader reader3 = Query("select id_categorie as id from categorie where titel ='"+ cat + "'");
          while (reader3.Read())
         {
             catID = Convert.ToInt32(reader3["id"]);
         }
         Close();
         PCid++;
         catID++;
         string sql2 = "insert into productcategorie values ('" + PCid + "','" + catID + "','" + id + "')";
         NonQuery(sql2);
     }
    /// <summary>
    /// Haal de lijst met hoofdcategorien op.
    /// </summary>
    /// <returns>Returned de opgehaalde lijst.</returns>
    public List<Categorie> GetCategories()
    {
        List<Categorie> cat = new List<Categorie>();
        string sql = "select titel from categorie where TOPCATEGORIE_ID_PARENT is null and id_categorie != 110";
        OracleDataReader reader1 = Query(sql);
        while (reader1.Read())
        {
            Categorie catt = new Categorie();
            catt.Titel = Convert.ToString(reader1["titel"]);
            cat.Add(catt);
        }
        Close();
        return cat;
    }
    /// <summary>
    /// Haalt de producten die bij een categorie horen op
    /// </summary>
    /// <param name="categorie"> De gewenste categorie</param>
    /// <returns>Geeft een lijst van producten</returns>
    public List<Product> GetProductsCategorie(string categorie)
    {
        List<Product> products = new List<Product>();
        int idproduct = 0;
        int idcat = 0;
        string sql3 = "select id_categorie from categorie where titel ='" + categorie + "'";
        OracleDataReader reader3 = Query(sql3);
        while (reader3.Read())
        {
            idcat = Convert.ToInt32(reader3["id_categorie"]);
        }
        Close();

        string sql2 = "select id_product from productcategorie where id_categorie = '" + idcat + "'";
        OracleDataReader reader2 = Query(sql2);
        while (reader2.Read())
        {
            idproduct = Convert.ToInt32(reader2["id_product"]);
        }
        Close();

        string sql =
            "select product.id_product, product.naam, product.prijs, product.gewichtkg, product.beschrijving from product where product.id_product = '" + idproduct + "'";
        OracleDataReader reader1 = Query(sql);
        while (reader1.Read())
        {
            Product pro = new Product();
            pro.Id_Product = Convert.ToInt32(reader1["id_product"]);
            pro.Naam = Convert.ToString(reader1["naam"]);
            pro.Gewicht = Convert.ToInt32(reader1["gewichtkg"]);
            pro.Beschrijving = Convert.ToString(reader1["beschrijving"]);
            products.Add(pro);
        }
        Close();
        return products;
    }
    
}
