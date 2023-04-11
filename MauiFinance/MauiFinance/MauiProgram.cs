using DevExpress.Maui;
using Microsoft.Maui;
using Microsoft.Maui.Controls.Compatibility;
using Microsoft.Maui.Controls.Compatibility.Hosting;
using Microsoft.Maui.Controls.Hosting;
using Microsoft.Maui.Hosting;

namespace MauiFinance
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .UseDevExpress(useLocalization: true)
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("roboto-regular.ttf", "Roboto");
                    fonts.AddFont("roboto-medium.ttf", "Roboto-Medium");
                    fonts.AddFont("roboto-bold.ttf", "Roboto-Bold");
                    fonts.AddFont("univia-pro-regular.ttf", "Univia-Pro");
                    fonts.AddFont("univia-pro-medium.ttf", "Univia-Pro Medium");
                });
            var RAPIDAPIKEY = builder.Configuration["STOCK_API:KEY"];
            var RAPIDAPIHOST = builder.Configuration["STOCK_API:HOST"];

            return builder.Build();
        }
    }
}