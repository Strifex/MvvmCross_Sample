
using System;
using Cirrious.FluentLayouts.Touch;
using CoreGraphics;
using MvvmCross;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Platforms.Ios.Views;
using MvvmCross.Plugin.Sidebar;
using MvvmCross.Plugin.Sidebar.Views;
using MvvmCross_Sample.Core.ViewModels;
using UIKit;

namespace Blank.Views
{
    [MvxFromStoryboard("Main")]
    [MvxSidebarPresentation(MvxPanelEnum.Left, MvxPanelHintType.PushPanel, false)]
    public partial class MenuView : MvxViewController<MenuViewModel>
    {
        private UIButton _homeButton;
        private UIButton _settingsButton;

        public MenuView(IntPtr handle) : base(handle)
        {

        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            var scrollView = new UIScrollView(View.Frame)
            {
                ShowsHorizontalScrollIndicator = false,
                AutoresizingMask = UIViewAutoresizing.FlexibleHeight
            };

            // create a binding set for the appropriate view model
            var set = this.CreateBindingSet<MenuView, MenuViewModel>();

            _homeButton = new UIButton(new CGRect(0, 100, 320, 40));
            _homeButton.SetTitle("Tip Calc", UIControlState.Normal);
            _homeButton.BackgroundColor = UIColor.White;
            _homeButton.SetTitleColor(UIColor.Black, UIControlState.Normal);
            set.Bind(_homeButton).To(vm => vm.ShowTipCalcCommand);

            _settingsButton = new UIButton(new CGRect(0, 100, 320, 40));
            _settingsButton.SetTitle("Settings", UIControlState.Normal);
            _settingsButton.BackgroundColor = UIColor.White;
            _settingsButton.SetTitleColor(UIColor.Black, UIControlState.Normal);
            set.Bind(_settingsButton).To(vm => vm.ShowSettingsCommand);

            //Add Event Handler to Buttons Touch Events in order to dismiss menu
            _homeButton.TouchUpInside += HomeButton_TouchUpInside;
            _settingsButton.TouchUpInside += _settingsButton_TouchUpInside;

            set.Apply();

            Add(scrollView);

            View.SubviewsDoNotTranslateAutoresizingMaskIntoConstraints();

            View.AddConstraints(
                scrollView.AtLeftOf(View),
                scrollView.AtTopOf(View),
                scrollView.WithSameWidth(View),
                scrollView.WithSameHeight(View));

            scrollView.Add(_homeButton);
            scrollView.Add(_settingsButton);

            scrollView.SubviewsDoNotTranslateAutoresizingMaskIntoConstraints();

            var constraints = scrollView.VerticalStackPanelConstraints(new Margins(20, 20, 20, 10, 5, 5), scrollView.Subviews);
            scrollView.AddConstraints(constraints);
        }

        public override void ViewDidUnload()
        {
            //Remove Event Handlers
            _homeButton.TouchUpInside -= HomeButton_TouchUpInside;
            _settingsButton.TouchUpInside -= _settingsButton_TouchUpInside;

            base.ViewDidUnload();
        }

        private void HomeButton_TouchUpInside(object sender, EventArgs e)
        {
            var menu = Mvx.Resolve<IMvxSidebarViewController>();
            menu?.CloseMenu();
        }

        private void _settingsButton_TouchUpInside(object sender, EventArgs e)
        {
            var menu = Mvx.Resolve<IMvxSidebarViewController>();
            menu?.CloseMenu();
        }

        public override void ViewWillAppear(bool animated)
        {
            Title = "Menu";
            base.ViewWillAppear(animated);
        }
    }
}