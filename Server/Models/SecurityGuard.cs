using System;
using System.Collections.Generic;

namespace Chop.Models;

public partial class SecurityGuard
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Password { get; set; }

    public string? Adress { get; set; }
}
