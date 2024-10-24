using Bogus;
using LocalFriendzApi.Application.Extensions;
using LocalFriendzApi.Core.Models;
using LocalFriendzApi.Core.Responses;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Testing;
using System.Net;
using System.Net.Http.Json;

namespace LocalFriendzApi.IntegrationTests
{
    public class ContactTests : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly WebApplicationFactory<Program> _factory;

        public ContactTests(WebApplicationFactory<Program> factory)
        {
            _factory = factory;
        }

        [Fact(DisplayName = "Criar um contato.")]
        [Trait("Tipo", "Integração")]
        [Trait("Funcionalidade", "Contatos")]
        public async Task Create_Contact_ShouldAssignId()
        {
            // Arrange
            var client = _factory.CreateClient();

            var faker = new Faker<Contact>()
                    .RuleFor(c => c.IdContact, f => Guid.NewGuid())
                    .RuleFor(c => c.Name, f => f.Person.FullName)
                    .RuleFor(c => c.Phone, f => f.GenerateBrazilianPhoneNumber())
                    .RuleFor(c => c.DDD, f => f.PickRandom(f.GetValidDDDs()))
                    .RuleFor(c => c.Email, f => f.Internet.Email());

            var newContactFake = faker.Generate(1).FirstOrDefault();

            // Act
            var response = await client.PostAsJsonAsync("/Contact/api/create-contact", newContactFake);

            // Assert
            response.EnsureSuccessStatusCode();
            Assert.Equal(HttpStatusCode.Created, response.StatusCode);
        }

        [Fact(DisplayName = "Obter todos os contatos.")]
        [Trait("Tipo", "Integração")]
        [Trait("Funcionalidade", "Contatos")]
        public async Task GetAll_ShouldReturnAllContacts()
        {
            // Arrange
            var client = _factory.CreateClient();

            // Act
            var response = await client.GetAsync("/Contact/api/list-all");

            // Assert
            response.EnsureSuccessStatusCode();
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            var listContacts = await response.Content.ReadFromJsonAsync<PagedResponse<List<Contact>>>();
            Assert.NotNull(listContacts.Data);
        }

        [Fact(DisplayName = "Filtrar o contato pelo email.")]
        [Trait("Tipo", "Integração")]
        [Trait("Funcionalidade", "Contatos")]
        public async Task FilterByParams_ShouldReturnCorrectContact()
        {
            // Arrange
            var client = _factory.CreateClient();
            var newContactFake = new Contact
            {
                Name = "José Alves",
                Email = "Jose_alves@gmail.com.br",
                Phone = "988882222",
                DDD = "11"
            };

            // Act
            var responseCreate = await CreateContactTest(newContactFake);
            var responseFilter = await client.GetAsync($"/Contact/api/list-by-filter?pageNumber=1&pageSize=25&email={newContactFake.Email}");
            var listContacts = await responseFilter.Content.ReadFromJsonAsync<PagedResponse<List<Contact>>>();
            var contact = listContacts.Data.FirstOrDefault();

            // Assert
            Assert.True(responseFilter.IsSuccessStatusCode);
            Assert.Equal(HttpStatusCode.OK, responseFilter.StatusCode);
            Assert.NotNull(contact);
            Assert.Equal(contact.Name, newContactFake.Name);
            Assert.Equal(contact.Email, newContactFake.Email);
            Assert.Equal(contact.Phone, newContactFake.Phone);
        }


        [Fact(DisplayName = "Atualiza um contato existente.")]
        [Trait("Tipo", "Integração")]
        [Trait("Funcionalidade", "Contatos")]
        public async Task Update_Contact_ShouldModifyExistingContact()
        {
            // Arrange
            var client = _factory.CreateClient();
            var newContactFake = new Contact
            {
                Name = "João",
                Email = "Joao_teste@gmail.com.br",
                Phone = "988886666",
                DDD = "11"
            };
            var responseCreate = await CreateContactTest(newContactFake);

            Contact contact = new();

            if (responseCreate.StatusCode == HttpStatusCode.BadRequest)
            {
                var getContact = await client.GetAsync($"/Contact/api/list-by-filter?pageNumber=1&pageSize=25&name={newContactFake.Name}");
                var listContacts = await getContact.Content.ReadFromJsonAsync<PagedResponse<List<Contact>>>();
                contact = listContacts.Data.FirstOrDefault();
            }
            else
            {
                var responseCreateData = await responseCreate.Content.ReadFromJsonAsync<Response<Contact>>();
                contact = responseCreateData.Data;
            }

            var updateContact = new Contact
            {
                IdContact = contact.IdContact,
                Email = contact.Email,
                Name = "João Silva",
                Phone = "97771111",
                DDD = "15"
            };

            // Act
            var response = await client.PutAsJsonAsync($"/Contact/api/update-contact?id={updateContact.IdContact}", updateContact);
            var updatedContact = await response.Content.ReadFromJsonAsync<Response<Contact>>();

            // Assert
            response.EnsureSuccessStatusCode();
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            Assert.NotNull(updatedContact);
            Assert.Equal(updateContact.Name, updatedContact.Data.Name);
            Assert.Equal(updateContact.Phone, updatedContact.Data.Phone);
            Assert.Equal(updateContact.DDD, updatedContact.Data.DDD);
        }

        [Fact(DisplayName = "Remover um contato existente.")]
        [Trait("Tipo", "Integração")]
        [Trait("Funcionalidade", "Contatos")]
        public async Task Delete_Contact_ShouldRemoveContact()
        {
            // Arrange
            var client = _factory.CreateClient();
            var newContactFake = new Contact
            {
                Name = "João",
                Email = "Joao_teste@gmail.com.br",
                Phone = "988886666",
                DDD = "11"
            };
            var responseCreate = await CreateContactTest(newContactFake);

            Contact contact = new();

            if (responseCreate.StatusCode == HttpStatusCode.BadRequest)
            {
                var getContact = await client.GetAsync($"/Contact/api/list-by-filter?pageNumber=1&pageSize=25&name={newContactFake.Name}");
                var listContacts = await getContact.Content.ReadFromJsonAsync<PagedResponse<List<Contact>>>();
                contact = listContacts.Data.FirstOrDefault();
            }
            else
            {
                var responseCreateData = await responseCreate.Content.ReadFromJsonAsync<Response<Contact>>();
                contact = responseCreateData.Data;
            }

            // Act
            var response = await client.DeleteAsync($"/Contact/api/delete-contact?Id={contact.IdContact}");

            // Assert
            response.EnsureSuccessStatusCode();
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }


        /// <summary>
        /// Fixture para criar contatos
        /// </summary>
        /// <param name="contact"></param>
        /// <returns></returns>
        private async Task<HttpResponseMessage> CreateContactTest(Contact contact)
        {
            var client = _factory.CreateClient();
            return await client.PostAsJsonAsync("/Contact/api/create-contact", contact);
        }
    }

}
