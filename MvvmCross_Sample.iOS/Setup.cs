using MvvmCross.Platforms.Ios.Core;
using MvvmCross.Platforms.Ios.Presenters;
using MvvmCross.Plugin.Sidebar;
using MvvmCross_Sample.Core;

namespace Blank
{
    public class Setup : MvxIosSetup<App>
    {
        protected override IMvxIosViewPresenter CreateViewPresenter()
        {
            return new MvxSidebarPresenter(ApplicationDelegate, Window);
        }
    }
}