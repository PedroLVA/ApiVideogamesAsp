namespace FirstAspApp.Models
{
    public class User
    {
        public int Id { get; set; }

        public  string UserName { get; set; } = string.Empty;

        public  string Email { get; set; } = string.Empty;

        public  string PasswordHash { get; set; } = string.Empty;

        public string Role { get; set; } = string.Empty;

        public string? RefreshToken { get; set; }

        public DateTime? RefreshTokenExpiryTime { get; set; }

        public List<Review>? Reviews { get; set; }  


    }
}
