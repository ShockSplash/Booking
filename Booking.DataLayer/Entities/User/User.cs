namespace Booking.DataLayer.Entities.User
{
    public class User : BaseEntity
    {
        public string Email { get; init; }

        public string FullName { get; init; }

        public string Login { get; init; }

        public string Password { get; init; }

        public Sex Sex { get; init; }
    }
}