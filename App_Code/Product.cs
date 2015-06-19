/// <summary>
///     Hier houden we de product data bij.
/// </summary>
public class Product
{
    public Product()
    {
   
    }

    public Product(int id_product)
    {
    }

    public int Id_Product { get; set; }
    public string Naam { get; set; }
    public int Prijs { get; set; }
    public int Gewicht { get; set; }
    public string Beschrijving { get; set; }
    public Categorie Categorie { get; set; }

    public override string ToString()
    {
        return Naam;
    }
}