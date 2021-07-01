
# Hangman

### Description:
This is version 1.0.0 of a Hangman game made with WinForms. Please ensure to have the .NET framework installed on your computer prior to running the application. This application simply requires the .NET framework to be installed on a computer running on any operating system, for example Windows or MacOS. Once the application is running, the player can simply click 'New Game' to start whereby they have 10 lives to correctly guess the secret word. A randomly chosen word will be displayed in the form of an asterisk for each letter in the word.

To guess a letter in this secret word, the player enters a letter into the appropriate textbox and clicks 'Take a Guess'. Should the letter be incorrect, the letter is stored into a textbox and 1 life is deducted. Otherwise, if a letter is guessed correctly, the player will be rewarded with a point for each correctly guessed letter.

After winning a game, the player's score will be added to the scoreboard to display their previous game's scores.

### How to play:
1. Press 'F5' to run the application
2. Click 'New Game' button to start a new game
3. Enter a letter you think might be in the secret word
4. Click 'Take a Guess' - and hope it's correct!
5. Click 'Reset Game' to clear the existing game
6. Once a game is finished, simply click 'New Game' to start another one! 

### Current Issues:
1. An incorrect letter is inserted into the 'incorrect guess' textbox for the length of the secret word. For example, 'Foo' is the secret word, 'x' is guessed, and is entered into the 'incorrect textbox' as 'xxx’. The solution would be to add only a single instance of the guessed letter into the ‘incorrect textbox’, otherwise the logic of adding guesses to the incorrect textbox should be moved outside the for loop for comparing each letter of the secret word with the guessed letter.
2. A life is deducted not only for incorrect guesses, but for correct guesses as well. The solution would be to strictly specify the logic for only deducting lives when a guess was incorrect.

### Author

- [Christiaan Venter](https://www.github.com/codecventer)