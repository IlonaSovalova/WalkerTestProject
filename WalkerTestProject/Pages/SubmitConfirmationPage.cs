using Microsoft.Playwright;

namespace WalkerAdAppTest;

/// <summary>
/// POM.
/// Page shown after sumbission.
/// </summary>
public class SubmitConfirmationPage: BasePage {
	/// <summary>
	/// Public constructor.
	/// </summary>
	public SubmitConfirmationPage(IPage page): base(page) {
	}

	#region Locators
	public ILocator SubmissionResult => Page.GetByText("Submission Successful!");
	public ILocator EditYourInfo => Page.Locator("a", new PageLocatorOptions{HasTextString = "here"});
	public ILocator EditSuccess => Page.GetByText("Edit Successful!");
    public ILocator DeleteSuccess => Page.GetByText("Delete Successful!");
    #endregion
}
