using BooksDbReader.Settings;

namespace PortalApp
{
    public class AppSetup
    {
        public static void SetupServices(WebApplicationBuilder? builder)
        {
            if (builder != null)
            {
                // Add our Config object so it can be injected
                builder.Services.Configure<MongoDbSettings>(
                    builder.Configuration.GetSection("MongoDbSettings"));

                // Add services to the container.
                builder.Services.AddControllersWithViews();

            }
        }
    }
}
