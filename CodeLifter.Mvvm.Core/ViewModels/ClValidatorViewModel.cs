using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace CodeLifter.Mvvm.ViewModels;

public abstract partial class ClValidatorViewModel : ObservableValidator, IClViewModel
{
    public virtual async Task InitializeAsync()
        => await Loaded().ConfigureAwait(true);

    protected virtual void NotifyStateChanged() => OnPropertyChanged((string?)null);

    [RelayCommand]
    public virtual async Task Loaded()
        => await Task.CompletedTask.ConfigureAwait(false);
}

