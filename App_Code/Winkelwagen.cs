using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Oracle.DataAccess.Client;

/// <summary>
/// Dit is een klasse die wordt gebruike om de winkelwagendata op te slaan of op te halen
/// </summary>
public class Winkelwagen
{
    public List<string> winkelwagens = new List<string>();

    DBC dbconnect = new DBC();


    public Winkelwagen()
    {

    }

    public List<string> GetWinkelwagens()
    {
       
       return winkelwagens;
      
    }
    /// <summary>
    /// Vind de ID  van de winkelwagen die bij de meegegeven account hoort.
    /// </summary>
    /// <param name="id"></param> ID van de meegegeven account.
    /// <returns></returns>
    public string FindWinkelwagen(string id)
    {
        string winkelwagenId = "";
        OracleDataReader reader2 = dbconnect.Query("select * from winkelwagen where id_account = '"+ id + "'");
        while (reader2.Read())
        {
            winkelwagenId = Convert.ToString(reader2["id_winkelwagen"]);
        }
        return winkelwagenId;       
    }
    /// <summary>
    /// Voegt een product toe aan de winkelwagen.
    /// </summary>
    /// <param name="product"></param> Het product dat toegevoegd moet worden.
    public void AddToWinkelwagen(string product)
    {
        winkelwagens.Add(product);
    }

}