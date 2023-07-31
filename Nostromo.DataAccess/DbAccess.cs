using Nostromo.Model;

namespace Nostromo.DataAccess
{
    public class DbAccess : DBase
    {
        #region Constructors
        public DbAccess(string server, string schema, string user, string password)
            : base(server, schema, user, password)
        {
        }
        #endregion

        #region Public methods
        public User? Login(string user, string password, string machineName)
        {
            User? result = null;

            if (string.IsNullOrEmpty(user) || string.IsNullOrEmpty(password))
                return null;

            string queryUser = string.Format("SELECT Id, Login, Password, Active, cUser, cDate, mUser, mDate FROM Users WHERE Login = '{0}' AND Password = '{1}'", user, password);
            var dataUser = this.ExecuteQuery(queryUser);

            if (dataUser != null && dataUser.Rows != null && dataUser.Rows.Count == 1)
            {
                result = ConverDataTableToObjectList<User>(dataUser).FirstOrDefault();
                if (result != null && result.Active)
                {
                    string queryProfiles = string.Format("SELECT P.Id, P.Code, P.Name, P.Active, P.cUSer, P.cDate, P.mUser, P.mDate FROM Profiles P JOIN UserProfiles UP ON P.Id = UP.IdProfile WHERE UP.IdUser = '{0}'", result.Id);
                    var dataProfiles = this.ExecuteQuery(queryProfiles);
                    if (dataProfiles != null && dataProfiles.Rows != null && dataProfiles.Rows.Count > 0)
                    {
                        result.Profiles = ConverDataTableToObjectList<Profile>(dataProfiles);

                        foreach(var actualProfile in result.Profiles)
                        {
                            string queryModules = string.Format("SELECT M.Id, M.Code, M.Name, M.Active, M.cUser, M.cDate, M.mUser, M.mDate FROM Modules M JOIN ProfileModules PM ON M.Id = PM.IdModule WHERE PM.IdProfile = '{0}'", actualProfile.Id);
                            var dataModule = this.ExecuteQuery(queryModules);
                            if (dataModule != null && dataModule.Rows != null && dataModule.Rows.Count > 0)
                            {
                                actualProfile.Modules = ConverDataTableToObjectList<Module>(dataModule);

                                foreach (var actualModule in actualProfile.Modules)
                                {
                                    string queryOperationGroups = string.Format("SELECT OG.* FROM OperationGroups OG JOIN Modules M ON OG.IdModule = M.Id WHERE IdModule = '{0}'", actualModule.Id);
                                    var dataOperationGroups = this.ExecuteQuery(queryOperationGroups);
                                    if (dataOperationGroups != null && dataOperationGroups.Rows != null && dataOperationGroups.Rows.Count > 0)
                                    {
                                        actualModule.OperationGroups = ConverDataTableToObjectList<OperationGroup>(dataOperationGroups);

                                        foreach(var actualOperationGroup in actualModule.OperationGroups)
                                        {
                                            string queryOperations = string.Format("SELECT O.* FROM Operations O WHERE O.IdOperationGroup = '{0}' ORDER BY Code", actualOperationGroup.Id);
                                            var dataOperations = this.ExecuteQuery(queryOperations);
                                            if (dataOperations != null && dataOperations.Rows != null && dataOperations.Rows.Count > 0)
                                            {
                                                actualOperationGroup.Operations = ConverDataTableToObjectList<Operation>(dataOperations);
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }

                    string queryUnits = string.Format("SELECT U.* FROM Units U JOIN UserUnits UU ON U.Id = UU.IdUnit WHERE UU.IdUser = '{0}' ORDER BY TackMark", result.Id);
                    var dataUnits = this.ExecuteQuery(queryUnits);
                    if (dataUnits != null && dataUnits.Rows != null && dataUnits.Rows.Count > 0)
                    {
                        result.Units = ConverDataTableToObjectList<Unit>(dataUnits);
                    }

                    // TODO Insert into accesslog
                    var strMachineName = (string.IsNullOrEmpty(machineName)) ? "null" : "'" + machineName + "'";
                    string queryInsert = string.Format("INSERT INTO AccessLog (IdUser, Login, MachineName) VALUES ('{0}', getdate(), {1})", result.Id, strMachineName);
                    var resultAccessLog = this.ExecuteNonQuery(queryInsert);

                    Console.WriteLine("Hemos insertado: " + resultAccessLog);
                }
                else
                {
                    result = null;
                }
            }

            return result;
        }

        public int Logout(Guid userId)
        {
            var result = -1;

            string query = string.Format("UPDATE AccessLog SET Logout = getdate() WHERE IdUser = '{0}' and Login = (SELECT TOP(1) Login FROM AccessLog WHERE IdUser = '{0}' ORDER BY Login DESC)", userId);
            result = this.ExecuteNonQuery(query);

            return result;
        }
        #endregion
    }
}
