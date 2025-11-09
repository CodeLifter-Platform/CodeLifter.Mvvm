# Laconia.MVVM.Maui

MVVM components for MAUI and MAUI Blazor Hybrid applications using the Laconia platform.

## Features

### For Standard MAUI Applications
- **ContentPageBase<TViewModel>**: Base class for MAUI ContentPage with ViewModel binding
- Automatic ViewModel initialization on page appearing
- Property change notifications

### For MAUI Blazor Hybrid Applications
- **BlazorComponent<TViewModel>**: Base component class for Blazor components in MAUI Hybrid apps
- Automatic state management and re-rendering

## Usage

### Standard MAUI (XAML)

```csharp
using Laconia.MVVM.Pages;

public partial class MyPage : ContentPageBase<MyViewModel>
{
    public MyPage(MyViewModel viewModel) : base(viewModel)
    {
        InitializeComponent();
    }
}
```

In your XAML:
```xml
<pages:ContentPageBase xmlns="http://schemas.microsoft.com/dotnet/2021/maui"
                       xmlns:x="http://schemas.microsoft.com/winfx/2009/xaml"
                       xmlns:pages="clr-namespace:Laconia.MVVM.Pages;assembly=Laconia.Mvvm.Maui"
                       x:Class="MyApp.MyPage">
    <Label Text="{Binding Title}" />
</pages:ContentPageBase>
```

### MAUI Blazor Hybrid

```csharp
@using Laconia.MVVM.Components
@inherits BlazorComponent<MyViewModel>

<h1>@VM.Title</h1>
<button @onclick="VM.DoSomethingCommand">Click Me</button>
```

## Dependencies

- Laconia.MVVM.Core - Core ViewModels and abstractions
- Microsoft.Maui.Controls - MAUI framework

## Platform Support

This package supports:
- ✅ MAUI (iOS, Android, macOS, Windows)
- ✅ MAUI Blazor Hybrid

For web-only Blazor applications, use:
- **Blazor Server**: Laconia.MVVM
- **Blazor WebAssembly**: Laconia.MVVM.WebAssembly

