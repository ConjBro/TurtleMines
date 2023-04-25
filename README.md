# TurtleMines
Turtle mine challenge.

To use this application, you must:
- Clone the repository 
- Export the application as an executable file.
- Run the application from the commandline in the following format while in the same folder as the application:
  - `.\TurtleMines.exe game-settings.json moves.json`
- The `game-settings.json` and `moves.json` files are required as commandline arguments to run this application, where the file names are interchangable but the `.json` extension is required.


## Known Issues
Currently, the application cannot deserialize the JSON files down to .Net objects due to interface usage. 
Given more time, this issue would be resolved.
