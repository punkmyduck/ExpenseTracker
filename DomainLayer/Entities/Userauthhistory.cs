using System;
using System.Collections.Generic;

namespace ExpenseTracker.DomainLayer.Entities;

public partial class Userauthhistory
{
    public long Authid { get; set; }

    public DateTime Date { get; set; }

    public bool Issuccessful { get; set; }

    public string? Ipaddress { get; set; }

    public int Userid { get; set; }

    public virtual User User { get; set; } = null!;
}
