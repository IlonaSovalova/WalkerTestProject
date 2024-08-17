namespace WalkerAdAppTest;

[Parallelizable(ParallelScope.Self)]
[TestFixture]
public class MainPageTests: TestBase {
	[Test]
	public async Task MainPage_Opens() {
		var mainPage = new MainPage(Page);

		await mainPage.Open();

		await Expect(mainPage.Greeting).ToBeVisibleAsync();
		await Expect(mainPage.Copyright).ToBeVisibleAsync();
	}

	[Test]
	public async Task Test1_MainPage_AllRequiredPresent() {
		var mainPage = new MainPage(Page);
		await mainPage.Open();

		// fill in the form
		await mainPage.FirstName.FillAsync(TestData.MyContact.firstName);
		await mainPage.LastName.FillAsync(TestData.MyContact.firstName);
		await mainPage.Email.FillAsync(TestData.MyContact.email);
		await mainPage.Phone.FillAsync(TestData.MyContact.phone);
		await mainPage.State.FillAsync(TestData.MyContact.state);
		await mainPage.Reason.FillAsync(TestData.MyContact.reason);
		// submit
		await mainPage.Submit.ClickAsync();

        // assertion
        var submitConfirmationPage = new SubmitConfirmationPage(Page);
		await Expect(submitConfirmationPage.EditYourInfo).ToBeVisibleAsync();
		await Expect(submitConfirmationPage.SubmissionResult).ToBeVisibleAsync();

		System.Threading.Thread.Sleep(3000);
	}

    [Test]
    public async Task Test2_MainPage_ReasonOmitted()
    {
        var mainPage = new MainPage(Page);
        await mainPage.Open();

        // fill in the form
        await mainPage.FirstName.FillAsync(TestData.MyContact.firstName);
        await mainPage.LastName.FillAsync(TestData.MyContact.firstName);
        await mainPage.Email.FillAsync(TestData.MyContact.email);
        await mainPage.Phone.FillAsync(TestData.MyContact.phone);
        await mainPage.State.FillAsync(TestData.MyContact.state);
         // submit
        await mainPage.Submit.ClickAsync();

		// assertion
		await Expect(mainPage.Submit).ToBeVisibleAsync();
		await Expect(mainPage.ResonError).ToBeVisibleAsync();

        System.Threading.Thread.Sleep(3000);
    }

    [Test]
	public async Task Test3_MainPage_Edit() {
		var mainPage = new MainPage(Page);
		await mainPage.Open();

		// add new
		await mainPage.FirstName.FillAsync(TestData.MyContact.firstName);
		await mainPage.LastName.FillAsync(TestData.MyContact.firstName);
		await mainPage.Email.FillAsync(TestData.MyContact.email);
		await mainPage.Phone.FillAsync(TestData.MyContact.phone);
		await mainPage.State.FillAsync(TestData.MyContact.state);
		await mainPage.Reason.FillAsync(TestData.MyContact.reason);
		await mainPage.Submit.ClickAsync();
		// check the result
		var submitConfirmationPage = new SubmitConfirmationPage(Page);
		await Expect(submitConfirmationPage.EditYourInfo).ToBeVisibleAsync();
		await Expect(submitConfirmationPage.SubmissionResult).ToBeVisibleAsync();

		// edit a bit
		await submitConfirmationPage.EditYourInfo.ClickAsync();
		System.Threading.Thread.Sleep(3000);
		await mainPage.FirstName.FillAsync("VV");
		await mainPage.LastName.FillAsync("PuTin");
		await mainPage.Reason.FillAsync("I don't want go to Hague.");
		await mainPage.Submit.ClickAsync();

        // assertion
        await Expect(submitConfirmationPage.EditSuccess).ToBeVisibleAsync();

		System.Threading.Thread.Sleep(5000);
	}
}
