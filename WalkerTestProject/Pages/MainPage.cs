using Microsoft.Playwright;

namespace WalkerAdAppTest;

/// <summary>
/// POM.
/// Main app page.
/// </summary>
public class MainPage: BasePage {
	/// <summary>
	/// Page URL.
	/// </summary>
	public string Url { get; } = "https://automationtestwaui.azurewebsites.net/";

	/// <summary>
	/// Public constructor.
	/// </summary>
	public MainPage(IPage page): base(page) {
	}

	#region Locators
	public ILocator FirstName => Page.GetByPlaceholder("Enter First Name..."); // NOTE: that will be a problem if app is localized
	public ILocator LastName => Page.GetByPlaceholder("Enter Last Name...");
	public ILocator Email => Page.GetByPlaceholder("Enter Email...");
	public ILocator Phone => Page.Locator("xpath=//input[@formcontrolname='phone']"); // NOTE: alternative to placeholder
	public ILocator State => Page.GetByPlaceholder("Enter State...");
	public ILocator Reason => Page.GetByPlaceholder("Enter Reason...");
	public ILocator Submit => Page.GetByRole(AriaRole.Button).Filter(new LocatorFilterOptions {HasTextString = "Submit"});
	public ILocator ResonError => Page.GetByText("Reason Required");
    public ILocator DeleteLink => Page.Locator("a", new PageLocatorOptions { HasTextString = "Delete" });

    #endregion

    #region Actions
    /// <summary>
    /// Opens the page.
    /// </summary>
    public async Task Open() {
		await Page.GotoAsync("https://automationtestwaui.azurewebsites.net/");
	}
	#endregion
}
