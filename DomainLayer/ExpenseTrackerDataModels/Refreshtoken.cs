using System;
using System.Collections.Generic;

namespace ExpenseTracker.DomainLayer.ExpenseTrackerDataModels;

public partial class Refreshtoken
{
    public int Tokenid { get; set; }

    public string Token { get; set; } = null!;

    public DateTime? Createat { get; set; }

    public DateTime? Expiresat { get; set; }

    public DateTime? Revokedat { get; set; }

    public string? Replacedbytoken { get; set; }

    public int Userid { get; set; }

    public virtual User User { get; set; } = null!;
}
