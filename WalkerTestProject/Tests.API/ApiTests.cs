using RestSharp;
using System.Text.Json;
using Microsoft.Playwright;
using System.Net.Http.Json;

namespace WalkerAdAppTest;

[TestFixture]
public class TestGitHubAPI : PlaywrightTest {
	private readonly string _BaseUrl = "https://automationtestwaapi.azurewebsites.net";


	[Test]
	public async Task TestAPI_GetAll() {
		var request = new RestRequest("api/Consumer", Method.Get);
		var client = new RestClient(new Uri(_BaseUrl));
		var contacts = await client.GetAsync<ContactInfo[]>(request);
		Assert.IsNotNull(contacts);
		Assert.IsTrue(contacts.Length >= 0);
	}

	[Test]
	public async Task TestAPI_AllMethods() {
		var client = new RestClient(new Uri(_BaseUrl));
		// add new (POST)
		int newID = 0;
		{
			var request = new RestRequest("api/Consumer", Method.Post);
			request.AddJsonBody(TestData.MyContact);
			var response = await client.PostAsync(request);
			Assert.IsTrue(response.IsSuccessStatusCode);
			var newContact = JsonSerializer.Deserialize<ContactInfo>(response.Content);
			newID = newContact.id;
			Console.WriteLine($"New item added, ID={newID}");
		}

		// get by ID (GET ID)
		{
			var request = new RestRequest("api/Consumer/consumer/" + newID, Method.Get);
			var response = await client.GetAsync(request);
			Assert.IsTrue(response.IsSuccessStatusCode);
			var contact = JsonSerializer.Deserialize<ContactInfo>(response.Content);
			Assert.IsNotNull(contact);
			Assert.AreEqual(newID, contact.id);
		}

		// update (PUT)
		{
			var contact = new ContactInfo(){
				id = newID,
				firstName = "VV",
				lastName = "PuTin",
				phone = "+7-916-666-6666",
				email = "vova@bunker.ru",
				state = "RU",
				reason = "I don't want go to Hague."
			};
			var request = new RestRequest("api/Consumer", Method.Put);
			request.AddJsonBody(contact);
			var response = await client.PutAsync(request);
			Assert.IsTrue(response.IsSuccessStatusCode);
			Console.WriteLine($"New item updated, ID={newID}");
		}

		// delete (DELETE)
		{
			var deleteRequest = new RestRequest("api/Consumer/" + newID, Method.Delete);
			var response = await client.DeleteAsync(deleteRequest);
			Assert.IsTrue(response.IsSuccessStatusCode);
			Console.WriteLine($"Item deleted, ID={newID}");
		}
	}

    [Test]
    public async Task TestAPI_DeleteAllWinnie() {
        var request = new RestRequest("api/Consumer", Method.Get);
        var client = new RestClient(new Uri(_BaseUrl));
        var contacts = await client.GetAsync<ContactInfo[]>(request);
        Assert.IsNotNull(contacts);
        int count = 0;
        foreach (var c in contacts)
        {
            if (c.email == "Winnie.the.Pooh@gmail.uk")
            {
                Console.WriteLine($"Deleting item with ID={c.id}");
                int id = c.id;
                var deleteRequest = new RestRequest("api/Consumer/" + id, Method.Delete);
                var response = await client.DeleteAsync(deleteRequest);
                Assert.IsTrue(response.IsSuccessStatusCode);
                count++;
            }
        }
        Console.WriteLine($"Deleted {count} items.");
    }
}
