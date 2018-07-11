
using System;
using System.Threading.Tasks;
using Android.OS;
using Android.Runtime;
using Android.Support.Design.Widget;
using Android.Views;
using MvvmCross.Droid.Support.V4;
using MvvmCross.Platforms.Android.Binding.BindingContext;
using MvvmCross.Platforms.Android.Presenters.Attributes;
using MvvmCross_Sample.Core.ViewModels;
using MvvmCross_Sample.Droid.Activities;

namespace MvvmCross_Sample.Droid.Fragments
{
    [MvxFragmentPresentation(typeof(MainViewModel), Resource.Id.navigation_frame)]
    [Register("mvvmcross_sample.droid.fragments.MenuFragment")]
    public class MenuFragment : MvxFragment<MenuViewModel>, NavigationView.IOnNavigationItemSelectedListener
    {
        private NavigationView _navigationView;
        private IMenuItem _previousMenuItem;

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            base.OnCreateView(inflater, container, savedInstanceState);

            var view = this.BindingInflate(Resource.Menu.menu_navigation, null);

            _navigationView = view.FindViewById<NavigationView>(Resource.Id.navigation_view);
            _navigationView.SetNavigationItemSelectedListener(this);
            _navigationView.Menu.FindItem(Resource.Id.nav_tipcalc).SetChecked(true);

            return view;
        }

        public bool OnNavigationItemSelected(IMenuItem item)
        {
            if (item != _previousMenuItem)
            {
                _previousMenuItem?.SetChecked(false);
            }

            item.SetCheckable(true);
            item.SetChecked(true);

            _previousMenuItem = item;

            Navigate(item.ItemId);

            return true;
        }

        private async void Navigate(int itemId)
        {
            ((MainView)Activity).DrawerLayout.CloseDrawers();

            // add a small delay to prevent any UI issues
            await Task.Delay(TimeSpan.FromMilliseconds(250));

            switch (itemId)
            {
                case Resource.Id.nav_tipcalc:
                    ViewModel.ShowTipCalcCommand.Execute();
                    break;
                case Resource.Id.nav_settings:
                    ViewModel.ShowSettingsCommand.Execute();
                    break;
            }
        }
    }
}
