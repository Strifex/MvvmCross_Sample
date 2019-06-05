using MvvmCross;
using MvvmCross.Commands;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;

namespace MvvmCross_Sample.Core.ViewModels
{
    public class MenuViewModel : MvxViewModel
    {
        public IMvxCommand ShowTipCalcCommand
        {
            get { return new MvxCommand(() => Mvx.IoCProvider.Resolve<IMvxNavigationService>().Navigate<TipViewModel>()); }
        }

        public IMvxCommand ShowSettingsCommand
        {
            get { return new MvxCommand(() => Mvx.IoCProvider.Resolve<IMvxNavigationService>().Navigate<SettingsViewModel>()); }
        }
    }
}
