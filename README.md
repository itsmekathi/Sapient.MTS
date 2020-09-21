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
3. You can use the example JSON file in TestData\medicines to load the initial data and place it in the respective JSONFileLocation path.
4. Start running the project with kestral with or without debugging.
5. Star the UI project by switching to Source\UI\SapientMedicinesUI.
6. Run the UI project by running npm start.
7. Open chorme and navigate to http://localhost:4000

## Abbreviations
1. MTS - Medicine Tracking system.
