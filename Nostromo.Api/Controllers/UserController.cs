using Microsoft.AspNetCore.Mvc;
using Nostromo.DataAccess;
using Nostromo.Model;

namespace Nostromo.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        // GET: api/<UserController>
        [HttpGet]

        public NResponse Get()
        {
            var result = new NResponse()
            {
                MsgType = MESSSAGE_TYPE.INFORMATION,
                MsgText = "OK",
                MsgData = new string[] { "value1", "value2" },
            };

            try
            {
                // TODO
            } catch (Exception ex)
            {
                result.MsgType = MESSSAGE_TYPE.ERROR;
                result.MsgText = ex.Message;
                result.MsgData = null;
            }

            return result;
        }

        // GET api/<UserController>/5
        [HttpGet("{id}")]
        public NResponse Get(Guid id)
        {
            var result = new NResponse()
            {
                MsgType = MESSSAGE_TYPE.INFORMATION,
                MsgText = "OK",
                MsgData = "value1",
            };

            try
            {
                // TODO
            }
            catch (Exception ex)
            {
                result.MsgType = MESSSAGE_TYPE.ERROR;
                result.MsgText = ex.Message;
                result.MsgData = null;
            }

            return result;
        }


        // POST api/<UserController>
        [HttpPost]
        public void Post([FromBody] User value)
        {
        }

        // PUT api/<UserController>/5
        [HttpPut("{id}")]
        public void Put(Guid id, [FromBody] User value)
        {
        }

        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public void Delete(Guid id)
        {
        }

        [HttpGet]
        [Route("login")]
        public NResponse Login(string user, string password, string machine)
        {
            var result = new NResponse() {
                MsgType = MESSSAGE_TYPE.SUCCESS,
                MsgText = "All ok",
                MsgData = null,
            };

            try
            {
                if (string.IsNullOrEmpty(user) || string.IsNullOrEmpty(password))
                {
                    result.MsgType = MESSSAGE_TYPE.WARNING;
                    result.MsgText = "Incorrect parameters";
                    result.MsgData = null;
                }
                else
                {
                    DbAccess dbAccess = new DbAccess("DESKTOP-VKRDT4C", "Nostromo", "nostromo", "nostromo");
                    result.MsgData = dbAccess.Login(user, password, machine);
                }
            }
            catch (Exception ex)
            {
                result.MsgType = MESSSAGE_TYPE.ERROR;
                result.MsgText = ex.Message;
                result.MsgData = null;
            }

            return result;
        }

        [HttpGet]
        [Route("logout")]
        public NResponse Logout(Guid userId)
        {
            var result = new NResponse()
            {
                MsgType = MESSSAGE_TYPE.SUCCESS,
                MsgText = "All ok",
                MsgData = null,
            };

            try
            {
                DbAccess dbAccess = new DbAccess("DESKTOP-VKRDT4C", "Nostromo", "nostromo", "nostromo");
                result.MsgData = dbAccess.Logout(userId);
            }
            catch (Exception ex)
            {
                result.MsgType = MESSSAGE_TYPE.ERROR;
                result.MsgText = ex.Message;
                result.MsgData = null;
            }

            return result;
        }
    }
}
