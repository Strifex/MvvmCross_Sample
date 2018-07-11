
using Android.App;
using Android.OS;
using Android.Support.V4.View;
using Android.Support.V4.Widget;
using Android.Views;
using Android.Views.InputMethods;
using MvvmCross.Droid.Support.V7.AppCompat;
using MvvmCross.Platforms.Android.Presenters.Attributes;
using MvvmCross_Sample.Core.ViewModels;

namespace MvvmCross_Sample.Droid.Activities
{
    [MvxActivityPresentation]
    [Activity(Theme = "@style/MainTheme", ScreenOrientation = Android.Content.PM.ScreenOrientation.Portrait)]
    public class MainView : MvxAppCompatActivity<MainViewModel>
    {
        public DrawerLayout DrawerLayout;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            SetContentView(Resource.Layout.main);

            DrawerLayout = FindViewById<DrawerLayout>(Resource.Id.drawer_layout);

            if (bundle == null)
                ViewModel.ShowMenu();
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            switch (item.ItemId)
            {
                case Android.Resource.Id.Home:
                    if (DrawerLayout.GetDrawerLockMode(GravityCompat.Start) == DrawerLayout.LockModeLockedClosed)
                    {
                        //If drawer locked, this is likely the back arrow, so hide keyboard
                        HideSoftKeyboard();
                    }
                    else
                    {
                        //If drawer is unlocked, ok to open it
                        DrawerLayout.OpenDrawer(GravityCompat.Start);
                    }
                    return true;
            }

            return base.OnOptionsItemSelected(item);
        }

        public override void OnBackPressed()
        {
            if (DrawerLayout != null && DrawerLayout.IsDrawerOpen(GravityCompat.Start))
                DrawerLayout.CloseDrawers();
            else
                base.OnBackPressed();
        }

        public void HideSoftKeyboard()
        {
            if (CurrentFocus == null)
                return;

            var inputMethodManager = (InputMethodManager)GetSystemService(InputMethodService);
            inputMethodManager.HideSoftInputFromWindow(CurrentFocus.WindowToken, 0);

            CurrentFocus.ClearFocus();
        }
    }
}
