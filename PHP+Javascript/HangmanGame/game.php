<?php

/**
 * Allows a user to play a game of Hangman.
 * 
 * Results are dynamically stored in the gamesession.sql
 * database.
 * 
 * Mahmood Abdul-Khaliq, Mohawk College, 2019
 */
session_start();



//Connects to the database
include "connect.php";

// Prepare and execute the DB query
$gameCommand = "SELECT user, inProgress, word, attempts, guessedLetters FROM gamesession";
$gameStmt = $dbh->prepare($gameCommand);
$gameSuccess = $gameStmt->execute();

//placeholder for stats about the current game session
$user = $_SESSION["user"];
$inProgress;
$word;
$attempts;
$guessedLetters;


//variable used to see if there is a current game in progress
$gameInProgress = false;

//Checks to see if a current game is in progress under the same username.
//If so, sets the gameInProgress variable to 'true'
while ($row = $gameStmt->fetch()) {
    if ($user == $row["user"]) {
        if ($row['inProgress'] == 1) {
            $gameInProgress = true;
            $inProgress = $row['inProgress'];
            $word = $row['word'];
            $attempts = $row['attempts'];
            $guessedLetters = $row['guessedLetters'];
            break;
        }
    }
}

//Creates an array of the words from words.sql
$words = array();
$wordCommand = "SELECT word FROM words";
$wordStmt = $dbh->prepare($wordCommand);
$wordSuccess = $wordStmt->execute();

while ($row = $wordStmt->fetch()) {
    array_push($words, $row['word']);
}

//If there is no game in progress, create variables from scratch
if (!$gameInProgress) {
    $randNum = rand(0, count($words) - 1);
    $word = $words[$randNum];

    $inProgress = 1;
    $attempts = 8;
    $guessedLetters = "";

    $insertCommand = "INSERT INTO gamesession VALUES (?,?,?,?,?,NULL)";
    $insertStmt = $dbh->prepare($insertCommand);
    $insertParams = [$user, $inProgress, $word, $attempts, $guessedLetters];
    $insertSuccess = $insertStmt->execute($insertParams);
}
?>

<!DOCTYPE html>
<html>

<head>
    <title>Hangman - Game</title>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <link rel="stylesheet" type="text/css" href="style.css">
    <script type="text/javascript" src="gamescript.js"></script>
</head>

<body>
    <div id="main">
        <div id="game">
            <h1><span id="username"><?= $_SESSION["user"] ?></span>'s Hangman game</h1>
            <?php
            if ($gameInProgress) {
                echo "<p id = 'gameDetected'>Game in progress detected; continuing previous game.</p>";
            } else {
                echo "<p id = 'gameDetected'>Creating new game.</p>";
            }
            ?>

            <p id="word" style="display:none"><?php echo $word ?></p>
            <p id="gameInfo">Letters Found/Remaining:</p>
            <div id="currentGuess">

            </div>

            <p id="gameInfo">Attempts: </p>
            <div id="attemptsRemaining">
                <p><?php echo $attempts ?></p>
                <p>Try guessing a letter!</p>
            </div>

            <p id="gameInfo">Guessed Letters:</p>
            <div id="guessed">
                <p><?php echo $guessedLetters ?></p>
            </div>

            <div id="userGuess">
                <input id="guess" type="text" minlength="1" maxlength="1" size="1">
                <input id="user" type="hidden" value="<?php echo $user ?>">
                <input class="button" id="guessbutton" type="submit" value="Guess!"><br />
                <input class="button" id="resetbutton" type="submit" value="Try another word">
            </div>


            <br /><button><a href="main.php">Go back</a></button>



        </div>
        <div id="gameResult" style="display: none">
            <p id="winMessage"></p>
            <button><a href="main.php">Go back</a></button><br />
            <button id = "tryagain">Try again</button><br />
            <button><a href="history.php">View history</a></button>
        </div>
    </div>
</body>

</html>