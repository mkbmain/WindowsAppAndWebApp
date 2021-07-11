using System;
using System.Drawing;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowWeb.WebService.Models;

namespace WindowWeb
{
    public class Window : Form
    {
        int port = 1555;
        private TextBox TextBox = new TextBox
            {Location = new Point(1, 1), Multiline = true, ScrollBars = ScrollBars.Both};

        private Task _webService;
        private CancellationToken _token;
        public Window()
        {
            this.Resize += OnResize;
            WebService.Hooks.QuestionAnswered = QuestionAnswered;
            WebService.Hooks.QuestionWanted = QuestionWanted;
            OnResize(null, null);
            _token = new CancellationToken();
            _webService=  Task.Run(() => WebService.WebService.SpinUpWebService(port),_token );
            this.Controls.Add(TextBox);


        }

        private QuestionResponse QuestionWanted(Guid gameId)
        {
            // TODO LOOK UP IN DB
            var item = new QuestionResponse(33,"what year was i born", new QuestionOption[]
            {
                new QuestionOption{AnswerLetter = 'A',Answer = "1983"},
                new QuestionOption{AnswerLetter = 'B',Answer = "1989"},
                new QuestionOption{AnswerLetter = 'C',Answer = "1996"},
                new QuestionOption{AnswerLetter = 'D',Answer = "2001"},
            });

            TextBox.Text += $"{Environment.NewLine}{gameId} got question {item.Id}";
            return item;
        }

        private AnswerResponse QuestionAnswered(SubmitAnswerRequest request, Guid gameid)
        {
            TextBox.Text += $"{Environment.NewLine}{gameid} answered {request.AnswerLetter} for question {request.Id}";

            return new AnswerResponse
            {
                Correct = request.Id == 33
            };
        }

        private void OnResize(object sender, EventArgs e)
        {
            TextBox.Size = this.Size;
        }
    }
}