using NUnit.Framework;
using Newtonsoft.Json;

namespace backend_test
{
    [TestFixture]
    public class Tests
    {
        public HttpClient _client;
        [SetUp]
        public void Setup()
        {
            _client = new TestClientProvider().Client;
        }

        [Test]
        public async Task Get()
        {
            var response = await _client.GetAsync("/api/user");
            response.EnsureSuccessStatusCode();
            List<backend_crud.User> users = JsonConvert.DeserializeObject<List<backend_crud.User>>(await response.Content.ReadAsStringAsync());
            Assert.That(users.Any(p => p.Name == "Eda" && p.Surname == "Altuntaş"));
        }

        [Test]
        public async Task Post()
        {
            var u = new
            {
                name = "Eda",
                surname = "Altuntaş",
                gender = 0,
                birth_date = "1999-01-01"
            };
            var response = await _client.PostAsJsonAsync("/api/user", u);
            response.EnsureSuccessStatusCode();
            backend_crud.User user = JsonConvert.DeserializeObject<backend_crud.User>(await response.Content.ReadAsStringAsync());
            Assert.AreEqual(u.name, user.Name);
            Assert.AreEqual(u.surname, user.Surname);
            Assert.AreEqual(u.gender, user.Gender);
        }
    }
}