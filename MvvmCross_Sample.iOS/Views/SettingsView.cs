
using System;
using MvvmCross.Platforms.Ios.Views;
using MvvmCross.Plugin.Sidebar;
using MvvmCross_Sample.Core.ViewModels;

namespace Blank.Views
{
    [MvxFromStoryboard("Main")]
    [MvxSidebarPresentation(MvxPanelEnum.Center, MvxPanelHintType.ResetRoot, true)]
    public partial class SettingsView : MvxViewController<SettingsViewModel>
    {
        public SettingsView(IntPtr handle) : base(handle)
        {

        }
    }
}