using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace Display.Views
{

   public partial class Shell : BasePage
   {

      public bool IsMenuOpen {
         get { return MainSplitView.IsPaneOpen; }
         set { MainSplitView.IsPaneOpen = value; }
      }

      public Shell()
      {
         InitializeComponent();
      }

      public event BackClickEventHandler BackButtonClicked;

      private void BackRadioButtonClick(object sender, RoutedEventArgs e)
      {
         var args = new BackClickEventArgs();
         BackButtonClicked?.Invoke(sender, args);
      }

      private void HamburgerRadioButtonClick(object sender, RoutedEventArgs e)
      {
         IsMenuOpen = !IsMenuOpen;
      }

      private void HomeRadioButtonClick(object sender, RoutedEventArgs e)
      {
         NavigateTo(typeof(MainPage));
      }

      protected virtual void NotHomeButtonClick(object sender, RoutedEventArgs e)
      {
         NavigateTo(typeof(NotmainPage), true);
      }

      private void NavigateTo(Type page, bool navtigateIfAlreadyOpen = false)
      {
         var frame = DataContext as Frame;
         var currentPage = frame?.Content as Page;

         if (navtigateIfAlreadyOpen)
         {
            frame?.Navigate(page);
         }
         else if (currentPage?.GetType() != page)
         {
            frame?.Navigate(page);
         }

         if (MainSplitView.DisplayMode != SplitViewDisplayMode.Inline)
         {
            IsMenuOpen = false;
         }
      }

   }

}