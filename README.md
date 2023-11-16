# Custom Logger

This is an attempt to design a custom logger that ships the logs based on the configurations to the required sinks as per the configured log level.

## Technical Details

- The project has been built with .NET 6.0 and Visual Studio 2022.
- All projects except SampleRunner are libraries, so please select that project to run the solution.
- 2 Loggers have been created
  - *Console Logger* - Logs to the console itself
  - *File Logger* - Logs to a file in the `bin` folder - logs.txt

## Application Setup

### Logger.Abstractions

This project contains the interfaces and serves as the base of the entire project.

### Logger.Configurations

This project contains the configuration options and their required implementations.

### Logger.Core

This project contains the implementations for all the contracts denied in the abstractions and helps make this work.

### Logger.SampleRunner

This is an executable project which runs off of all the previous projects and their implementations.
