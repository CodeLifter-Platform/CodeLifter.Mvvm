using System;
using Microsoft.AspNetCore.Components;

namespace CodeLifter.Mvvm.Components
{
	public class ClParameterBoundComponent<TViewModel> : ComponentBase, IClView<TViewModel> where TViewModel : IClViewModel
    {
        [Parameter]
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

    // Backward compatibility aliases
    [Obsolete("Use ClParameterBoundComponent<TViewModel> instead. This alias will be removed in a future version.")]
    public class ParameterBoundComponent<TViewModel> : ClParameterBoundComponent<TViewModel> where TViewModel : IClViewModel
    {
    }

    [Obsolete("Use ClParameterBoundComponent<TViewModel> instead. This alias will be removed in a future version.")]
    public class LaconicParameterBoundComponent<TViewModel> : ClParameterBoundComponent<TViewModel> where TViewModel : IClViewModel
    {
    }
}

