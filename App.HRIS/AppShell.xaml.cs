using App.HRIS.Views;
using App.HRIS.Views.Attendances;

namespace App.HRIS
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute("login", typeof(LoginPage));
            Routing.RegisterRoute("main", typeof(MainPage));
            Routing.RegisterRoute("home", typeof(HomePage));
            Routing.RegisterRoute("settings", typeof(SettingPage));
            Routing.RegisterRoute("submittime", typeof(SubmitTimePage));
        }
    }
}
