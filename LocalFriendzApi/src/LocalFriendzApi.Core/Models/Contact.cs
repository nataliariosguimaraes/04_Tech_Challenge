using LocalFriendzApi.Core.Requests.Contact;

namespace LocalFriendzApi.Core.Models
{
    public class Contact
    {
        public Guid IdContact { get; set; }
        public string? Name { get; set; }
        public string? Phone { get; set; }
        public string? DDD { get; set; }
        public string? Email { get; set; }

        public static Contact RequestMapper(CreateContactRequest request)
        {

            return new Contact()
            {
                IdContact = Guid.NewGuid(),
                Name = request.Name,
                Phone = request.Phone,
                DDD = request.DDD,
                Email = request.Email
            };
        }
    }
}
