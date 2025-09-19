using System;
using System.Collections.Generic;

namespace LanaKaraokeBar_DataBaseApi.Models;

public partial class Room
{
    public int Id { get; set; }

    public int IdStatus { get; set; }

    public int MaxPeopleCount { get; set; }

    public int IdRate { get; set; }

    public virtual ICollection<Booking> Bookings { get; set; } = new List<Booking>();

    public virtual Rate IdRateNavigation { get; set; } = null!;

    public virtual Status IdStatusNavigation { get; set; } = null!;
}
