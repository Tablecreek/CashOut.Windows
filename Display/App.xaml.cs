using System;
using System.Diagnostics;
using Windows.ApplicationModel;
using Windows.ApplicationModel.Activation;
using Windows.Globalization;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using Display.Views;

namespace UwpTemplate
{

   public sealed partial class App : Application
   {

      private Frame _rootFrame;

      public App()
      {
         InitializeComponent();
         Suspending += OnSuspending;

         //UnhandledException += OnUnhandledException;
      }

      private void OnUnhandledException(object sender, UnhandledExceptionEventArgs unhandledExceptionEventArgs)
      {
         Debug.Write(sender + ": " + unhandledExceptionEventArgs.Message);
      }

      protected override void OnLaunched(LaunchActivatedEventArgs e)
      {
         var shell = Window.Current.Content as Shell;

         if (shell != null)
         {
            return;
         }

         _rootFrame = new Frame
         {
            Language = ApplicationLanguages.Languages[0]
         };

         _rootFrame.NavigationFailed += OnNavigationFailed;

         _rootFrame.SourcePageType = typeof(MainPage);

         shell = new Shell {DataContext = _rootFrame};

         Window.Current.Content = shell;

         Window.Current.Activate();
      }

      private void OnSuspending(object sender, SuspendingEventArgs e)
      {
         var deferral = e.SuspendingOperation.GetDeferral();
         //TODO: Save application state and stop any background activity
         deferral.Complete();
      }

      private void OnNavigationFailed(object sender, NavigationFailedEventArgs e)
      {
         throw new Exception("Failed to load Page " + e.SourcePageType.FullName);
      }

   }

}