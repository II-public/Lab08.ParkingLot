namespace Lab08.ParkingLot.Data.Constants
{
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "Ignore for constants")]
    public static class ConfigurationConstants
    {
        public const string SchemaName = "Lab08";

        public const string IndexFormat = "IDX_{0}_{1}";

        public const string ForeignKeyFormat = "FK_{0}_{1}";

        public const string PrimaryKeyFormat = "PK_{0}_{1}";

        public const string DateFormat = "date";

        /// <summary>
        /// Not the best user to be used but all we need this is for the migrations
        /// </summary>
        public const string CreateMigrationConnectionString = "Data Source=(local);Initial Catalog=Lab08.ParkingLot;User ID=sa;Password=test123;";
    }
}
