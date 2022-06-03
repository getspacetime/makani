[![Build](https://github.com/getspacetime/makani/actions/workflows/build.yml/badge.svg)](https://github.com/getspacetime/makani/actions/workflows/build.yml)
![nuget](https://img.shields.io/nuget/dt/makani)
![nuget](https://img.shields.io/nuget/vpre/makani)

# 🏖️ makani
Collection of UI components built specifically for .NET MAUI Blazor

## Why Makani?
Makani was born based on the need for lightweight, performant, and customizable UI components for .NET MAUI Blazor. Makani is built on the wonderful CSS framework, [Tailwind CSS](https://tailwindcss.com/). While a simple theme will be included, the hope is that the community is able to customize the theme to fit their needs. 

The main focus of the Makani library is to provide a powerful set of components that work flawlessly with .NET MAUI Blazor.

## 🏗️ Design Principles
- Built first and foremost for .NET MAUI Blazor
- Components should be easy to customize
- Components should be composable, extensible, and performant
- Always listen to the community

> ⚠️ **This library is currently under active development.** You may experience bugs, breaking changes, or missing functionality.

## 🚀 Getting Started

### Quick Start

**1. Install via NuGet**

```
dotnet add package Makani
```

**2. Update your `_Imports.razor`**

```razor
@using Makani
```

**3. Add Makani**
```csharp
builder.Services.AddMakani();
```

**4. Build away!**
```razor
<MkButton Color="MkColor.Primary">Hello world!</MkButton>
```

### Using Syntax Highlighting
The syntax highlighting component is an optional feature. If you don't need this feature, skip this section and avoid loading the additional resources.

Makani is using [Prism](https://prismjs.com/) for syntax highlighting, so if you need this component, a few more steps are needed. 

In your `index.html`, add **only one** of the following themes to the `<head>...</head>` section:
```html
<!-- vscode-dark-plus is the one used in the Makani docs -->
<link href="_content/Makani/css/vscode-dark-plus.css" rel="stylesheet" />

<!--<link href="_content/Makani/css/atom-dark.css" rel="stylesheet" />
<link href="_content/Makani/css/coy.css" rel="stylesheet" />
<link href="_content/Makani/css/okaidia.css" rel="stylesheet" />
<link href="_content/Makani/css/tomorrow-night.css" rel="stylesheet" />-->
```

Add the following JS to the end of the `<body>...</body>` section:
```html
<script src="_content/Makani/prism.js"></script>
```

## 📖 Documentation

[Extensible Design Documentation](https://github.com/getspacetime/makani/wiki/Extensible-Design)

[View All Components](https://github.com/getspacetime/makani/wiki/Makani-UI-Components)

[Live Documentation](https://getspacetime.github.io/makani/)

## Performance / Benchmarks
Providing a **lightweight** and **performant** component library is a major goal of this project. Without benchmarks or tracking, this is more of a wish and not a real goal.

We will track performance and benchmarks as below:

1. Makani DLL Size
2. RAM Usage
3. CPU Usage
4. Time to Interactive
5. First Input Delay
6. Total Blocking Time
7. Cumulative Layout Shift
8. First Contentful Paint

| Area | Target | Actual | Passing
| --- | --- | --- | --- |
| DLL Size | | | |
| RAM Usage | | | |
| CPU Usage | | | |
| Time to Interactive | | | |
| First Input Delay | | | |
| Total Blocking Time | | | |
| Cumulative Layout Shift | | | |
| First Contentful Paint | | | |

**Sources**
- https://blog.openreplay.com/top-metrics-you-need-to-understand-when-measuring-front-end-performance
- https://developer.mozilla.org/en-US/docs/Learn/Performance/Measuring_performance
