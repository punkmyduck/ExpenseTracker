using System;
using System.Collections.Generic;

namespace ExpenseTracker.DomainLayer.ExpenseTrackerDataModels;

public partial class Userauthdatum
{
    public int Userid { get; set; }

    public string Passwordhash { get; set; } = null!;

    public string Salt { get; set; } = null!;

    public string? Refreshtoken { get; set; }

    public DateTime? Rtendsat { get; set; }

    public virtual User User { get; set; } = null!;
}
