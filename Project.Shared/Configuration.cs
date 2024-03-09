
namespace Project.Shared
{
    public static class Configuration
    {
        public static DatabaseConfiguration Database { get; set; } = new();
        public class DatabaseConfiguration
        {
            public string ConnectionString { get; set; } = String.Empty;
        }
    }
}
