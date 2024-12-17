using RadinikMAUIDemo.ViewModels;

namespace RadinikMAUIDemo.Views;

public partial class CallsPage : ContentPage
{
	public CallsPage(CallsPageViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
    }
}