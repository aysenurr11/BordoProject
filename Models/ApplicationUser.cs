namespace BordoProject.Models
{
    public class ApplicationUser
    {
        internal string UserName;

        public int Id { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public bool IsAdmin { get; set; } // Admin olup olmadığını belirten bir flag
    }
}
