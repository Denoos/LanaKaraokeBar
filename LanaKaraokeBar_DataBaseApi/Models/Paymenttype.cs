using System;
using System.Collections.Generic;

namespace LanaKaraokeBar_DataBaseApi.Models;

public partial class Paymenttype
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public virtual ICollection<Sell> Sells { get; set; } = new List<Sell>();
}
