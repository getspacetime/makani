[![Build](https://github.com/getspacetime/makani/actions/workflows/build.yml/badge.svg)](https://github.com/getspacetime/makani/actions/workflows/build.yml)
![nuget](https://img.shields.io/nuget/dt/makani)
![nuget](https://img.shields.io/nuget/vpre/makani)
<sup>[Discord](https://discord.gg/PeBbYy6WKq)</sup>

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

### Further Customization with Tailwind

At the core of this library is the ability to customize components using Tailwind CSS. For further customization, extra steps are required:

1. Install the Tailwind CLI

In the `wwwroot` of your application, follow the [Tailwind CLI installation](https://tailwindcss.com/docs/installation)

2. Configure `.razor` and your `index.html` files in `tailwind.config.js`

**Example**
```js
module.exports = {
  content: ["../**/*.razor", "../*.razor", "index.html"],
  theme: {
    extend: {},
  },
  plugins: [],
}
```

3. Update your `.csproj` file to run the Tailwind CLI

**Example**
```
<Target Name="NpmInstall" BeforeTargets="BeforeBuild">
    <Exec WorkingDirectory="wwwroot" Command="npm install" />
</Target>

<Target Name="Tailwind" DependsOnTargets="NpmInstall" BeforeTargets="Build">
    <Exec WorkingDirectory="wwwroot" Command="npx tailwindcss -i app.css -o ./dist/styles.css" />
</Target>
```

4. Add the CSS to your `index.html`

```html
<head>
    <link href="dist/styles.css" rel="stylesheet" />
</head>
```

## 📖 Documentation

[Extensible Design Documentation](https://github.com/getspacetime/makani/wiki/Extensible-Design)

[View All Components](https://github.com/getspacetime/makani/wiki/Makani-UI-Components)

[Live Documentation](https://getspacetime.github.io/makani/)

## Performance / Benchmarks
Providing a **lightweight** and **performant** component library is a major goal of this project.

| Area | Target | Actual | Passing
| --- | --- | --- | --- |
| DLL Size | 200kb | 26.4kb | ✔️ |
| JS Bundle Size | 10kb | 392b | ✔️ |
| CSS Bundle Size | 50kb | 4.6kb | ✔️ |
| Time to Interactive | 1s | 0.6s | ✔️ |
| Total Blocking Time | 200ms | 140ms | ✔️ |
| Cumulative Layout Shift | 0 | 0 | ✔️ |
| First Contentful Paint | 0.5s | 0.3s | ✔️ |
| RAM Usage | TBD | | |
| CPU Usage | TBD | | |
| First Input Delay | TBD | | |

_The targets specified are only initial estimates and are open to change over time based on a reasonable standard._

**Sources**
- https://blog.openreplay.com/top-metrics-you-need-to-understand-when-measuring-front-end-performance
- https://developer.mozilla.org/en-US/docs/Learn/Performance/Measuring_performance

## Accessibility
A UI component library isn't helpful if it isn't useful to **everyone**.

TBD
