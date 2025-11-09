using Microsoft.AspNetCore.Components;

namespace CodeLifter.Mvvm.Components;

public abstract class ClLayoutComponent<TViewModel> : LayoutComponentBase, IClView<TViewModel> where TViewModel : IClViewModel
{
    [Inject]
    protected TViewModel VM { get; set; } = default!;

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

// Backward compatibility aliases
[Obsolete("Use ClLayoutComponent<TViewModel> instead. This alias will be removed in a future version.")]
public abstract class LayoutComponent<TViewModel> : ClLayoutComponent<TViewModel> where TViewModel : IClViewModel
{
}

[Obsolete("Use ClLayoutComponent<TViewModel> instead. This alias will be removed in a future version.")]
public abstract class LaconicLayoutComponent<TViewModel> : ClLayoutComponent<TViewModel> where TViewModel : IClViewModel
{
}