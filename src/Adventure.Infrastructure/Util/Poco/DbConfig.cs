namespace Adventure.Infrastructure.Util.Poco
{
    public class DbConfig
    {
        public string Server { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string UserId { get; set; } = null!;
        public string Password { get; set; } = null!;
        public int CommandTimeout { get; set; } = 30;
        public int MaxRetryCount { get; set; } = 3;
        public int MaxRetryDelay { get; set; } = 10;

        public override string ToString()
        {
            return $"Server={Server};Initial Catalog={Name};User Id={UserId};Password={Password};Encrypt=true;TrustServerCertificate=True;";
        }
    }
}
