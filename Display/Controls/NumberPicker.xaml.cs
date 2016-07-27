using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;

namespace Display.Controls
{

   public sealed partial class NumberPicker : UserControl
   {

      public static readonly DependencyProperty NumberProperty = DependencyProperty.Register("Number", typeof(int),
         typeof(NumberPicker), null);

      public static readonly DependencyProperty HeaderProperty = DependencyProperty.Register("Header", typeof(string),
         typeof(NumberPicker), null);

      public int Number {
         get { return (int) GetValue(NumberProperty); }
         set { SetValue(NumberProperty, value); }
      }

      public string Header {
         get { return (string) GetValue(HeaderProperty); }
         set { SetValue(HeaderProperty, value); }
      }

      public NumberPicker()
      {
         InitializeComponent();

         var frameworkElement = Content as FrameworkElement;
         if (frameworkElement != null)
         {
            frameworkElement.DataContext = this;
         }
      }

      public event TappedEventHandler NumberChanged;

      private void DecreaseButton_OnClick(object sender, RoutedEventArgs e)
      {
         var currentValue = int.Parse(Content.Text);

         if (currentValue == 0)
         {
            return;
         }
         Content.Text = (currentValue - 1).ToString();
      }

      private void IncreaseButton_OnClick(object sender, RoutedEventArgs e)
      {
         var currentValue = int.Parse(Content.Text);
         Content.Text = (currentValue + 1).ToString();
      }

      private void Content_OnTextChanging(TextBox sender, TextBoxTextChangingEventArgs args)
      {
         sender.Text = sender.Text.Replace("-", "");

         var number = 0;
         if (int.TryParse(sender.Text, out number))
         {
            Number = number;
            NumberChanged?.Invoke(sender, new TappedRoutedEventArgs());
         }
         sender.Text = Number.ToString();
      }

   }

}