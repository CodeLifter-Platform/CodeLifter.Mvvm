# CodeLifter.Mvvm

A modern, cross-platform MVVM framework for .NET 9+ applications, supporting Blazor Server, Blazor WebAssembly, .NET MAUI, and MAUI Blazor Hybrid.

📋 **[View Release Notes](RELEASE-NOTES.md)** | 📦 **[Browse NuGet Packages](https://www.nuget.org/packages?q=CodeLifter.MVVM)**

## ✨ What's New in 1.0.1-beta

🎉 **New Package**: **CodeLifter.MVVM.Maui.Blazor** - Dedicated support for MAUI Blazor Hybrid applications!

We've separated MAUI support into two packages:
- **CodeLifter.MVVM.Maui** - For pure MAUI XAML applications
- **CodeLifter.MVVM.Maui.Blazor** ✨ NEW - For MAUI Blazor Hybrid applications

This separation provides better clarity and removes unnecessary dependencies for each use case. See [Release Notes](RELEASE-NOTES.md) for migration details.

## 🚀 Features

- **Multi-Platform Support**: Works seamlessly across Blazor Server, Blazor WebAssembly, .NET MAUI (XAML), and MAUI Blazor Hybrid
- **Built on CommunityToolkit.Mvvm**: Leverages the power of source generators for high-performance MVVM
- **Type-Safe ViewModels**: Strongly-typed ViewModel binding with compile-time safety
- **Validation Support**: Built-in validation using `ClValidatorViewModel`
- **Messaging Support**: Inter-component communication with `ClRecipientViewModel`
- **Consistent API**: Same MVVM patterns across all platforms
- **Separate Packages**: Dedicated packages for pure MAUI and MAUI Blazor Hybrid scenarios

## 📦 Packages

### CodeLifter.MVVM.Core
[![NuGet](https://img.shields.io/nuget/v/CodeLifter.MVVM.Core.svg)](https://www.nuget.org/packages/CodeLifter.MVVM.Core/)

Platform-agnostic core library containing base ViewModels:
- `ClViewModel` - Base ViewModel with `ObservableObject`
- `ClValidatorViewModel` - ViewModel with validation support using `ObservableValidator`
- `ClRecipientViewModel` - ViewModel with messaging support using `ObservableRecipient`
- `IClViewModel` - Common interface for all ViewModels

### CodeLifter.MVVM
[![NuGet](https://img.shields.io/nuget/v/CodeLifter.MVVM.svg)](https://www.nuget.org/packages/CodeLifter.MVVM/)

Blazor Server components and base classes:
- `ClComponent<TViewModel>` - Base component for Blazor Server
- `ClLayoutComponent<TViewModel>` - Layout component with ViewModel binding
- `ClParameterBoundComponent<TViewModel>` - Component with parameter binding
- `ClValidationSummary` - Validation summary component

### CodeLifter.MVVM.WebAssembly
[![NuGet](https://img.shields.io/nuget/v/CodeLifter.MVVM.WebAssembly.svg)](https://www.nuget.org/packages/CodeLifter.MVVM.WebAssembly/)

Blazor WebAssembly-specific components:
- Same component structure as Blazor Server
- Optimized for client-side execution

### CodeLifter.MVVM.Maui
[![NuGet](https://img.shields.io/nuget/v/CodeLifter.MVVM.Maui.svg)](https://www.nuget.org/packages/CodeLifter.MVVM.Maui/)

.NET MAUI support for pure XAML applications:
- `ClContentPageBase<TViewModel>` - Base page for MAUI XAML applications
- Support for iOS, Android, macOS, and Windows
- For MAUI Blazor Hybrid apps, use **CodeLifter.MVVM.Maui.Blazor** instead

### CodeLifter.MVVM.Maui.Blazor ✨ NEW
[![NuGet](https://img.shields.io/nuget/v/CodeLifter.MVVM.Maui.Blazor.svg)](https://www.nuget.org/packages/CodeLifter.MVVM.Maui.Blazor/)

MAUI Blazor Hybrid support for mobile and desktop:
- `ClComponent<TViewModel>` - Base component for MAUI Blazor Hybrid
- `ClLayoutComponent<TViewModel>` - Layout component with ViewModel binding
- Support for iOS, Android, macOS, and Windows
- Uses the same component patterns as Blazor Server/WebAssembly

## 📋 Choosing the Right Package

| Scenario | Package | Use When |
|----------|---------|----------|
| Blazor Server App | `CodeLifter.MVVM` | Building server-side Blazor applications |
| Blazor WebAssembly App | `CodeLifter.MVVM.WebAssembly` | Building client-side Blazor applications |
| MAUI XAML App | `CodeLifter.MVVM.Maui` | Building native mobile/desktop apps with XAML UI |
| MAUI Blazor Hybrid App | `CodeLifter.MVVM.Maui.Blazor` | Building native apps with Blazor UI components |

> **Note**: All packages require `CodeLifter.MVVM.Core` which is automatically included as a dependency.

## 🎯 Quick Start

### 1. Install the Package

```bash
# For Blazor Server
dotnet add package CodeLifter.MVVM

# For Blazor WebAssembly
dotnet add package CodeLifter.MVVM.WebAssembly

# For .NET MAUI (XAML)
dotnet add package CodeLifter.MVVM.Maui

# For .NET MAUI Blazor Hybrid
dotnet add package CodeLifter.MVVM.Maui.Blazor
```

### 2. Create a ViewModel

```csharp
using CodeLifter.Mvvm.ViewModels;
using CommunityToolkit.Mvvm.Input;

public partial class MyViewModel : ClViewModel
{
    private string _message = "Hello, CodeLifter!";
    
    public string Message
    {
        get => _message;
        set => SetProperty(ref _message, value);
    }
    
    [RelayCommand]
    private void UpdateMessage()
    {
        Message = "Updated!";
    }
}
```

### 3. Create a Component (Blazor)

```razor
@inherits ClComponent<MyViewModel>

<h1>@VM.Message</h1>
<button @onclick="VM.UpdateMessageCommand.Execute">Update</button>

@code {
    protected override async Task OnInitializedAsync()
    {
        await VM.InitializeAsync();
    }
}
```

### 4. Create a Page (MAUI XAML)

```csharp
using CodeLifter.Mvvm.Pages;

public class MyPage : ClContentPageBase<MyViewModel>
{
    public MyPage(MyViewModel viewModel) : base(viewModel)
    {
        InitializeComponent();

        // ViewModel is automatically bound to BindingContext
    }
}
```

### 5. Create a Component (MAUI Blazor Hybrid)

```razor
@using CodeLifter.Mvvm.Maui.Blazor.Components
@inherits ClComponent<MyViewModel>

<h1>@VM.Message</h1>
<button @onclick="VM.UpdateMessageCommand.Execute">Update</button>

@code {
    // ViewModel is automatically injected and initialized
}
```

## 🏗️ Architecture

```
CodeLifter.Mvvm.Core (Platform-Agnostic)
    ├── ViewModels
    │   ├── IClViewModel
    │   ├── ClViewModel
    │   ├── ClValidatorViewModel
    │   └── ClRecipientViewModel
    │
    ├── CodeLifter.Mvvm (Blazor Server)
    │   └── Components
    │       ├── ClComponent<TViewModel>
    │       ├── ClLayoutComponent<TViewModel>
    │       ├── ClParameterBoundComponent<TViewModel>
    │       └── ClValidationSummary
    │
    ├── CodeLifter.Mvvm.WebAssembly (Blazor WASM)
    │   └── Components (Same as Blazor Server)
    │
    ├── CodeLifter.Mvvm.Maui (.NET MAUI - XAML)
    │   └── Pages
    │       └── ClContentPageBase<TViewModel>
    │
    └── CodeLifter.Mvvm.Maui.Blazor (MAUI Blazor Hybrid)
        └── Components
            ├── ClComponent<TViewModel>
            └── ClLayoutComponent<TViewModel>
```

## 🔧 Building

```bash
# Build all projects
dotnet build CodeLifter.Mvvm.sln

# Build specific project
dotnet build CodeLifter.Mvvm.Core/CodeLifter.Mvvm.Core.csproj
```

## 📝 Naming Convention

All classes use the `Cl` prefix (CodeLifter) to avoid naming conflicts:
- `ClViewModel` instead of `ViewModel`
- `ClComponent` instead of `Component`
- `ClValidationSummary` instead of `ValidationSummary`

## 🎨 Validation Example

```csharp
using CodeLifter.Mvvm.ViewModels;
using System.ComponentModel.DataAnnotations;

public partial class LoginViewModel : ClValidatorViewModel
{
    [Required]
    [EmailAddress]
    private string _email = "";
    
    public string Email
    {
        get => _email;
        set => SetProperty(ref _email, value, true); // true = validate
    }
    
    [Required]
    [MinLength(8)]
    private string _password = "";
    
    public string Password
    {
        get => _password;
        set => SetProperty(ref _password, value, true);
    }
}
```

## 📡 Messaging Example

```csharp
using CodeLifter.Mvvm.ViewModels;
using CommunityToolkit.Mvvm.Messaging;

public class UserLoggedInMessage
{
    public string Username { get; set; }
}

public partial class LoginViewModel : ClRecipientViewModel<UserLoggedInMessage>
{
    public override void Receive(UserLoggedInMessage message)
    {
        // Handle the message
        Console.WriteLine($"User logged in: {message.Username}");
    }
}
```

## 📚 Documentation

- **[Release Notes](RELEASE-NOTES.md)** - Version history and migration guides
- **[NuGet Packages](https://www.nuget.org/packages?q=CodeLifter.MVVM)** - Browse all packages
- **README.md** - This file (getting started guide)

## 🤝 Contributing

This is part of the CodeLifter Platform. For contributions, please follow the standard pull request process.

## 📄 License

See LICENSE.txt for details.

## 🔗 Dependencies

- .NET 9.0+
- CommunityToolkit.Mvvm 8.3.2+
- Microsoft.AspNetCore.Components (for Blazor projects)
- Microsoft.Maui.Controls (for MAUI projects)
- Microsoft.AspNetCore.Components.WebView.Maui (for MAUI Blazor Hybrid)

## 🎯 Target Frameworks

- **CodeLifter.MVVM.Core**: net9.0
- **CodeLifter.MVVM**: net9.0
- **CodeLifter.MVVM.WebAssembly**: net9.0
- **CodeLifter.MVVM.Maui**: net9.0, net9.0-android, net9.0-ios, net9.0-maccatalyst, net9.0-windows
- **CodeLifter.MVVM.Maui.Blazor**: net9.0, net9.0-android, net9.0-ios, net9.0-maccatalyst, net9.0-windows

---

**CodeLifter.Mvvm** - Modern MVVM for Modern .NET 🚀

