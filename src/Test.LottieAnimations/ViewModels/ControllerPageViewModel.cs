using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Lottie.Forms;
using Xamarin.Forms;

namespace Test.LottieAnimations.ViewModels
{
  public class ControllerPageViewModel : INotifyPropertyChanged
  {
    private string _animationFile;

    private bool _isPlaying;

    public ControllerPageViewModel()
    {
      StartPlayingCommand = new Command(() => IsPlaying = true);
      StopPlayingCommand = new Command(() => IsPlaying = false);

      PlayingCommand = new Command(() => DisplayAlert($"{nameof(AnimationView.PlaybackStartedCommand)} executed!"));
      FinishedCommand = new Command(() => DisplayAlert($"{nameof(AnimationView.PlaybackFinishedCommand)} executed!"));
      GetNextAnimation = new Command(() => DisplayAlert($"{nameof(AnimationView.ClickedCommand)} executed!"));

      AnimationFile = "AniMangoWriting.json";
    }

    public event PropertyChangedEventHandler PropertyChanged;

    public string AnimationFile
    {
      get => _animationFile;
      set
      {
        Set(ref _animationFile, value);
      }
    }

    public ICommand FinishedCommand { get; }

    public ICommand GetNextAnimation { get; }

    public bool IsPlaying
    {
      get => _isPlaying;
      set => Set(ref _isPlaying, value);
    }

    public ICommand PlayingCommand { get; }

    public ICommand StartPlayingCommand { get; }

    public ICommand StopPlayingCommand { get; }

    private void DisplayAlert(string message) => Application.Current.MainPage.DisplayAlert(string.Empty, message, "OK");

    private bool Set<T>(ref T field, T value, [CallerMemberName]string propertyName = null)
    {
      if (Equals(field, value)) return false;

      field = value;
      PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
      return true;
    }
  }
}