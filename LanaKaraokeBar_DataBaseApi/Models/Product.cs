using System;
using System.Collections.Generic;

namespace LanaKaraokeBar_DataBaseApi.Models;

public partial class Product
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public decimal Cost { get; set; }

    public virtual ICollection<Productslist> Productslists { get; set; } = new List<Productslist>();
}
