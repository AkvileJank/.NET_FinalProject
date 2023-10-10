# .NET Final Project - Bulls and Cows Game

## Introduction
This project is a console-based implementation of the classic game "Bulls and Cows." It was created as a final project on the "She Goes Tech" course on Microsoft technologies and .NET.

## Game Description
"Bulls and Cows" is a number guessing game where the player attempts to guess a combination of unique numbers. The game provides feedback in the form of "Bulls" and "Cows" to help the player refine their guesses:

- Bull: A bull represents a number that is correctly guessed and in the correct position.
- Cow: A cow represents a number that is correctly guessed but in the wrong position.

The player's goal is to guess the entire combination within a limited number of attempts.

## Programming Concepts Used
This project demonstrates various programming concepts and features in C# and .NET development:

### 1. Console Application
   - The entire game is implemented as a console application, allowing interaction via the command line.

### 2. Object-Oriented Programming (OOP)
   - The code is organized into classes and methods, following OOP principles for modularity and maintainability.
   - Key classes: `Program`, which contains the main game logic, and various utility methods.

### 3. User Input and Output
   - User input is obtained using `Console.ReadLine()` for difficulty selection and guesses.
   - Output messages and game instructions are displayed using `Console.WriteLine()`.

### 4. Exception Handling
   - The code includes error handling using `try` and `catch` to handle input validation and inform users of incorrect inputs.

### 5. Arrays
   - Arrays are used to store the randomly generated numbers, the user's guesses, and to track bulls and cows.

### 6. Random Number Generation
   - The `CreateRandomArray` method generates a random combination of numbers within a specified range.

### 7. Flow Control
   - Conditional statements (`if`, `switch`) are used for game flow control and input validation.
   - Loops (`while`, `for`) are employed to control game rounds and iterations.

### 8. Data Conversion
   - The code converts user input from strings to integers using `Array.ConvertAll()`.

### 9. LINQ
   - LINQ is used to find the intersection of two arrays to calculate the number of cows.

## How to Run the Game
1. Clone or download this repository to your local machine.
2. Open the project in a compatible C# development environment (e.g., Visual Studio).
3. Build and run the application.
4. Follow the on-screen instructions to play the Bulls and Cows game.
