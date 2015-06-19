using System;

/// <summary>
///    Hier houden we de data van een bestelling bij.
/// </summary>
public class Bestelling
{
    public Bestelling(DateTime leverdatum, bool bezorgmanier)
    {
        Leverdatum = leverdatum;
        Bezorgmanier = bezorgmanier;
    }

    public DateTime Leverdatum { get; set; }
    public bool Bezorgmanier { get; set; }
}