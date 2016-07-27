using System;
using Windows.UI.Xaml.Input;

namespace Display.Controls
{

   public sealed partial class HamburgerButton
   {

      public enum Modes
      {

         Hamburger,
         Back,
         None

      }

      private Modes _mode;

      public Modes Mode {
         get { return _mode; }
         set {
            _mode = value;

            switch (_mode)
            {
               case Modes.Hamburger:
                  //TODO: Show Hamburger-Button
                  break;
               case Modes.Back:
                  //TODO: Show Back-Button
                  break;
               case Modes.None:
                  //TODO: Show None
                  break;
               default:
                  throw new ArgumentOutOfRangeException();
            }
         }
      }

      public HamburgerButton()
      {
         InitializeComponent();
      }

      public event TappedEventHandler HamburgerButtonClicked;

      public event TappedEventHandler BackButtonClicked;

      private void HamburgerRadioButtonTapped(object sender, TappedRoutedEventArgs e)
      {
         switch (_mode)
         {
            case Modes.Hamburger:
               HamburgerButtonClicked?.Invoke(sender, e);
               break;
            case Modes.Back:
               BackButtonClicked?.Invoke(sender, e);
               break;
            case Modes.None:
               break;
            default:
               throw new ArgumentOutOfRangeException();
         }
      }

   }

}