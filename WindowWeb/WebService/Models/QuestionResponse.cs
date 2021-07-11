namespace WindowWeb.WebService.Models
{
    public class QuestionResponse
    {
        public int Id { get; set; }
        public QuestionResponse(int id,string question,QuestionOption[] options)
        {
            Id = id;
            Question = question;
            // TODO ERROR CHECKING
            QuestionOptions = options;
        }
        public string Question { get; }
        public QuestionOption[] QuestionOptions { get; }
    }

    public class QuestionOption
    {
        public char AnswerLetter { get; set; }
        public string Answer { get; set; }
    }
}