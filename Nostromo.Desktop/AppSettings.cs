using System;

namespace Nostromo.Desktop
{
    public enum LANGUAGE { ENGLISH, SPANISH }

    public class AppSettings
    {
        public GeneralSettings General { get; set; }

        public DatabaseSettings Database { get; set; }

        #region Constructors
        public AppSettings()
        {
            General = new GeneralSettings();
            Database = new DatabaseSettings();
        }
        #endregion

        #region Public methods
        public void Save()
        {
            // TODO Save
        }
        #endregion
    }

    public class GeneralSettings
    {
        public LANGUAGE Language { get; set; }

        public string LogFolder { get; set; }

        public string ExportFolder { get; set; }

        #region Constructors
        public GeneralSettings()
        {
            Language = LANGUAGE.ENGLISH;
            LogFolder = string.Empty;
            ExportFolder = string.Empty;
        }
        #endregion
    }

    public class DatabaseSettings
    {
        public string DbServer { get; set; }

        public string DbSchema { get; set; }

        public string DbUser { get; set; }

        public string DbPassword { get; set; }

        public string BaseUrl { get; set; }

        #region Constructors
        public DatabaseSettings()
        {
            DbServer = string.Empty;
            DbSchema = string.Empty;
            DbUser = string.Empty;
            DbPassword = string.Empty;

            BaseUrl = "'https://localhost:7139/api/";
        }
        #endregion
    }
}
