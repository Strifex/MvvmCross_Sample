using Android.OS;
using Android.Runtime;
using Android.Views;
using MvvmCross.Platforms.Android.Presenters.Attributes;
using MvvmCross_Sample.Core.ViewModels;

namespace MvvmCross_Sample.Droid.Fragments
{
    [MvxFragmentPresentation(typeof(MainViewModel), Resource.Id.content_frame)]
    [Register("mvvmcross_sample.droid.fragments.TipView")]
    public class TipView : BaseFragment<TipViewModel>
    {
        protected override int FragmentId => Resource.Layout.tipview;

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            ShowHamburgerMenu = true;

            return base.OnCreateView(inflater, container, savedInstanceState);
        }
    }
}
