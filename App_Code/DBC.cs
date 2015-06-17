using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Oracle.DataAccess.Client;

/// <summary>
/// Summary description for DBC
/// </summary>
public class DBC
{
    public string Titel { get; set; }
    public string Beschrijving { get; set; }
    public string Prijs { get; set; }
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

    public void Open()
    {
        conn.Open();
    }

    public void Close()
    {
        conn.Close();
    }

    public OracleDataAdapter OracleDA(string q)
    {
        OracleDataAdapter da = new OracleDataAdapter(q, conn);
        return da;
    }
}