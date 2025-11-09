# CodeLifter.MVVM.Maui

MVVM components for pure MAUI (XAML) applications using the CodeLifter platform.

> **Note**: For MAUI Blazor Hybrid applications, use **CodeLifter.MVVM.Maui.Blazor** instead.

## Installation

```bash
dotnet add package CodeLifter.MVVM.Maui
```

## Features

- **ClContentPageBase<TViewModel>**: Base class for MAUI ContentPage with ViewModel binding
- Automatic ViewModel initialization on page appearing
- Property change notifications
- Full support for MAUI data binding

## Usage

### Creating a MAUI Page with ViewModel

```csharp
using CodeLifter.Mvvm.Pages;

public partial class MyPage : ClContentPageBase<MyViewModel>
{
    public MyPage(MyViewModel viewModel) : base(viewModel)
    {
        InitializeComponent();
    }
}
```

### XAML Example

```xml
<pages:ClContentPageBase xmlns="http://schemas.microsoft.com/dotnet/2021/maui"
                         xmlns:x="http://schemas.microsoft.com/winfx/2009/xaml"
                         xmlns:pages="clr-namespace:CodeLifter.Mvvm.Pages;assembly=CodeLifter.Mvvm.Maui"
                         x:Class="MyApp.MyPage">
    <StackLayout>
        <Label Text="{Binding Title}" />
        <Button Text="Click Me" Command="{Binding DoSomethingCommand}" />
    </StackLayout>
</pages:ClContentPageBase>
```

### Registering ViewModels

In your `MauiProgram.cs`:

```csharp
builder.Services.AddTransient<MyViewModel>();
builder.Services.AddTransient<MyPage>();
```

## Dependencies

- **CodeLifter.MVVM.Core** - Core ViewModels and abstractions
- **Microsoft.Maui.Controls** - MAUI framework

## Platform Support

This package supports:
- ✅ iOS
- ✅ Android
- ✅ macOS (Catalyst)
- ✅ Windows

## Related Packages

- **CodeLifter.MVVM.Core** - Core MVVM abstractions and ViewModels
- **CodeLifter.MVVM.Maui.Blazor** - MVVM components for MAUI Blazor Hybrid applications
- **CodeLifter.MVVM** - MVVM components for Blazor Server applications
- **CodeLifter.MVVM.WebAssembly** - MVVM components for Blazor WebAssembly applications

## License

MIT

