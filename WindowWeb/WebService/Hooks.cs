using System;
using WindowWeb.WebService.Models;

namespace WindowWeb.WebService
{
    public static class Hooks
    {
        public static Func<SubmitAnswerRequest,Guid,AnswerResponse> QuestionAnswered = null;
        public static Func<Guid,QuestionResponse> QuestionWanted = null;
    }
}