using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;

namespace CodeLifter.Mvvm.ViewModels;

public abstract partial class ClRecipientViewModel : ObservableRecipient, IClViewModel
{
    public virtual async Task InitializeAsync()
    {
        await Loaded().ConfigureAwait(true);
    }

    protected virtual void NotifyStateChanged() => OnPropertyChanged((string?)null);

    [RelayCommand]
    public virtual async Task Loaded()
        => await Task.CompletedTask.ConfigureAwait(false);
}

public abstract partial class ClRecipientViewModel<TMessage> : ClRecipientViewModel, IRecipient<TMessage>
    where TMessage : class
{
    public abstract void Receive(TMessage message);
}

