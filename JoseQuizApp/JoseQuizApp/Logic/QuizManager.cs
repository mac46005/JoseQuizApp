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
        public QuizManager(AnswerRepository answerRepository, QuestionRepository questionRepository)
        {
            _answerRepository = answerRepository;
            _questionRepository = questionRepository;
        }
        public async Task CreateQuiz()
        {
            int numOfQuestions = 10;//int.Parse(_config.GetSection("Options")["QuestionCount"]);
            Quiz = Resolver.Resolve<Quiz>();
            var listOfQuestions = await _questionRepository.GetItems();
            for (int i = 0; i < numOfQuestions; i++)
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
            string[] codes =
            {
                "G80","G81", "G82", "G83","G84","G85","G86","G87","G88","G89",
                "G00","G01","G02","G03","G12","G13","G28","G40","G41", "G42",
                "G43","G53","G43","G70","G71","G72","G73","G74","G76","G90","G91",
                "G98","G99","M00","M01","M02", "M03","M04", "M05","M06", "M08",
                "M09","M30","M97","M98","M99"
            };
            string[] questions =
            {
                "Cancel Canned Cycle","Drill Canned Cycle", "Spot Drill / Counterbore Canned Cycle",
                "Peck Drill Deep Hole Canned Cycle","Tapping Canned Cycle","Bore in~Bore out Canned Cycle",
                "Bore in~Stop~Rapid out Canned Cycle","Bore in~Manual Retract Canned Cycle","Bore~Dwell~Manual Retract Canned Cycle",
                "Bore~Dwell~Bore out Canned Cycle","Rapid Positioning Motion","Linear Interpolation Motion",
                "Circular Interpolation Motion CW","Circular Interpolation Motion CCW",
                "Circular Pocket Milling CW","Circular Pocket Milling CCW",
                "Machine Zero Return Thru Reference Point","G40”* “Cutter Compensation Cancel",
                "2D Cutter Compensation Left","2D Cutter Compensation Right","Tool Length Compensation +"
                ,"Machine Zero XYZ Positioning, Non-Modal","Work Offset Positioning Coordinate #1","Bolt Hole Circle with a Canned Cycle",
                "Bolt Hole Arc with a Canned Cycle","Bolt Holes Along an Angle with a Canned Cycle","High Speed Peck Drill Canned Cycle”," +
                "Reverse Tapping Canned Cycle","Fine Boring Canned Cycle","Absolute Positioning Command","Incremental Positioning Command",
                "Canned Cycle Initial Point Return","Canned Cycle \"R\" Plane Return","Program Stop","Optional Program Stop",
                "Program End","Spindle On, Clockwise","Spindle On, Counterclockwise","Spindle Stop","Tool Change","Coolant On",
                "Coolant Off","Program End and Reset","Local Sub-Program Call","Sub Program Call",
                "M97 Local Sub-Program or M98 Sub-Program Return or Loop Program"
            };
            foreach (var item in codes)
            {
                var am = Resolver.Resolve<AnswerModel>();
                am.Solution = item;
                await _answerRepository.AddItem(am);
            }
            var answerList = await _answerRepository.GetItems();

            for (int i = 0; i < answerList.Count-1; i++)
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


            for (int i = 0; i < Quiz.UserResponses.Count - 1; i++)
            {
                if (Quiz.UserResponses[i].Response == Quiz.AnswersList[i].Answer.Solution)
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
