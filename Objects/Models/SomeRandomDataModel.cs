using System;
using Objects.Provider;

namespace Objects.Models
{

   public class SomeRandomDataModel : IStorable
   {

      public const int DefaultNumber = 0;

      public int Number { get; set; } = DefaultNumber;

      public void Store()
      {
         throw new NotImplementedException();
      }

      public void Restore()
      {
         var randomDataLoader = new RandomDataLoader();
         var loadedDataModel = randomDataLoader.LoadSomeRandomDataModel();

         Number = loadedDataModel.Number;
      }

   }

}