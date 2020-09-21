# Solution for Round 2 interview of Sapient :computer:
Contains Solution for Coding round interview.

## Design Decisions
* The solution would be implemented and available as a set of web api endpoints.
* Logging will be done at an API level for exceptions as API would be the client facing part.

## Pre-requisites for running the code
* .NET core 3.1 or latest should be installed on the machine.
* Microsoft Visual Studio Professional 2019 Version 16.4.2 or latest

## Instructions for Running the API project locally.
1. Verify that the startup project is set as Sapient.MTS.WebApi.
2. Configure the JSON file location in appsettings.json and property JSONFileLocation, make sure you have both read and write access to the path.
3. Start running the project with kestral with or without debugging.
4. Star the UI project by switching to Source\UI\SapientMedicinesUI.
5. Run the UI project by running npm start.

## Abbreviations
1. MTS - Medicine Tracking system.
