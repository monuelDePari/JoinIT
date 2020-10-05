namespace JoinIT.UnitTests
{
    public static class TestHelper<T>
    {
        public static T GetInstance<T>() where T : new()
        {
            var instance = new T();
            return instance;
        }
    }
}
