# Laconia.MVVM.Core

Core MVVM abstractions and ViewModels for the Laconia platform. This package contains platform-agnostic base classes and interfaces that work across:

- Blazor Server
- Blazor WebAssembly
- MAUI Blazor Hybrid
- MAUI (standard)

## Features

- **ViewModel**: Base class for ViewModels using CommunityToolkit.Mvvm's `ObservableObject`
- **ValidatorViewModel**: Base class for ViewModels with validation support using `ObservableValidator`
- **RecipientViewModel**: Base class for ViewModels that participate in messaging using `ObservableRecipient`
- **IViewModel**: Core interface for all ViewModels

## Usage

```csharp
using Laconia.MVVM.ViewModels;

public partial class MyViewModel : ViewModel
{
    [ObservableProperty]
    private string _name = string.Empty;

    public override async Task Loaded()
    {
        // Initialize your ViewModel here
        await base.Loaded();
    }
}
```

## Dependencies

This package has minimal dependencies:
- CommunityToolkit.Mvvm - For MVVM infrastructure
- .NET 9.0

No UI framework dependencies, making it suitable for all platforms.

