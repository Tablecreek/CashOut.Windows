using Objects.Models;

namespace DisplayData.ViewModels
{

   public class NotmainPageViewModel : NotificationBase
   {

      private readonly SomeRandomDataModel _randomData;

      public int Number {
         get { return _randomData.Number; }
         set { SetProperty(_randomData.Number, value, () => _randomData.Number = value); }
      }

      public NotmainPageViewModel()
      {
         _randomData = new SomeRandomDataModel();
      }

   }

}