# CodeLifter.Mvvm

A modern, cross-platform MVVM framework for .NET 9+ applications, supporting Blazor Server, Blazor WebAssembly, and .NET MAUI.

## 🚀 Features

- **Multi-Platform Support**: Works seamlessly across Blazor Server, Blazor WebAssembly, and .NET MAUI (iOS, Android, macOS, Windows)
- **Built on CommunityToolkit.Mvvm**: Leverages the power of source generators for high-performance MVVM
- **Type-Safe ViewModels**: Strongly-typed ViewModel binding with compile-time safety
- **Validation Support**: Built-in validation using `ClValidatorViewModel`
- **Messaging Support**: Inter-component communication with `ClRecipientViewModel`
- **Consistent API**: Same MVVM patterns across all platforms

## 📦 Projects

### CodeLifter.Mvvm.Core
Platform-agnostic core library containing base ViewModels:
- `ClViewModel` - Base ViewModel with `ObservableObject`
- `ClValidatorViewModel` - ViewModel with validation support using `ObservableValidator`
- `ClRecipientViewModel` - ViewModel with messaging support using `ObservableRecipient`
- `IClViewModel` - Common interface for all ViewModels

### CodeLifter.Mvvm
Blazor Server components and base classes:
- `ClComponent<TViewModel>` - Base component for Blazor Server
- `ClLayoutComponent<TViewModel>` - Layout component with ViewModel binding
- `ClParameterBoundComponent<TViewModel>` - Component with parameter binding
- `ClValidationSummary` - Validation summary component

### CodeLifter.Mvvm.WebAssembly
Blazor WebAssembly-specific components:
- Same component structure as Blazor Server
- Optimized for client-side execution

### CodeLifter.Mvvm.Maui
.NET MAUI support for mobile and desktop:
- `ClContentPageBase<TViewModel>` - Base page for MAUI applications
- `ClBlazorComponent<TViewModel>` - Blazor Hybrid component for MAUI
- Support for iOS, Android, macOS, and Windows

## 🎯 Quick Start

### 1. Install the Package

```bash
# For Blazor Server
dotnet add package CodeLifter.Mvvm

# For Blazor WebAssembly
dotnet add package CodeLifter.Mvvm.WebAssembly

# For .NET MAUI
dotnet add package CodeLifter.Mvvm.Maui
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

### 4. Create a Page (MAUI)

```csharp
using CodeLifter.Mvvm.Pages;

public class MyPage : ClContentPageBase<MyViewModel>
{
    public MyPage()
    {
        Content = new StackLayout
        {
            Children =
            {
                new Label { Text = "Hello from MAUI!" }
            }
        };
    }
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
    └── CodeLifter.Mvvm.Maui (.NET MAUI)
        ├── Pages
        │   └── ClContentPageBase<TViewModel>
        └── Components
            └── ClBlazorComponent<TViewModel>
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

## 🤝 Contributing

This is part of the CodeLifter Platform. For contributions, please follow the standard pull request process.

## 📄 License

See LICENSE.txt for details.

## 🔗 Dependencies

- .NET 9.0+
- CommunityToolkit.Mvvm 8.3.2+
- Microsoft.AspNetCore.Components (for Blazor projects)
- Microsoft.Maui.Controls (for MAUI projects)

## 🎯 Target Frameworks

- **CodeLifter.Mvvm.Core**: net9.0
- **CodeLifter.Mvvm**: net9.0
- **CodeLifter.Mvvm.WebAssembly**: net9.0
- **CodeLifter.Mvvm.Maui**: net9.0, net9.0-android, net9.0-ios, net9.0-maccatalyst

---

**CodeLifter.Mvvm** - Modern MVVM for Modern .NET 🚀

