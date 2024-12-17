
using RadinikMAUIDemo.ViewModels;

namespace RadinikMAUIDemo

{
    public partial class MainPage : ContentPage
    {
        public MainPage(MainPageViewModel vm)
        {
            InitializeComponent();
            BindingContext = vm;
        }
    }
}
