using LocalFriendzApi.Core.Models;
using LocalFriendzApi.Core.Requests.Contact;
using LocalFriendzApi.Core.Responses;

namespace LocalFriendzApi.Application.IServices
{
    public interface IContactServices
    {
        Task<Response<Contact?>> CreateAsync(CreateContactRequest request);
        Task<PagedResponse<List<Contact>?>> GetAll(GetAllContactRequest request);
        Task<PagedResponse<List<Contact>?>> GetByFilter(GetByParamsRequest request);
        Task<Response<Contact?>> GetById(Guid id);
        Task<Response<Contact?>> PutContact(Guid id, UpdateContactRequest request);
        Task<Response<Contact?>> DeleteContact(Guid id);
        IEnumerable<Contact> ContactGenerator(int numberOfContacts);
    }
}
