using System;
using System.Collections.Generic;

namespace Lesson.Models.Database;

public partial class User
{
    public int UserId { get; set; }

    public string UserName { get; set; } = null!;

    public string Password { get; set; } = null!;

    public bool IsActive { get; set; }

    public DateTime DateCreated { get; set; }

    public DateTime? DateModified { get; set; }
}
