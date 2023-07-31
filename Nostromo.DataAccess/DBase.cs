using System.Data;
using System.Reflection;
using System.Data.SqlClient;

namespace Nostromo.DataAccess
{
    public class DBase
    {
        private string _strConn = string.Empty;

        #region Constructors
        public DBase(string server, string schema, string user, string password)
        {
            _strConn = string.Format("Server={0};Database={1};User Id={2};Password={3};", server, schema, user, password);
        }
        #endregion

        #region Public methods
        public DataTable? ExecuteQuery(string query)
        {
            DataTable? result = new DataTable();

            using (SqlConnection con = new SqlConnection(_strConn))
            {
                con.Open();
                using (SqlDataAdapter da = new SqlDataAdapter(query, con))
                {
                    da.Fill(result);
                }
            }

            return result;
        }

        public int ExecuteNonQuery(string query)
        {
            int result = -1;

            using (SqlConnection con = new SqlConnection(_strConn))
            {
                SqlCommand command = new SqlCommand(query, con);
                command.Connection.Open();
                result = command.ExecuteNonQuery();
            }

            return result;
        }

        public List<T> ConverDataTableToObjectList<T>(DataTable data) where T : new() 
        {
            List<T> result = new List<T>();

            if (data != null)
            {
                foreach(DataRow row in data.Rows)
                {
                    result.Add(ConverDataRowToObject<T>(row));
                }
            }

            return result;
        }

        public T ConverDataRowToObject<T>(DataRow data) where T : new()
        {
            T result = new T();

            if (data != null)
            {
                List<PropertyInfo> properties = typeof(T).GetProperties().ToList();

                foreach (var property in properties)
                {
                    if (data.Table.Columns.Contains(property.Name))
                    {
                        if (data[property.Name] != DBNull.Value)
                            property.SetValue(result, data[property.Name], null);
                    }
                }
            }

            return result;
        }


        #endregion
    }
}