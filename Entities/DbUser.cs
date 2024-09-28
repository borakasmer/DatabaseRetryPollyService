using System;
using System.Collections.Generic;

namespace LinqToDBBlog.Entities;

public partial class DbUser
{
    public int IdUser { get; set; }

    public int? IdSecurityRole { get; set; }

    public string? Name { get; set; }

    public string? LastName { get; set; }

    public string? UserName { get; set; }

    public string? Password { get; set; }

    public string? PasswordHash { get; set; }

    public string? Email { get; set; }

    public string? Gsm { get; set; }

    public long? TotalCompanyNumber { get; set; }

    public bool IsDeleted { get; set; }

    public bool? IsAdmin { get; set; }

    public int? CreUser { get; set; }

    public DateTime CreDate { get; set; }

    public int? ModUser { get; set; }

    public DateTime? ModDate { get; set; }

    public string? Client { get; set; }

    public string? ClientIp { get; set; }

    public bool Deleted { get; set; }

    public bool? IsRoleLock { get; set; }

    public virtual ICollection<DbSecurityUserAction> DbSecurityUserAction { get; set; } = new List<DbSecurityUserAction>();

    public virtual DbSecurityRole? IdSecurityRoleNavigation { get; set; }

    public virtual ICollection<UserSwagger> UserSwagger { get; set; } = new List<UserSwagger>();
}
