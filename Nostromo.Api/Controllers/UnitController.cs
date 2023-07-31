using Microsoft.AspNetCore.Mvc;
using Nostromo.Model;

namespace Nostromo.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UnitController : ControllerBase
    {
        // GET: api/<UserController>
        [HttpGet]
        //public IEnumerable<string> Get()
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
    }
}
