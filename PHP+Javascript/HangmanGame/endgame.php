<?php
/**
 * Ends the game by setting the 'inProgress' parameter for that
 * game to zero, and logs the game in the history.sql database.
 * 
 */


include "connect.php";

//POST inputs
$user = filter_input(INPUT_POST, "user", FILTER_SANITIZE_SPECIAL_CHARS);
$win = filter_input(INPUT_POST, 'win', FILTER_VALIDATE_BOOLEAN);
$date = date("Y-m-d");

// Finds the game stats for the selected game
$selectCommand = "SELECT word, attempts, guessedLetters, gameID FROM gamesession WHERE user=?";
$selectStmt = $dbh->prepare($selectCommand);
$selectParams = [$user];
$selectSuccess = $selectStmt->execute($selectParams);

$word;
$attempts;
$guessedLetters;
$id;

while ($row = $selectStmt->fetch()) {
    $word=$row["word"];
    $attempts=$row["attempts"];
    $guessedLetters=$row["guessedLetters"];
    $id=$row["gameID"];
}

//Deletes current game session
$deleteCommand = "DELETE FROM gamesession WHERE user=?";
$deleteStmt = $dbh->prepare($deleteCommand);
$deleteParams = [$user];
$deleteSuccess = $deleteStmt->execute($deleteParams);

//Inserts game stats into the history.sql database
$insertCommand = "INSERT INTO history VALUES (?,?,?,?,?,?)";
$insertStmt = $dbh->prepare($insertCommand);
$insertParams = [$user, $win, $attempts, $word, $date, $id];
$insertSuccess = $insertStmt->execute($insertParams);


?>