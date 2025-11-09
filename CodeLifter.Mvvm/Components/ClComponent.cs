using System;

using Microsoft.AspNetCore.Components;

namespace CodeLifter.Mvvm.Components;

public abstract class ClComponent<TViewModel> : ComponentBase, IClView<TViewModel> where TViewModel : IClViewModel
{
    [Inject]
    public TViewModel VM { get; set; } = default!;


    public override async Task SetParametersAsync(ParameterView parameters)
    {
        await base.SetParametersAsync(parameters);
        await VM!.InitializeAsync();
    }

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
[Obsolete("Use ClComponent<TViewModel> instead. This alias will be removed in a future version.")]
public abstract class Component<TViewModel> : ClComponent<TViewModel> where TViewModel : IClViewModel
{
}

[Obsolete("Use ClComponent<TViewModel> instead. This alias will be removed in a future version.")]
public abstract class LaconicComponent<TViewModel> : ClComponent<TViewModel> where TViewModel : IClViewModel
{
}

