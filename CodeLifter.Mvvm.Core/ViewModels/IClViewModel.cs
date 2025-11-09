using System.ComponentModel;

namespace CodeLifter.Mvvm.ViewModels;

public interface IClViewModel : INotifyPropertyChanged
{
    Task InitializeAsync();
    Task Loaded();
}

