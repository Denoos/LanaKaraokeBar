using System;
using System.Collections.Generic;

namespace LanaKaraokeBar_DataBaseApi.Models;

public partial class Sell
{
    public int Id { get; set; }

    public int IdBooking { get; set; }

    public DateTime TimeStamp { get; set; }

    public decimal Amount { get; set; }

    public int IdPaymenttype { get; set; }

    public virtual Booking IdBookingNavigation { get; set; } = null!;

    public virtual Paymenttype IdPaymenttypeNavigation { get; set; } = null!;
}
