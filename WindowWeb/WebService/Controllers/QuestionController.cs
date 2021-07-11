using System;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Results;
using Newtonsoft.Json;
using WindowWeb.WebService.Models;

namespace WindowWeb.WebService.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class QuestionController : ApiController
    {
        [HttpPost]
        [Route("api/{controller}/")]
        public IHttpActionResult Post([FromUri] Guid gameId, [FromBody] SubmitAnswerRequest item)
        {
            if (item == null || gameId == null || gameId == default)
            {
                return new BadRequestErrorMessageResult("No answer given", this);
            }

            var result = Hooks.QuestionAnswered?.Invoke(item, gameId);

            return Json(result);
        }

        [HttpGet]
        [Route("api/{controller}/")]
        public IHttpActionResult Get([FromUri] Guid gameId)
        {
            if (gameId == null || gameId == default)
            {
                return new BadRequestErrorMessageResult("No answer given", this);
            }

            var question = Hooks.QuestionWanted?.Invoke(gameId);
            if (question == null)
            {
                return new InternalServerErrorResult(this);
            }

            return Json(question);
        }
    }
}