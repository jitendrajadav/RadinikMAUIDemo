using CommunityToolkit.Maui;
using RadinikMAUIDemo.Comman;
using RadinikMAUIDemo.Data;
using RadinikMAUIDemo.Db;
using RadinikMAUIDemo.Services;
using RadinikMAUIDemo.ViewModels;
using RadinikMAUIDemo.Views;
using Microsoft.Extensions.Logging;

namespace RadinikMAUIDemo
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .UseMauiCommunityToolkit(options =>
                {
                    options.SetShouldEnableSnackbarOnWindows(true);
                })
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

#if DEBUG
    		builder.Logging.AddDebug();
#endif

            builder.Services.AddTransient<MainPage, MainPageViewModel>();
            builder.Services.AddTransient<CallsPage, CallsPageViewModel>();

            //Without EF
            builder.Services.AddSingleton<RadinikDatabase>();

            //With EF
            //builder.Services.AddTransient<LocalDatabase>((services) =>
            //{
            //    return new LocalDatabase();
            //});

            //With EF Repository Pattern
            builder.Services.AddDbContext<LocalDatabase>();
            builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
            builder.Services.AddScoped<TodoService>();

            return builder.Build();
        }
    }
}
