namespace MyShop.Domain.Entities
{
    /// <summary>
    /// Represents an application user with authentication and profile details.
    /// </summary>
    public class ApplicationUser
    {
        /// <summary>
        /// Unique identifier of the user.
        /// </summary>
        public required Guid Id { get; set; }

        /// <summary>
        /// User's login name.
        /// </summary>
        public required string Login { get; set; }

        /// <summary>
        /// Hashed password of the user.
        /// </summary>
        public required string PasswordHash { get; set; }

        /// <summary>
        /// Email address of the user.
        /// </summary>
        public required string Email { get; set; }

        /// <summary>
        /// First name of the user (optional).
        /// </summary>
        public string? FirstName { get; set; }

        /// <summary>
        /// Last name of the user (optional).
        /// </summary>
        public string? LastName { get; set; }

        /// <summary>
        /// Phone number of the user.
        /// </summary>
        public required string PhoneNumber { get; set; }

        /// <summary>
        /// Address of the user (optional).
        /// </summary>
        public string? Address { get; set; }

        /// <summary>
        /// Date and time when the user was created.
        /// </summary>
        public required DateTime CreatedDate { get; set; }

        /// <summary>
        /// Date and time of the user's last login (optional).
        /// </summary>
        public DateTime? LastLoginDate { get; set; }
    }
}
