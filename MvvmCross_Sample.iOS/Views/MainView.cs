
using System;
using MvvmCross.Platforms.Ios.Views;
using MvvmCross.Plugin.Sidebar;
using MvvmCross_Sample.Core.ViewModels;

namespace Blank.Views
{
    [MvxFromStoryboard("Main")]
    [MvxSidebarPresentation(MvxPanelEnum.Center, MvxPanelHintType.ResetRoot, true)]
    public partial class MainView : MvxViewController<MainViewModel>
    {
        public MainView(IntPtr handle) : base(handle)
        {

        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            ViewModel.ShowMenu();
        }
    }
}