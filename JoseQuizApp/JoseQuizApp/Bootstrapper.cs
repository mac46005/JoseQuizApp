using Autofac;
using JoseQuizApp.Logic;
using JoseQuizApp.Models;
using JoseQuizApp.Repositories;
using JoseQuizApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using Xamarin.Forms;

namespace JoseQuizApp
{
    public abstract class Bootstrapper
    {
        protected ContainerBuilder ContainerBuilder { get; set; }
        public Bootstrapper()
        {
            Initialize();
            FinishInitializing();
        }
        private void Initialize()
        {
            //var currentAssembly = Assembly.GetExecutingAssembly();
            ContainerBuilder = new ContainerBuilder();

            // Registers Types of Views and ViewModels and models
            Assembly.GetExecutingAssembly().DefinedTypes
                .Where(t => (t.IsSubclassOf(typeof(ViewModel)) || t.IsSubclassOf(typeof(Page))))
                .ToList()
                .ForEach(t => ContainerBuilder.RegisterType(t.AsType()));
            ContainerBuilder.RegisterType<AnswerModel>();
            ContainerBuilder.RegisterType<QuestionModel>();

            ContainerBuilder.RegisterType<Quiz>();
            // Singletons
            ContainerBuilder.RegisterType<QuestionRepository>().SingleInstance();
            ContainerBuilder.RegisterType<AnswerRepository>().SingleInstance();
            ContainerBuilder.RegisterType<QuizManager>().SingleInstance();

        }
        private void FinishInitializing()
        {
            var container = ContainerBuilder.Build();
            Resolver.Initialize(container);
        }
    }
}
