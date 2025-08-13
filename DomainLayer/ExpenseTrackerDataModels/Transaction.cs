using System;
using System.Collections.Generic;

namespace ExpenseTracker.DomainLayer.ExpenseTrackerDataModels;

public partial class Transaction
{
    public long Transactionid { get; set; }

    public char Type { get; set; }

    public decimal Amount { get; set; }

    public DateTime Date { get; set; }

    public string? Commentary { get; set; }

    public int Categoryid { get; set; }

    public int Userid { get; set; }

    public virtual Category Category { get; set; } = null!;

    public virtual User User { get; set; } = null!;

    public virtual ICollection<Report> Reports { get; set; } = new List<Report>();
}
