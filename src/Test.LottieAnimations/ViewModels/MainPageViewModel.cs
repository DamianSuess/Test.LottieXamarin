using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Xamarin.Forms;

namespace Test.LottieAnimations.ViewModels
{
  public class MainPageViewModel : INotifyPropertyChanged
  {
    private readonly List<string> _fileList = new List<string>
    {
      "1735-animated-indonesian-first-president",
      "4461-love-as-energy-charge",
      "4767-love",
      "4770-lady-and-dove",
      "5787-love-heart-uiux-icon-animation",
      "6074-like-heart",
      "AniCheckmark",
      // "AniLoadingSkullBlueBg-(3490dc)",
      // "AniMangoWriting",
    };

    private string _animationFile;
    private int _currentIndex = 0;
    private bool _isPlaying;

    public MainPageViewModel()
    {
      AnimationFile = "AniMangoWriting.json";

      GetNextAnimation = new Command(() =>
      {
        var name = _fileList[_currentIndex];

        AnimationFile = $"{name}.json";
        ++_currentIndex;

        if (_currentIndex >= _fileList.Count)
          _currentIndex = 0;
      });
    }

    public event PropertyChangedEventHandler PropertyChanged;

    public string AnimationFile
    {
      get => _animationFile;
      set => Set(ref _animationFile, value);
    }

    public ICommand GetNextAnimation { get; }

    public bool IsPlaying
    {
      get => _isPlaying;
      set => Set(ref _isPlaying, value);
    }

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