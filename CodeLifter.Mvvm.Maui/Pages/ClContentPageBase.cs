using CodeLifter.Mvvm.ViewModels;
using Microsoft.Maui.Controls;

namespace CodeLifter.Mvvm.Pages;

/// <summary>
/// Base class for MAUI ContentPage with ViewModel binding
/// </summary>
public abstract class ClContentPageBase<TViewModel> : ContentPage, Components.IClView<TViewModel>
    where TViewModel : IClViewModel
{
    public TViewModel VM { get; set; } = default!;

    protected ClContentPageBase()
    {
    }

    protected ClContentPageBase(TViewModel viewModel)
    {
        VM = viewModel;
        BindingContext = VM;

        // Subscribe to property changes
        VM.PropertyChanged += (_, _) => OnPropertyChanged(string.Empty);
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();

        if (VM != null)
        {
            await VM.InitializeAsync();
        }
    }
}

// Backward compatibility alias
[Obsolete("Use ClContentPageBase<TViewModel> instead. This alias will be removed in a future version.")]
public abstract class ContentPageBase<TViewModel> : ClContentPageBase<TViewModel>
    where TViewModel : IClViewModel
{
    protected ContentPageBase() : base()
    {
    }

    protected ContentPageBase(TViewModel viewModel) : base(viewModel)
    {
    }
}

