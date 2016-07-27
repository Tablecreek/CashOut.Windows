using System;
using Objects.Models;

namespace Objects.Provider
{

   public class RandomDataLoader
   {

      public SomeRandomDataModel LoadSomeRandomDataModel()
      {
         return new SomeRandomDataModel
         {
            Number = new Random().Next()
         };
      }

   }

}