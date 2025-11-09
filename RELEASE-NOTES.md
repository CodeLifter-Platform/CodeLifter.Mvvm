# Release Notes

## Version 1.0.1-beta (2025-11-09)

### 🎉 New Package: CodeLifter.MVVM.Maui.Blazor

We've separated MAUI support into two distinct packages to better serve different use cases:

#### New Package
- **CodeLifter.MVVM.Maui.Blazor** - Dedicated package for MAUI Blazor Hybrid applications
  - `ClComponent<TViewModel>` - Base component for Blazor components in MAUI
  - `ClLayoutComponent<TViewModel>` - Base layout component with ViewModel binding
  - `IClView<TViewModel>` - View interface for type-safe ViewModel binding
  - Full multi-platform support (iOS, Android, macOS, Windows)
  - Uses the same component patterns as Blazor Server/WebAssembly

#### Updated Packages
- **CodeLifter.MVVM.Maui** - Now focused exclusively on pure MAUI XAML applications
  - Removed Blazor Hybrid components (moved to CodeLifter.MVVM.Maui.Blazor)
  - Changed SDK from `Microsoft.NET.Sdk.Razor` to `Microsoft.NET.Sdk`
  - Removed dependency on `Microsoft.AspNetCore.Components.WebView.Maui`
  - Updated description and documentation to clarify XAML-only focus
  - Contains `ClContentPageBase<TViewModel>` for XAML pages

- **CodeLifter.MVVM.Core** - Updated to version 1.0.1-beta
- **CodeLifter.MVVM** - Updated to version 1.0.1-beta
- **CodeLifter.MVVM.WebAssembly** - Updated to version 1.0.1-beta

### 📦 Migration Guide

If you're using **MAUI Blazor Hybrid** applications:
```bash
# Remove the old package
dotnet remove package CodeLifter.MVVM.Maui

# Add the new Blazor Hybrid package
dotnet add package CodeLifter.MVVM.Maui.Blazor
```

Update your using statements:
```csharp
// Old
using CodeLifter.Mvvm.Maui.Components;

// New
using CodeLifter.Mvvm.Maui.Blazor.Components;
```

If you're using **pure MAUI XAML** applications:
- No changes needed! Continue using `CodeLifter.MVVM.Maui`
- Your existing code will work without modifications

### 🐛 Bug Fixes
- Fixed namespace inconsistencies across projects
- Improved package metadata and descriptions

### 📚 Documentation
- Updated README with clear package selection guidance
- Added "Choosing the Right Package" comparison table
- Added NuGet badges for all packages
- Updated architecture diagrams to reflect new structure
- Added comprehensive examples for all platforms

---

## Version 1.0.0-beta (2025-11-09)

### 🎉 Initial Release

First beta release of the CodeLifter.MVVM framework!

#### Packages Released
- **CodeLifter.MVVM.Core** (1.0.0-beta)
  - `ClViewModel` - Base ViewModel with `ObservableObject`
  - `ClValidatorViewModel` - ViewModel with validation support
  - `ClRecipientViewModel` - ViewModel with messaging support
  - `IClViewModel` - Common interface for all ViewModels

- **CodeLifter.MVVM** (1.0.0-beta)
  - Blazor Server components
  - `ClComponent<TViewModel>` - Base component
  - `ClLayoutComponent<TViewModel>` - Layout component
  - `ClParameterBoundComponent<TViewModel>` - Parameter-bound component
  - `ClValidationSummary` - Validation summary component

- **CodeLifter.MVVM.WebAssembly** (1.0.0-beta)
  - Blazor WebAssembly components
  - Same component structure as Blazor Server
  - Optimized for client-side execution

- **CodeLifter.MVVM.Maui** (1.0.0-beta)
  - .NET MAUI support for mobile and desktop
  - `ClContentPageBase<TViewModel>` - Base page for MAUI
  - `ClBlazorComponent<TViewModel>` - Blazor Hybrid component
  - Multi-platform support (iOS, Android, macOS, Windows)

### ✨ Features
- Multi-platform MVVM support across Blazor and MAUI
- Built on CommunityToolkit.Mvvm for high performance
- Type-safe ViewModel binding with compile-time safety
- Validation support using Data Annotations
- Messaging support for inter-component communication
- Consistent API across all platforms
- .NET 9.0 support

### 🎯 Target Frameworks
- .NET 9.0 for all Blazor packages
- .NET 9.0 with platform-specific targets for MAUI (Android, iOS, macOS, Windows)

### 📚 Documentation
- Comprehensive README with examples
- Quick start guides for each platform
- Architecture documentation
- Validation and messaging examples

---

## Upcoming Features

We're planning the following features for future releases:

- [ ] Navigation services for MAUI and Blazor
- [ ] State management helpers
- [ ] Advanced validation scenarios
- [ ] Unit testing utilities
- [ ] Sample applications for each platform
- [ ] Performance optimizations
- [ ] Additional component base classes

---

## Support

For issues, questions, or contributions:
- GitHub Issues: [Report an issue](https://github.com/CodeLifter/CodeLifter.Mvvm/issues)
- Documentation: See README.md
- NuGet: [Browse packages](https://www.nuget.org/packages?q=CodeLifter.MVVM)

---

**CodeLifter.MVVM** - Modern MVVM for Modern .NET 🚀

