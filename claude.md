# Fitness App — Project Context

## Stack
- **Frontend**: Blazor WebAssembly (Client project)
- **Backend**: ASP.NET Core Web API (Server project)  
- **Shared**: Shared C# models used by both Client and Server
- **Database**: SQLite via Entity Framework Core
- **Template used**: `dotnet new blazorwasm --hosted -n fitness-app`

## Project purpose
A local-only web app combining a meal planner, workout planner, and fitness tracker.
No need for production security hardening — this is a local dev/portfolio project.

## Collaboration style
Where possible, do not write code directly to files or create new files in the repository. Instead, act as a guide — explain step by step what needs to be done and why, so the user can implement it themselves.

## Folder structure
- `Client/` — Blazor WASM pages and components (.razor files)
- `Server/` — ASP.NET Core controllers, AppDbContext, EF migrations
- `Shared/` — C# model classes shared between Client and Server (Meal, Workout, FitnessEntry, etc.)

## Key decisions made
- Models live in the Shared project so Client and Server don't duplicate them
- HttpClient service classes in Client/ wrap all API calls and are injected into razor pages
- EF Core migrations run from the Server project
- Single `dotnet run --project Server` command serves both the API and the Blazor app

## Features to build
- Meal planner (log meals, set targets)
- Workout planner (create and schedule workouts)
- Fitness tracker (log activity, track progress over time)

## Commands
- Run app: `dotnet run --project Server`
- Add migration: `dotnet ef migrations add <Name> --project Server`
- Update DB: `dotnet ef database update --project Server`
