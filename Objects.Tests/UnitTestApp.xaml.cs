using System;
using Windows.ApplicationModel;
using Windows.ApplicationModel.Activation;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using Microsoft.VisualStudio.TestPlatform.TestExecutor;

namespace Objects.Tests
{

   public sealed partial class App : Application
   {

      public App()
      {
         InitializeComponent();
         Suspending += OnSuspending;
      }

      protected override void OnLaunched(LaunchActivatedEventArgs e)
      {
         var rootFrame = Window.Current.Content as Frame;
         if (rootFrame == null)
         {
            rootFrame = new Frame();
            rootFrame.NavigationFailed += OnNavigationFailed;
            Window.Current.Content = rootFrame;
         }

         UnitTestClient.CreateDefaultUI();

         Window.Current.Activate();

         UnitTestClient.Run(e.Arguments);
      }

      private void OnNavigationFailed(object sender, NavigationFailedEventArgs e)
      {
         throw new Exception("Failed to load Page " + e.SourcePageType.FullName);
      }

      private void OnSuspending(object sender, SuspendingEventArgs e)
      {
         var deferral = e.SuspendingOperation.GetDeferral();
         //TODO: Save application state and stop any background activity
         deferral.Complete();
      }

   }

}