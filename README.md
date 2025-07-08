## Overview

    This project implements a custom programming language parser using the GOLD Parser Builder and a Windows Forms application in C#. 
    I personally designed and wrote the syntax for this language from scratch, defining its grammar rules in the PLD_proj.cgt file. 
    The parser processes input code written in this custom language, validates it against the defined syntax rules, and displays token and parsing information in a user-friendly interface.

# Features:
  - Custom Syntax: The language syntax was entirely designed by me, supporting constructs such as:
      1. Arithmetic expressions (e.g., +, -, *, /, **, %)
      2. Control structures (If, For, then, else, If_end)
      3. Function declarations and calls (Func, Return)
      4. Class declarations and object creation (Class, New)
      5. Variable assignments and data types (intg, doub, strg, floaut)
  - Parser Implementation: Utilizes the GOLD Parser Engine to parse input code based on the custom grammar defined in PLD_proj.cgt.
  - GUI Interface: A Windows Forms application with a text box for input code and two list boxes to display:
      1. Token information (via listBox2)
      2. Parsing errors and expected tokens (via listBox1)
  - Real-time Feedback: The parser processes input as it changes in the text box, providing immediate feedback on syntax validity.

# Project Structure:
   - Form1.cs: Main form logic, handling user input and parser initialization.
   - Form1.Designer.cs: Auto-generated code for the Windows Forms UI layout.
   - Form1.resx: Resource file for the form's UI elements.
   - Parser.cs: Contains the MyParser class, which processes the input using the GOLD Parser Engine and handles token and parse error events.
   - Program.cs: Entry point for the Windows Forms application.
   - PLD_Project.csproj: Project file with dependencies, including CalithaLib and GoldParserEngine.
   - PLD_proj.cgt: Compiled grammar table file defining the custom language syntax.


# How It Works:
   1. Syntax Definition: The custom language syntax is defined in a .egt or .cgt file (compiled grammar table) using GOLD Parser Builder.
   2. Parsing: The MyParser class reads the grammar file (PLD_proj.cgt) and processes input code from the text box.
   3. Token Processing: As the parser reads tokens, it displays them in listBox2 with their corresponding symbol names (e.g., Ident, +, If).
   4. Error Handling: If a syntax error occurs, the parser logs the error and expected tokens in listBox1.
   5. UI Interaction: The Windows Forms interface allows users to input code, view tokens, and see parsing errors in real time.

# Usage:
   1. Launch the application to open the Windows Forms interface.
   2. Enter code written in the custom language syntax in the text box on the left.
   3. View parsed tokens in the top-right list box (listBox2).
   4. Check for any syntax errors in the bottom-right list box (listBox1).
  # Example Code:
        Start
        intg x = 5
        If (x > 2) then
            x = x + 1
        If_end
        End
   This code declares an integer x, assigns it the value 5, checks if x > 2, and increments x if true. 
   The parser will process this input and display the tokens and any errors.    


    
