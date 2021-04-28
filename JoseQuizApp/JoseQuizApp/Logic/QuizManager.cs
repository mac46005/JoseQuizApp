using JoseQuizApp.Models;
using JoseQuizApp.Repositories;
using JoseQuizApp.VIewModels;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace JoseQuizApp.Logic
{
    public class QuizManager
    {
        //private readonly IConfiguration _config = new ConfigurationBuilder().AddJsonFile(@"E:\C#\GitHub_Repositories\JoseQuizApp_SLN\JoseQuizApp\JoseQuizApp\appsettings.json")
        //.Build();
        private readonly AnswerRepository _answerRepository;
        private readonly QuestionRepository _questionRepository;
        public Quiz Quiz { get; set; }
        public int QuestionCount { get; set; } = 10;//<==Default;
        public QuizManager(AnswerRepository answerRepository, QuestionRepository questionRepository)
        {
            _answerRepository = answerRepository;
            _questionRepository = questionRepository;
        }
        public async Task CreateQuiz()
        {
            Quiz = Resolver.Resolve<Quiz>();
            var listOfQuestions = await _questionRepository.GetItems();
            for (int i = 0; i < QuestionCount; i++)
            {
                var randNum = new Random().Next(listOfQuestions.Count - 1);
                var vm = Resolver.Resolve<QuestionItemViewModel>();
                vm.Question = listOfQuestions[randNum];
                Quiz.QuestionsList.Add(vm);
            }
            Quiz.QuestionsList.ForEach(async q =>
            {
                var vm = Resolver.Resolve<AnswerItemViewModel>();
                vm.Answer = await _answerRepository.GetItem_ById(q.Question.Answer_Id);
                Quiz.AnswersList.Add(vm);
            }
            );
        }























        public async Task LoadDataOnce()
        {
            string[] answers2 =
                        {
                "Subprogram call of program number that defines pocket geometry",
                "X position of starting hole",
                "Y position of starting hole",
                "Final depth of pocket",
                "Incremental Z-axis depth starting from R plane",
                "R plane clearance position",
                "X-axis shift over cut increment",
                "Y-axis shift over cut increment",
                "Finishing cut allowance",
                "Cutter compensation",
                "Cutter compensation geometry offset register number",
                "Feed rate"
            };
            string[] questions2 =
            {
                "Define the P letter for the General Purpose Pocket Pilling",
                "Define the X letter for the General Purpose Pocket Pilling",
                "Define the Y letter for the General Purpose Pocket Pilling",
                "Define the Z letter for the General Purpose Pocket Pilling",
                "Define the Q letter for the General Purpose Pocket Pilling",
                "Define the R letter for the General Purpose Pocket Pilling",
                "Define the I letter for the General Purpose Pocket Pilling",
                "Define the J letter for the General Purpose Pocket Pilling",
                "Define the K letter for the General Purpose Pocket Pilling",
                "Define the G41 G42 letter for the General Purpose Pocket Pilling",
                "Define the D letter for the General Purpose Pocket Pilling",
                "Define the F letter for the General Purpose Pocket Pilling"
            };


            string mess =
                "G80 ," +
                "Cancel Canned Cycle ," +
                "G81," +
                " Drill Canned Cycle ," +
                "G82," +
                " Spot Drill  Counterbore Canned Cycle ," +
                "G83," +
                " Peck Drill Deep Hole Canned Cycle," +
                "G84," +
                "Tapping Canned Cycle ," +
                "G85," +
                " Bore in~Bore out Canned Cycle," +
                "G86," +
                " Bore in~Stop~Rapid out Canned Cycle ," +
                "G87," +
                " Bore in~Manual Retract Canned Cycle," +
                "G88," +
                " Bore~Dwell~Manual Retract Canned Cycle," +
                "G89," +
                " Bore~Dwell~Bore out Canned Cycle," +
                "G00," +
                " Rapid Positioning Motion ," +
                "G01," +
                " Linear Interpolation Motion ," +
                "G02," +
                " Circular Interpolation Motion CW," +
                "G03," +
                " Circular Interpolation Motion CCW," +
                "G12," +
                " Circular Pocket Milling CW," +
                "G13," +
                " Circular Pocket Milling CCW," +
                "G28," +
                " Machine Zero Return Thru Reference Point," +
                "G40," +
                " Cutter Compensation Cancel ," +
                "G41," +
                " 2D Cutter Compensation Left," +
                "G42," +
                " 2D Cutter Compensation Right," +
                "G43," +
                " Tool Length Compensation +," +
                "G53," +
                " Machine Zero XYZ Positioning Non - Modal," +
                "G54," +
                " Work Offset Positioning Coordinate #1," +
                "G70," +
                " Bolt Hole Circle with a Canned Cycle," +
                "G71," +
                " Bolt Hole Arc with a Canned Cycle," +
                "G72," +
                " Bolt Holes Along an Angle with a Canned Cycle," +
                "G73," +
                " High Speed Peck Drill Canned Cycle," +
                "G74," +
                " Reverse Tapping Canned Cycle," +
                "G76," +
                " Fine Boring Canned Cycle," +
                "G90," +
                " Absolute Positioning Command ," +
                "G91," +
                " Incremental Positioning Command ," +
                "G98," +
                " Canned Cycle Initial Point Return ," +
                "G99," +
                " Canned Cycle R Plane Return," +
                "M00," +
                " Program Stop," +
                "M01," +
                " Optional Program Stop," +
                "M02," +
                " Program End," +
                "M03," +
                " Spindle On Clockwise," +
                "M04," +
                " Spindle On Counterclockwise," +
                "M05," +
                " Spindle Stop," +
                "M06," +
                " Tool Change," +
                "M08," +
                " Coolant On," +
                "M09," +
                " Coolant Off," +
                "M30," +
                " Program End and Reset," +
                "M97," +
                " Local Sub - Program Call," +
                "M98," +
                " Sub Program Call," +
                "M99," +
                " M97 Local Sub-Program or M98 Sub - Program Return or Loop Program,";

            var ac = 0;
            var qc = 0;
            for (int i = 0; i < ((answers2.Length + questions2.Length)); i++)
            {
                if (i % 2 == 0)
                {
                    mess += answers2[ac] + ",";
                    ac++;
                }
                else
                {
                    mess += questions2[qc] + ",";
                    qc++;
                }
            }

            var newmess = mess.Remove(mess.Length - 1);




            var array = newmess.Split(',');
            var splitVal = array.Length / 2;
            string[] answers = new string[splitVal];
            string[] questions = new string[splitVal];
            ac = 0;
            qc = 0;

            for (int i = 0; i < array.Length - 1; i++)
            {
                if (i % 2 == 0)
                {
                    answers[ac] = array[i];
                    ac++;
                }
                else
                {
                    questions[qc] = array[i];
                    qc++;
                }
            }

            foreach (var item in answers)
            {
                var am = Resolver.Resolve<AnswerModel>();
                am.Solution = item;
                await _answerRepository.AddItem(am);
            }
            var answerList = await _answerRepository.GetItems();

            for (int i = 0; i < answerList.Count - 1; i++)
            {
                var qm = Resolver.Resolve<QuestionModel>();
                qm.Query = questions[i];
                qm.Answer_Id = answerList[i].Id;
                await _questionRepository.AddItem(qm);
            }
        }



















        public ResultsViewModel EvaluateQuiz()
        {
            var vm = Resolver.Resolve<ResultsViewModel>();


            for (int i = 0; i < Quiz.UserResponses.Count; i++)
            {
                if (Quiz.UserResponses[i].Response.Trim() == Quiz.AnswersList[i].Answer.Solution.Trim())
                {
                    Quiz.UserResponses[i].IsCorrect = true;
                }
            }



            var numCorrect = 0;
            Quiz.UserResponses.ForEach(r =>
            {
                if (r.IsCorrect)
                {
                    numCorrect += numCorrect++;
                }
            });

            vm.CorrectQuestions = numCorrect;
            vm.TotalQuestions = Quiz.UserResponses.Count;




            for (int i = 0; i < Quiz.QuestionsList.Count - 1; i++)
            {
                vm.ObsList_RLVM.Add(new ResultsListViewModel
                {
                    Question = Quiz.QuestionsList[i].Question,

                    UserResponse = Quiz.UserResponses[i]
                });
            }


            vm.ObsList_RLVM.ForEach(rlvm =>
            {
                rlvm.Question.Answer = Quiz.AnswersList.Find(aVM => aVM.Answer.Id == rlvm.Question.Answer_Id).Answer;
            });




            var percent = ((numCorrect / Quiz.UserResponses.Count) * 100).ToString("P");
            vm.Accuracy = $"{percent.ToString()}";
            return vm;
        }
    }
}
