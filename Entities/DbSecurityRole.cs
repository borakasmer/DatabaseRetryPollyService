using System;
using System.Collections.Generic;

namespace LinqToDBBlog.Entities;

public partial class DbSecurityRole
{
    public int IdSecurityRole { get; set; }

    public string SecurityRoleName { get; set; } = null!;

    public int? CreUser { get; set; }

    public DateTime CreDate { get; set; }

    public int? ModUser { get; set; }

    public DateTime? ModDate { get; set; }

    public string? Client { get; set; }

    public string? ClientIp { get; set; }

    public bool Deleted { get; set; }

    public virtual ICollection<DbSecurityUserRole> DbSecurityUserRole { get; set; } = new List<DbSecurityUserRole>();

    public virtual ICollection<DbUser> DbUser { get; set; } = new List<DbUser>();

    public virtual ICollection<DbUser2> DbUser2 { get; set; } = new List<DbUser2>();

    public virtual ICollection<DbUser2017> DbUser2017 { get; set; } = new List<DbUser2017>();

    public virtual ICollection<DbUser2018> DbUser2018 { get; set; } = new List<DbUser2018>();

    public virtual ICollection<DbUser2019> DbUser2019 { get; set; } = new List<DbUser2019>();
}
