using LinqToDB;
using LinqToDB.EntityFrameworkCore;
using LinqToDBBlog.Entities;
using LinqToDBBlog.Entities.DbContexts;
using LinqToDBBlog.Models;
using LinqToDBBlog.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LinqToDBBlog.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LinqToDbController : ControllerBase
    {
        private readonly DashboardContext _context;
        private readonly IDatabaseRetryService _databaseRetryService;
        public LinqToDbController(DashboardContext context, IDatabaseRetryService databaseRetryService)
        {
            _context = context;
            _databaseRetryService = databaseRetryService;
        }

        [HttpGet("GetUserList")]
        public List<CustomUserModel> Get()
        {
            var users = from user in _context.DbUser
                        join role in _context.DbSecurityRole on user.IdSecurityRole equals role.IdSecurityRole into roleLeft
                        from role in roleLeft.DefaultIfEmpty()
                        select new CustomUserModel
                        {
                            Name = user.Name,
                            LastName = user.LastName,
                            UserName = user.UserName,
                            Password = user.Password,
                            Email = user.Email,
                            Gsm = user.Gsm,
                            IsAdmin = user.IsAdmin,
                            SecurityRoleName = role.SecurityRoleName,
                            IdSecurityRole = role.IdSecurityRole,
                            IdUser = user.IdUser,
                            CreDate = user.CreDate
                        };
            return _databaseRetryService.ExecuteWithRetry(() =>
            {
                return users.ToList();
            });
        }
        [HttpGet("GetUserListFromTableName/{tableName}")]
        public async Task<List<CustomUserModel>> GetFromTableName(string tableName)
        {
            var users = from user in _context.Set<DbUser>().ToLinqToDBTable().TableName(tableName)
                        join role in _context.DbSecurityRole on user.IdSecurityRole equals role.IdSecurityRole into roleLeft
                        from role in roleLeft.DefaultIfEmpty()
                        where user.Deleted != true
                        select new CustomUserModel
                        {
                            Name = user.Name,
                            LastName = user.LastName,
                            UserName = user.UserName,
                            Password = user.Password,
                            Email = user.Email,
                            Gsm = user.Gsm,
                            IsAdmin = user.IsAdmin,
                            SecurityRoleName = role.SecurityRoleName,
                            IdSecurityRole = role.IdSecurityRole,
                            IdUser = user.IdUser,
                            CreDate = user.CreDate
                        };
            return await _databaseRetryService.ExecuteWithRetryAsync(async () =>
            {
                return await LinqToDB.AsyncExtensions.ToListAsync(users);
            });
        }       
    }
}
