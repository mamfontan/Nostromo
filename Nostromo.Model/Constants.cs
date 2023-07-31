namespace Nostromo.Model
{
    public static class Constants
    {
        public static string SEPARATOR = " - ";

        #region Unit management permissions
        public static string UNIT_CREATION = "UNT00";

        public static string UNIT_READ = "UNT01";

        public static string UNIT_EDIT = "UNT02";

        public static string UNIT_DELETE = "UNT03";
        #endregion

        #region Material management permissions
        public static string MATERIAL_CREATION = "MAT00";

        public static string MATERIAL_READ = "MAT01";

        public static string MATERIAL_EDIT = "MAT02";

        public static string MATERIAL_DELETE = "MAT03";
        #endregion

        #region Settings permissions
        public static string SETTINGS_READ = "SET00";

        public static string SETTINGS_EDIT = "SET01";
        #endregion
    }
}
