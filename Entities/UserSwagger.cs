using System;
using System.Collections.Generic;

namespace LinqToDBBlog.Entities;

public partial class UserSwagger
{
    public int Id { get; set; }

    public int? UrlId { get; set; }

    public int IdUser { get; set; }

    public int IdSwagger { get; set; }

    public DateTime CreDate { get; set; }

    public bool IsDeleted { get; set; }

    public virtual DbUser IdUserNavigation { get; set; } = null!;
}
