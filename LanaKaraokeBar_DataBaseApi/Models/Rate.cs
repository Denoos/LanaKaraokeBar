using System;
using System.Collections.Generic;

namespace LanaKaraokeBar_DataBaseApi.Models;

public partial class Rate
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public double CostCoefficient { get; set; }

    public virtual ICollection<Room> Rooms { get; set; } = new List<Room>();
}
