using System;

using RestSharp;
using Nostromo.Model;
using System.Text.Json;

namespace Nostromo.Desktop
{
    public class WServiceHelper
    {
        private string _url = string.Empty;

        #region Constructors
        public WServiceHelper()
        {
            _url = string.Empty;
        }

        public WServiceHelper(string baseUrl)
        {
            _url = baseUrl;
        }
        #endregion

        #region Private methods
        //public void CallWebService(string url)
        //{
        //    var client = new RestClient(url);


        //    var requst = new RestRequest();
        //    requst.Parameters.AddParameter

        //    var response = client.Execute(new RestRequest());
        //    c
        //    var dataReceived = response.Content;

        //    int x = 9;
        //}
        #endregion

        #region Public methods
        public User? Login(string user, string password, string machineName)
        {
            User? result = null;

            try
            {
                var url = _url + "User/login";

                var client = new RestClient(url);

                var request = new RestRequest();
                request.AddParameter("user", user);
                request.AddParameter("password", password);
                request.AddParameter("machine", machineName);

                RestResponse response = client.Execute(request);

                if (response != null && response.Content != null)
                {
                    JsonSerializerOptions options = new JsonSerializerOptions(JsonSerializerDefaults.Web);
                    NResponse resp = JsonSerializer.Deserialize<NResponse>(response.Content, options);
                    if (resp != null && resp.MsgType == MESSSAGE_TYPE.SUCCESS && resp.MsgData != null)
                    {
                        result = JsonSerializer.Deserialize<User>(resp.MsgData.ToString(), options);
                    }
                }
            }
            catch(Exception error)
            {
                // TODO Log the error
            }

            return result;
        }

        public void Logout(Guid idUser)
        {
            try
            {
                var url = _url + "User/logout";

                var client = new RestClient(url);
                var request = new RestRequest();
                request.AddParameter("userId", idUser);
                client.Execute(request);
            }
            catch (Exception error)
            {
                // TODO Log the error
            }
        }
        #endregion
    }
}
