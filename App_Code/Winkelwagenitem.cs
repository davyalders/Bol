/// <summary>
///     Hier maken we items om in de winkelwagen te stoppen
/// </summary>
public class Winkelwagenitem
{
    private Product _product;
    private int _productId;

    public Winkelwagenitem(int productId)
    {
        ProductId = productId;
    }

    public int Quantity { get; set; }

    public int ProductId
    {
        get { return _productId; }
        set
        {
            // Om zeker te weten dat het opnieuw wordt gemaakt
            _product = null;
            _productId = value;
        }
    }

    public Product Prod
    {
        get
        {
            // Product wordt alleen gemaakt wanneer het nodig is
            if (_product == null)
            {
                _product = new Product(ProductId);
            }
            return _product;
        }
    }

    public string Description
    {
        get { return Prod.Beschrijving; }
    }

    public decimal UnitPrice
    {
        get { return Prod.Prijs; }
    }

    public decimal TotalPrice
    {
        get { return UnitPrice*Quantity; }
    }
}