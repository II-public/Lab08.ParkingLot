using Lab08.ParkingLot.Data.Constants;

namespace Lab08.ParkingLot.Data.ConfigurationHelpers
{
    public static class ConstraintNameBuilder
    {
        public static string GetIndexName(string objectName, params string[] columnNames)
        {
            return string.Format(ConfigurationConstants.IndexFormat, objectName, string.Concat(columnNames));
        }

        public static string GetForignKeyName(string referenceObject, params string[] referenceColumns)
        {
            return string.Format(ConfigurationConstants.ForeignKeyFormat, referenceObject, string.Concat(referenceColumns));
        }

        public static string GetForignKeyName<T1, T2>(params string[] referenceColumns)
        {
            return string.Format(ConfigurationConstants.ForeignKeyFormat, $"{typeof(T1).Name}_{typeof(T2).Name}", string.Concat(referenceColumns));
        }

        public static string GetPrimaryName(string objectName, params string[] columnNames)
        {
            return string.Format(ConfigurationConstants.PrimaryKeyFormat, objectName, string.Concat(columnNames));
        }
    }
}
