using CodeLifter.Mvvm.ViewModels;
using Microsoft.AspNetCore.Components;

namespace CodeLifter.Mvvm.Components;

/// <summary>
/// Base class for MAUI Blazor Hybrid components with ViewModel binding
/// </summary>
public abstract class ClBlazorComponent<TViewModel> : ComponentBase, IClView<TViewModel>
    where TViewModel : IClViewModel
{
    [Inject]
    public TViewModel VM { get; set; } = default!;

    protected override void OnInitialized()
    {
        // Cause changes to the ViewModel to make Blazor re-render
        VM!.PropertyChanged += (_, _) => InvokeAsync(StateHasChanged);
        base.OnInitialized();
    }

    protected override async Task OnInitializedAsync()
    {
        await VM!.InitializeAsync();

        // Cause changes to the ViewModel to make Blazor re-render
        VM!.PropertyChanged += (_, _) => InvokeAsync(StateHasChanged);
        await base.OnInitializedAsync();
    }
}

// Backward compatibility alias
[Obsolete("Use ClBlazorComponent<TViewModel> instead. This alias will be removed in a future version.")]
public abstract class BlazorComponent<TViewModel> : ClBlazorComponent<TViewModel>
    where TViewModel : IClViewModel
{
}

