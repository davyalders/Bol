﻿using System;
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
}