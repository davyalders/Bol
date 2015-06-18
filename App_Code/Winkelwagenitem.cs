﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Winkelwagenitem
/// </summary>
public class Winkelwagenitem
{
    public int Quantity { get; set; }
    private int _productId;

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
    private Product _product = null;
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
        get { return UnitPrice * Quantity; }
    }
    public Winkelwagenitem(int productId)
	{
        this.ProductId = productId;
	}
}