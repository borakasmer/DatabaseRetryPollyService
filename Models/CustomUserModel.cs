namespace LinqToDBBlog.Models
{
    public partial class CustomUserModel
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Gsm { get; set; }
        public bool? IsAdmin { get; set; }
        public string SecurityRoleName { get; set; }
        public int? IdSecurityRole { get; set; }
        public int IdUser { get; set; }
        public DateTime CreDate { get; set; }
    }
}
