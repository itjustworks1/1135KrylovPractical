using System;
using System.Collections.Generic;

namespace _1135KrylovPracticalAPI.DB;

public partial class Employee
{
    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string Position { get; set; } = null!;

    public int Id { get; set; }

    public DateTime HireDate { get; set; }

    public bool IsActive { get; set; }

    public virtual ICollection<Credential> Credentials { get; set; } = new List<Credential>();

    public virtual ICollection<Shift> Shifts { get; set; } = new List<Shift>();
}
