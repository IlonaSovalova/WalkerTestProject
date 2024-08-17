using Microsoft.Playwright;

namespace WalkerAdAppTest;

/// <summary>
/// POM.
/// Common fields, properties, methods etc for all pages.
/// </summary>
public class BasePage {
	readonly IPage _Page;

	public IPage Page => _Page;

	public BasePage(IPage page) {
		_Page = page;
	}

	#region Locators
	public ILocator Greeting => Page.GetByText("Contact Info", new PageGetByTextOptions{ Exact = true });
	public ILocator Copyright => Page.GetByText("Walker Advertising LLC. All Rights Reserved");
	#endregion
}
