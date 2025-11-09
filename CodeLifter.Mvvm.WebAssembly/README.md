# Laconia.MVVM.WebAssembly - Blazor WebAssembly

MVVM components for Blazor WebAssembly applications using the Laconia platform.

## Features

- **Component<TViewModel>**: Base component class for Blazor components with ViewModel binding
- **LayoutComponent<TViewModel>**: Base layout component class with ViewModel support
- **ParameterBoundComponent<TViewModel>**: Component with parameter-bound ViewModel
- **ValidationSummary**: Validation summary component for ObservableValidator ViewModels

## Usage

```csharp
@inherits Component<MyViewModel>

<h1>@VM.Title</h1>
<button @onclick="VM.DoSomethingCommand">Click Me</button>
```

## Dependencies

- Laconia.MVVM.Core - Core ViewModels and abstractions
- Microsoft.AspNetCore.Components.WebAssembly - Blazor WASM components

## Platform Support

This package is specifically for **Blazor WebAssembly** applications. For other platforms, use:
- **Blazor Server**: Laconia.MVVM
- **MAUI/MAUI Blazor**: Laconia.MVVM.Maui

## Features
I'll be implementing the following features that I believe are fundamental to a high-quality web application.  Note that each of these items below are basically just implementing a nice clean config for re-use. They will each come with necessary settings class prefilled where possible with "Sensible Defaults" 
I'll be making improvements over time and I am HIGHLY OPEN to feedback. I like learning too!

| Feature                     | Tooling used           | Nuget       |
|-----------------------------|------------------------|----------------------|
| External Configuration      | `Azure App Config`     | `Laconia.Config`     |
| Structured Logging Console  | `Serilog / Console`    | `Laconia.Logging`    |
| Structured Logging + OTEL   | `Serilog / Jaeger`     | `Laconia.Logging`    |
| SQL Database                | `PostgreSQL`           | `Laconia.Data`       |
| Identity                    | `.Net Identity`        | `Laconia.Identity`   |
| Free Distributed Caching    | `.Net in memory cache` |                      |
| Premium Distributed Caching | `Redis`                | `Laconia.Caching`    |
| Free Document Database      | `Marten`               | `Laconia.NoSql`      |
| Premium Document Database   | `Marten`               | `Laconia.NoSql`      |
| Background Workers          | `HangFire`             | `Laconia.Background` |
| Free Document Database      | `Marten`               | `Laconia.NoSql`      |
| Free Document Database      | `Marten`               | `Laconia.NoSql`      |
| Blazor Server               | `MudBlazor`            | `MudBlazor`          |


### * Laconia's name was taken from the wonderful 'The Expanse' book series. It is also the location of a historical place of government in Greece.