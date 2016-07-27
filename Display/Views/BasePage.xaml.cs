using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace Display.Views
{

   public partial class BasePage : Page
   {

      public readonly Shell Shell;

      public BasePage()
      {
         Shell = Window.Current.Content as Shell;
      }

      protected override void OnNavigatedTo(NavigationEventArgs e)
      {
         base.OnNavigatedTo(e);

         SystemNavigationManager.GetForCurrentView().BackRequested += OnBackRequested;

         if (Shell != null)
         {
            Shell.BackButtonClicked += OnBackRequested;
         }
      }

      protected override void OnNavigatedFrom(NavigationEventArgs e)
      {
         base.OnNavigatedFrom(e);

         SystemNavigationManager.GetForCurrentView().BackRequested -= OnBackRequested;

         if (Shell != null)
         {
            Shell.BackButtonClicked -= OnBackRequested;
         }
      }

      protected virtual void GoBack()
      {
         if (!Frame.CanGoBack)
         {
            return;
         }

         Frame.GoBack();
      }

      private void OnBackRequested(object sender, BackRequestedEventArgs e)
      {
         e.Handled = true;
         GoBack();
      }

      private void OnBackRequested(object sender, BackClickEventArgs e)
      {
         e.Handled = true;
         GoBack();
      }

   }

}