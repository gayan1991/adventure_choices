namespace Adventure.Test.Fixtures
{
    public class TestDbManager
    {
        private bool _disposed = false;
        private TesAdventureDbContext TesAdventureDbContext { get; set; }

        private static TestDbManager _testDbManager;

        private TestDbManager()
        {
            TesAdventureDbContext = TesAdventureDbContext.GetTestDB();
        }

        public static TesAdventureDbContext CreateInstance()
        {
            _testDbManager = new TestDbManager();
            return _testDbManager.TesAdventureDbContext;
        }

        public static void Dispose()
        {
            _testDbManager.TesAdventureDbContext.Dispose();
        }
    }
}
