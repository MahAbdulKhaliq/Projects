This project - titled 'HangmanGame' - was made during my time at Mohawk College; it was created to test my understanding of PHP, JavaScript
AJAX, and a bit of SQL (via implementing databases for some of the features). The CSS implemented is very rough as this project was not
designed with CSS design in mind.

If you want to run this on a web browser, please visit: https://csunix.mohawkcollege.ca/~000788833/HangmanGame/.
If you are concerned about password security, please do not use your real password for the sake of testing.

This project requires a personal server to run (I used XAMPP as it provided a version of phpMyAdmin); as such, the connect.php may need to be adjusted to allow for access within your internal database.

Sample .sql database files can be found within the db folder and can be implemented into your phpMyAdmin.

---

The premise of this project is that a user can register an account or password (this is checked amongst other usernames). The passwords are
hashed (using default PHP hashing methods) and the user is stored in a database. The user can then login with their creditentals.

Once the user is logged in, they can choose to:
a) Play a game of Hangman - this checks for an active session for that user. If there is one, it starts from the previous session; 
otherwise, a new session is started.
b) View history - this views the history of all played games with their username, the word, and whether the attempt was a success
or failure.
c) Logout - this logs the user out of the current session.

The game of hangman operates as follows:
a) The user is given a random word (pulled from words.sql)
b) The user has 8 guesses for each letter in that words. Numbers do not count, case is ignored, and an already guessed letter
cannot be used.
c) All of the above data is then stored in a game session file (username, current word, number of guesses remaining, already guessed letters, etc.)
d) Any guessed letters are displayed to the user; this will show even if resuming a current session.
e) The user can 'try another word' to reset their current game.
f) The game will check upon each attempt to see if the word is complete.

If the game ends in either a victory or a loss, an appropriate message is desplayed and the results are saved to history.sql.

--

Databases are used heavily throughout this project as follows:
i) users.sql contains: usernames, passwords (hashed), and a userid (used for phpMyAdmin management)
ii) words.sql contains: words, word id (used for phpMyAdmin management)
iii) gamesession.sql contains: username, game session status, current word, remianing attempts, guessed letters, and game id (used for phpMyAdmin management)
iv) history.sql contains: usernames, win/loss status, how many attempts were remaining, the word, the date finished, and game id (used for phpMyAdmin management)
