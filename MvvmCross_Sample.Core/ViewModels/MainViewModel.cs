using MvvmCross;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;

namespace MvvmCross_Sample.Core.ViewModels
{
    public class MainViewModel : MvxViewModel
    {
        public void ShowMenu()
        {
            Mvx.IoCProvider.Resolve<IMvxNavigationService>().Navigate<MenuViewModel>();
            Mvx.IoCProvider.Resolve<IMvxNavigationService>().Navigate<TipViewModel>();
        }
    }
}
