using App.HRIS.Views.Attendances;
using CommunityToolkit.Maui;
using Microsoft.Extensions.Logging;
using Plugin.Fingerprint.Abstractions;
using Plugin.Fingerprint;
using App.HRIS.Services.Employees;
using App.HRIS.ViewModels;
using App.HRIS.Views;
using App.HRIS.Models;

namespace App.HRIS
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .UseMauiCommunityToolkit()
                .UseMauiCommunityToolkitCamera()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

#if DEBUG
    		builder.Logging.AddDebug();
#endif
            builder.Services.AddSingleton<ViewModelBase>();
            builder.Services.AddSingleton<EmployeeDetailsViewModel>();
            builder.Services.AddSingleton<HomePage>();
            builder.Services.AddTransient<SubmitTimePage>();
            builder.Services.AddTransient<Employee>();
            builder.Services.AddSingleton<IEmployeeService, EmployeeService>();            
            builder.Services.AddSingleton(typeof(IFingerprint), CrossFingerprint.Current);
            return builder.Build();
        }
    }
}
