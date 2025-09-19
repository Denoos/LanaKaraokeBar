using System;
using System.Collections.Generic;

namespace LanaKaraokeBar_DataBaseApi.Models;

public partial class Productslist
{
    public int IdOrder { get; set; }

    public int IdProduct { get; set; }

    public int ProductCount { get; set; }

    public virtual Order IdOrderNavigation { get; set; } = null!;

    public virtual Product IdProductNavigation { get; set; } = null!;
}
