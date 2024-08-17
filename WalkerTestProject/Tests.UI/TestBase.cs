using Microsoft.Playwright;

namespace WalkerAdAppTest;

/// <summary>
/// Common fields, properties, methods etc for all tests.
/// </summary>
public class TestBase: PageTest {
	public override BrowserNewContextOptions ContextOptions() {
		return new BrowserNewContextOptions(){
			Locale = "en-US",
			ColorScheme = ColorScheme.Light,
			ViewportSize = new ViewportSize(){ Width = 1920, Height = 1080 },
		};
	}
}
