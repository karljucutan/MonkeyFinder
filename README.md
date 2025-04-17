# MonkeyFinder - .NET MAUI Blazor Hybrid & Blazor Web App

This repository contains the code and resources for a workshop focused on building cross-platform applications using .NET MAUI Blazor Hybrid technology, extended to include a Blazor Web App InteractiveAuto render mode that shares code with the MAUI application.

This also include some information about the render info for obseravation for Blazor AutoInteractive mode.

Interactive Auto - Interactive SSR using Blazor Server initially and then CSR on subsequent visits after the Blazor bundle is downloaded. more info: https://learn.microsoft.com/en-us/aspnet/core/blazor/components/render-modes?view=aspnetcore-9.0
Note: If the browser hasn't yet cached the required WASM files (e.g., it's the user's first visit or the cache has been cleared), the Interactive Auto mode will continue to rely on Blazor Server for interactivity, until the WASM files are cached.

**Based on the YouTube Workshop:**

* **Title:** Blazor Hybrid: Build Cross-Platform Apps with .NET MAUI
* **Link:** https://www.youtube.com/watch?v=Ou0k5XKcIh4
