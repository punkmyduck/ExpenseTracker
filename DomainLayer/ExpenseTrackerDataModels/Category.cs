using System;
using System.Collections.Generic;

namespace ExpenseTracker.DomainLayer.ExpenseTrackerDataModels;

public partial class Category
{
    public int Categoryid { get; set; }

    public string Categoryname { get; set; } = null!;

    public char Categorytype { get; set; }

    public int? Userid { get; set; }

    public virtual ICollection<Transaction> Transactions { get; set; } = new List<Transaction>();

    public virtual User? User { get; set; }
}
