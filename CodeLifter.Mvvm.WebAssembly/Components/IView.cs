using System;
using CodeLifter.Mvvm.ViewModels;

namespace CodeLifter.Mvvm.Components;

// differentiate View (Page) from ViewModel for MvvmNavigationManager auto-detection
public interface IClView<out TViewModel> : IClView
    where TViewModel : IClViewModel
{
    // Skip
}

public interface IClView
{
    // Skip
}
