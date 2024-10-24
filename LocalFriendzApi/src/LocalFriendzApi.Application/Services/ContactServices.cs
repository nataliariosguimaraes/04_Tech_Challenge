using Bogus;
using LocalFriendzApi.Application.Extensions;
using LocalFriendzApi.Application.IServices;
using LocalFriendzApi.Core.IRepositories;
using LocalFriendzApi.Core.Models;
using LocalFriendzApi.Core.Requests.Contact;
using LocalFriendzApi.Core.Responses;

namespace LocalFriendzApi.Application.Services
{
    public class ContactServices : IContactServices
    {
        private readonly IContactRepository _contactRepository;

        public ContactServices(IContactRepository contactRepository)
        {
            _contactRepository = contactRepository;
        }

        public async Task<Response<Contact?>> CreateAsync(CreateContactRequest request)
        {
            var contact = Contact.RequestMapper(request);
            var response = await _contactRepository.Create(contact);

            return response;
        }
        public async Task<PagedResponse<List<Contact>?>> GetAll(GetAllContactRequest request)
        {
            var response = await _contactRepository.GetAll(request);
            return response;
        }

        public async Task<Response<Contact?>> PutContact(Guid id, UpdateContactRequest request)
        {
            var response = await _contactRepository.Update(id, request);
            return response;
        }

        public async Task<Response<Contact?>> DeleteContact(Guid id)
        {
            var response = await _contactRepository.Delete(id);
            return response;
        }

        public async Task<PagedResponse<List<Contact>?>> GetByFilter(GetByParamsRequest request)
        {
            var response = await _contactRepository.GetContactByFilter(request);
            return response;
        }

        public async Task<Response<Contact?>> GetById(Guid id)
        {
            return await _contactRepository.GetById(id);
        }

        public IEnumerable<Contact> ContactGenerator(int numberOfContacts)
        {
            var faker = new Faker<Contact>()
                .RuleFor(c => c.IdContact, f => Guid.NewGuid())
                .RuleFor(c => c.Name, f => f.Person.FullName)
                .RuleFor(c => c.Phone, f => f.GenerateBrazilianPhoneNumber())
                .RuleFor(c => c.DDD, f => f.PickRandom(f.GetValidDDDs()))
                .RuleFor(c => c.Email, f => f.Internet.Email());

            return faker.Generate(numberOfContacts);
        }
    }
}
