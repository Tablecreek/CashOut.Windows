using Windows.UI.Xaml.Controls;
using DisplayData.ViewModels;

namespace Display.Views
{

   public sealed partial class NotmainPage : Page
   {

      public NotmainPageViewModel NotmainPageViewModel;

      public NotmainPage()
      {
         InitializeComponent();
         NotmainPageViewModel = new NotmainPageViewModel();
      }

   }

}