using System;
using System.Collections.Generic;

namespace LanaKaraokeBar_DataBaseApi.Models;

public partial class Order
{
    public int Id { get; set; }

    public int IdBooking { get; set; }

    public decimal Cost { get; set; }

    public virtual Booking IdBookingNavigation { get; set; } = null!;

    public virtual ICollection<Productslist> Productslists { get; set; } = new List<Productslist>();
}
