using MvvmCross.ViewModels;

namespace MvvmCross_Sample.Core.ViewModels
{
    public class MainViewModel : MvxViewModel
    {
        public void ShowMenu()
        {
            NavigationService.Navigate<MenuViewModel>();
            NavigationService.Navigate<TipViewModel>();
        }
    }
}
