using System;
using System.Collections.Generic;

namespace Lesson.Models.Database;

public partial class UserDetail
{
    public int UserDetailId { get; set; }

    public int UserId { get; set; }

    public string Name { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Address { get; set; } = null!;

    public DateTime DateCreated { get; set; }

    public DateTime? DateModified { get; set; }
}
