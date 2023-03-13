namespace Roblox.Databases
{
    public interface IGlobalDatabase
    {
        DatabaseType DbType { get; }

        string ConnectionString { get; }

        // C# 11.0
#if NET7_0_OR_GREATER
        static abstract IGlobalDatabase Singleton { get;}
#endif
    }
}
