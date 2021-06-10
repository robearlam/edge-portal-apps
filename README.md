# 🎢 Edge Portal Apps

Sample application build using Mobile Blazor Bindings, to pull data from Sitecore Experience Edge for Content Hub.

## ⚠ Prerequisites

- .NET Core 3.1+ SDK
- Visual Studio 2019 with the following workloads enabled
  - Mobile development with .NET (Xamarin.Forms)
  - ASP.NET and web development
- Android SDK level 28 (Pie) and above

## 🏃‍ To Run

- Open Solution in Visual Studio 2019
- Set required target system project as startup project
  - E.g. to run Android set `edge-portal-apps.Android` as startup project.
- Hit F5 and wait

## 📃 Notes
- This is all a POC, some of the code........ isn't nice
- All of the GraphQL stuff is hardcoded in the `AnnouncementsService` class, this can be better.
- Mobile Blazor Bindings is experimental and sometimes it seems to cache old versions and doesn't show your changes, to get around this
  - Clean Solution
  - Delete `obj` & `bin` folders from all projects
  - Remove `.zip` file from Assets folder in target system project you're trying to run.