# CodeLifter.MVVM.Maui.Blazor

MVVM components for MAUI Blazor Hybrid applications using the CodeLifter platform.

## Overview

This package provides base components for building MAUI Blazor Hybrid applications with the MVVM pattern. It includes:

- **ClComponent<TViewModel>** - Base class for Blazor components with ViewModel binding
- **ClLayoutComponent<TViewModel>** - Base class for Blazor layout components with ViewModel binding

## Installation

```bash
dotnet add package CodeLifter.MVVM.Maui.Blazor
```

## Usage

### Creating a Blazor Component in MAUI

```csharp
@inherits ClComponent<MyViewModel>

<h3>@VM.Title</h3>
<p>@VM.Description</p>

<button @onclick="VM.DoSomethingCommand">Click Me</button>

@code {
    // Component code here
}
```

### Registering ViewModels

In your `MauiProgram.cs`:

```csharp
builder.Services.AddTransient<MyViewModel>();
```

## Features

- Automatic ViewModel initialization
- Automatic UI updates when ViewModel properties change
- Dependency injection support
- Works seamlessly with MAUI Blazor Hybrid apps

## Related Packages

- **CodeLifter.MVVM.Core** - Core MVVM abstractions and ViewModels
- **CodeLifter.MVVM.Maui** - MVVM components for pure MAUI (XAML) applications
- **CodeLifter.MVVM** - MVVM components for Blazor Server applications
- **CodeLifter.MVVM.WebAssembly** - MVVM components for Blazor WebAssembly applications

## License

MIT

