<?php
/**
 * Returns a JSON-encoded string of the letters in the word
 * Will return the string with underscores if the word is
 * partially guessed.
 * 
 */


include "connect.php";

//POST inputs
$user = filter_input(INPUT_POST, "user", FILTER_SANITIZE_SPECIAL_CHARS);

// Prepare and execute the DB query
$gameCommand = "SELECT user, inProgress, word, attempts, guessedLetters FROM gamesession";
$gameStmt = $dbh->prepare($gameCommand);
$gameSuccess = $gameStmt->execute();

//empty variables for the word/guessed letters
$word="";
$guessedLetters = "";


//gets the word and guessedLetters from the database
while ($row = $gameStmt->fetch()) {
    $word = $row['word'];
    $guessedLetters = $row["guessedLetters"];
}

//temporary string that houses either the letters or underscores
//depending on the currently-guessed word status
$currentGuessedWord = "";

//enters letters for current guessed word, and underscores for non-guessed letters
for ($i = 0; $i<strlen($word); $i++){
    $letterGuessed = false;
    for ($j = 0; $j<strlen($guessedLetters); $j++){
        if (substr($word,$i,1)===substr($guessedLetters,$j,1)){
            if (substr($currentGuessedWord,$i,1)!=substr($guessedLetters,$j,1)){                
            $currentGuessedWord.=substr($word,$i,1);
            $letterGuessed=true;
            }
        }
    }
    if (!$letterGuessed){
        $currentGuessedWord.="_";
    }
}

//Returns a JSON-encoded guessed word
echo json_encode($currentGuessedWord);
?>