using System;
using System.Collections.Generic;

namespace LanaKaraokeBar_DataBaseApi.Models;

public partial class Booking
{
    public int Id { get; set; }

    public DateTime TimeStamp { get; set; }

    public int HoursCount { get; set; }

    public int IdRate { get; set; }

    public int IdRoom { get; set; }

    public int IdUser { get; set; }

    public virtual Room IdRoomNavigation { get; set; } = null!;

    public virtual User IdUserNavigation { get; set; } = null!;

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

    public virtual ICollection<Sell> Sells { get; set; } = new List<Sell>();
}
