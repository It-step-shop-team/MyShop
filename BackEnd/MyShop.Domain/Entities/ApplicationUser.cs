namespace MyShop.Domain.Entities
{
    public class ApplicationUser
    {
        public required Guid Id { get; set; }
        public required string Login { get; set; }
        public required string PasswordHash { get; set; }
        public required string Email { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public required string PhoneNumber { get; set; }
        public string? Address { get; set; }
        public required DateTime CreatedDate { get; set; }
        public DateTime? LastLoginDate { get; set; }
    }
}
