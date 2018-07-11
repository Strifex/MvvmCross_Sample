using MvvmCross.IoC;
using MvvmCross.ViewModels;
using MvvmCross_Sample.Core.ViewModels;

namespace MvvmCross_Sample.Core
{
    public class App : MvxApplication
    {
        public override void Initialize()
        {
            //Register App Services
            CreatableTypes()
                .EndingWith("Service")
                .AsInterfaces()
                .RegisterAsLazySingleton();

            //Register App Entry Point
            RegisterAppStart<TipViewModel>();
        }
    }
}
