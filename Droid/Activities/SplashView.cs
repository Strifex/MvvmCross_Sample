
using Android.App;
using MvvmCross.Platforms.Android.Views;

namespace MvvmCross_Sample.Droid.Activities
{
    [Activity(MainLauncher = true, ScreenOrientation = Android.Content.PM.ScreenOrientation.Portrait, NoHistory = true, Theme = "@style/MainTheme")]
    public class SplashView : MvxSplashScreenActivity
    {
        public SplashView() : base(Resource.Layout.splashview)
        {
            
        }
    }
}
