<?php
/**
 * Resets the user's game.
 * 
 * Returns a JSON-encoded array of results
 * from this reset, used for updating the webpage.
 * 
 */


include "connect.php";

//POST inputs
$user = filter_input(INPUT_POST, "user", FILTER_SANITIZE_SPECIAL_CHARS);

//Creates an array of the words from words.sql
$words = array();
$wordCommand = "SELECT word FROM words";
$wordStmt = $dbh->prepare($wordCommand);
$wordSuccess = $wordStmt->execute();

while ($row = $wordStmt->fetch()) {
    array_push($words,$row['word']);
}

//Randomly selects a word from the array
$randNum = rand(0,count($words)-1);
$word = $words[$randNum];

$inProgress = 1;
$attempts = 8;
$guessedLetters = "";

//Replaces current session with default values
$deleteCommand = "DELETE FROM gamesession WHERE user=?";
$deleteStmt = $dbh->prepare($deleteCommand);
$deleteParams = [$user];
$deleteSuccess = $deleteStmt->execute($deleteParams);

$insertCommand = "INSERT INTO gamesession VALUES (?,?,?,?,?,NULL)";
$insertStmt = $dbh->prepare($insertCommand);
$insertParams = [$user, $inProgress, $word, $attempts, $guessedLetters];
$insertSuccess = $insertStmt->execute($insertParams);

$results = array('user' => $user, 'word' => $word, 'message' => "Try guessing a letter!", 'attempts' => $attempts, 'guessedLetters' => $guessedLetters);

//Returns a JSON-encoded results array
echo json_encode($results);
?>