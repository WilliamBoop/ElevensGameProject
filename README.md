# Elevens Console Game (C#)

## Project Overview
This project is a **console-based implementation of the Elevens card game**, written in **C#** using object-oriented programming principles. Elevens is a single-player solitaire-style game where the player removes cards from a 9-card board by forming valid combinations until the game is either won or no valid moves remain.

## Game Rules
The game is played using a standard **52-card deck**.

### Valid Moves
The player may remove cards from the board using one of the following rules:

1. **Two-card move**  
   - Select **two cards whose values sum to 11**
   - Card values:
     - Ace = 1
     - Cards 2–10 = face value
     - Jack, Queen, King = 0 (not used in pairs)

2. **Three-card move (Face cards)**  
   - Select **one Jack, one Queen, and one King** (any suits)

### Win Condition
- The player **wins** when:
  - All cards on the board are removed
  - The deck has no cards remaining

### Lose Condition
- The player **loses** when:
  - No valid moves remain on the board
  - This can occur even if cards are still left in the deck

---

## How to Play the Game

### Requirements
- .NET SDK (version 6.0 or later recommended)
- Type "dotnet run" into terminal once cloned into your local computer 


• The board displays 9 cards, each labeled with a position number (1–9)

• Enter positions to select cards

Example Inputs:

• 2 5 → Selects cards at positions 2 and 5

• 1 3 9 → Selects cards at positions 1, 3, and 9

• r → Restart the game

• q → Quit the game

The game will display whether a move is valid or invalid and update the board accordingly
