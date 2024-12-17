
using RadinikMAUIDemo.Views;

namespace RadinikMAUIDemo
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            RegisterRouting();
        }

        private void RegisterRouting()
        {
            Routing.RegisterRoute(nameof(CallsPage), typeof(CallsPage));
        }
    }
}
