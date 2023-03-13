using System;
using System.Diagnostics;

namespace Roblox.Databases
{
    /// <summary>
    /// Base singleton class.
    /// </summary>
    /// <typeparam name="TSingleton"></typeparam>
    public abstract class GlobalDatabase<TSingleton> : IGlobalDatabase
        where TSingleton : IGlobalDatabase, new()
    {
        /// <summary>
        /// The singleton instance to be returned when indexing this singleton.
        /// The <see cref="TSingleton"/> parameter should have at least one public empty constructor.
        /// </summary>
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        public static IGlobalDatabase Singleton { get; } = new TSingleton();

        public DatabaseType DbType { get; }

        public string ConnectionString { get; }

        public GlobalDatabase(string connectionString, DatabaseType databaseType = DatabaseType.Mssql)
        {
            if (string.IsNullOrEmpty(connectionString)) throw new ArgumentNullException(nameof(connectionString));

            ConnectionString = connectionString;
            DbType = databaseType;
        }
    }
}