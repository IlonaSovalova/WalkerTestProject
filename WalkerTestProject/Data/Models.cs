namespace WalkerAdAppTest;

/// <summary>
/// ContactInfo (same as used by API).
/// </summary>
public class ContactInfo {
	public int id {get; set;}
	public string firstName {get; set;}
	public string lastName {get; set;}
	public string phone {get; set;}
	public string email {get; set;}
	public string state {get; set;}
	public string reason {get; set;}
}

public class TestData {
	/// <summary>
	/// Used by tests.
	/// </summary>
	public static readonly ContactInfo MyContact = new ContactInfo {
		id = 0,
		firstName = "Winnie",
		lastName = "Pooh",
		phone = "515-555-7890",
		email = "Winnie.the.Pooh@gmail.uk",
		state = "IA",
		reason = "I'm just a little black rain cloud, hovering under the honey tree."
	};
}
