using System;
using System.Collections.Generic;

namespace ExpenseTracker.DomainLayer.Entities;

public partial class Report
{
    public int Reportid { get; set; }

    public DateTime Startdate { get; set; }

    public DateTime Finishdate { get; set; }

    public decimal Totalsum { get; set; }

    public int Userid { get; set; }

    public virtual User User { get; set; } = null!;

    public virtual ICollection<Transaction> Transactions { get; set; } = new List<Transaction>();
}
