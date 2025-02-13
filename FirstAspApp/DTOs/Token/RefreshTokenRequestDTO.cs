namespace FirstAspApp.DTOs.Token
{
    public class RefreshTokenRequestDTO
    {
        public int UserId { get; set; }
        public required string RefreshToken { get; set; }
    }
}
