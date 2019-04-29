COM Server Demo
================

This is a basic example of providing a managed COM server in .NET Core 3.0. Documentation on the inner workings of activation can be found [here](https://github.com/dotnet/core-setup/blob/master/Documentation/design-docs/COM-activation.md).

Key Features
------------

Demonstrates how to provide a COM server in .NET Core 3.0 Preview 5 or later.

Addtional comments are contained in source and project files.

Build and Run
-------------

The project will only build and run on the Windows platform.

1) Install .NET Core 3.0 Preview 5 or later.

1) Navigate to the root directory and run `dotnet.exe build`.

1) Follow the instructions for COM server registration that were emitted during the build.

1) Navigate to `COMClient/` and run `dotnet.exe run`.

**Note** Remember to unregister the COM server when the demo is complete.
