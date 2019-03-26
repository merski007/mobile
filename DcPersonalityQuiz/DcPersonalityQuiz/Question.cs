using System;
namespace DcPersonalityQuiz
{
    public class Question
    {
        public string UserQuestion { get; set; }
        public string[] AnswerA { get; set; } = new string[2];
        public string[] AnswerB { get; set; } = new string[2];
        public string[] AnswerC { get; set; } = new string[2];
        public string[] AnswerD { get; set; } = new string[2];


        public Question(string UserQuestion, string AnswerA1, string AnswerA2, string AnswerB1, string AnswerB2, string AnswerC1, string AnswerC2, string AnswerD1, string AnswerD2)
        {
            this.UserQuestion = UserQuestion;
            this.AnswerA[0] = AnswerA1;
            this.AnswerA[1] = AnswerA2;
            this.AnswerB[0] = AnswerB1;
            this.AnswerB[1] = AnswerB2;
            this.AnswerC[0] = AnswerC1;
            this.AnswerC[1] = AnswerC2;
            this.AnswerD[0] = AnswerD1;
            this.AnswerD[1] = AnswerD2;

        }


    }
}
