using Autofac;
using JoseQuizApp.Models;
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

            // Registers Types of Views and ViewModels
            Assembly.GetExecutingAssembly().DefinedTypes
                .Where(t => (t.IsSubclassOf(typeof(ViewModel)) || (t.IsSubclassOf(typeof(Page)))))
                .ToList()
                .ForEach(t => ContainerBuilder.RegisterType(t.AsType()));

            ContainerBuilder.RegisterType<Quiz>();
            // Singletons

        }
        private void FinishInitializing()
        {
            var container = ContainerBuilder.Build();
            Resolver.Initialize(container);
        }
    }
}
