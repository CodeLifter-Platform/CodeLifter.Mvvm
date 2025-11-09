using CodeLifter.Mvvm.ViewModels;

namespace CodeLifter.Mvvm.Maui.Blazor.Components;

/// <summary>
/// Interface for views that are bound to a ViewModel
/// </summary>
public interface IClView<TViewModel> where TViewModel : IClViewModel
{
    TViewModel VM { get; set; }
}

