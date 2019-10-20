using System.ComponentModel;
using Xamarin.Forms;

namespace Test.LottieAnimations.Views
{
  // Learn more about making custom code visible in the Xamarin.Forms previewer
  // by visiting https://aka.ms/xamarinforms-previewer
  [DesignTimeVisible(false)]
  public partial class MainPage : ContentPage
  {
    public MainPage()
    {
      InitializeComponent();

      // TODO: Currently, reverse playback is not supported on tizen backend. Will update when it supports.
      //playSegmentsButton.Clicked += (sender, e) => animationView.PlayProgressSegment(0.65f, (Device.RuntimePlatform != Device.Tizen) ? 0.0f : 1.0f);
      //playFramesButton.Clicked += (sender, e) => animationView.PlayFrameSegment(50, (Device.RuntimePlatform != Device.Tizen) ? 1 : 100);

      // On<Xamarin.Forms.PlatformConfiguration.iOS>().SetUseSafeArea(true);
    }

    private void Slider_OnValueChanged(object sender, ValueChangedEventArgs e)
    {
      animationView.Progress = (float)e.NewValue;
    }

    private void Handle_OnFinish(object sender, System.EventArgs e)
    {
      DisplayAlert(string.Empty, $"{nameof(animationView.OnFinish)} invoked!", "OK");
    }
  }
}