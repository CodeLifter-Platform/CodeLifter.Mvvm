using CodeLifter.Mvvm.ViewModels;
using Microsoft.AspNetCore.Components;

namespace CodeLifter.Mvvm.Maui.Blazor.Components;

/// <summary>
/// Base class for MAUI Blazor Hybrid layout components with ViewModel binding
/// </summary>
public abstract class ClLayoutComponent<TViewModel> : LayoutComponentBase, IClView<TViewModel>
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

