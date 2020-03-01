<?php
/**
 * Tries the user's inputted guess.
 * 
 * Returns a JSON-encoded array of results from
 * that guess.
 */


include "connect.php";

//POST inputs
$user = filter_input(INPUT_POST, "user", FILTER_SANITIZE_SPECIAL_CHARS);
$guess = filter_input(INPUT_POST, "guess", FILTER_SANITIZE_SPECIAL_CHARS);
$guess = strtolower($guess);

// Prepare and execute the DB query
$gameCommand = "SELECT user, inProgress, word, attempts, guessedLetters FROM gamesession";
$gameStmt = $dbh->prepare($gameCommand);
$gameSuccess = $gameStmt->execute();

//empty variables for the word/guessed letters
$word="";
$guessedLetters = "";
$attempts;
$message;

//gets the word,guessedLetters and attempts from the database
while ($row = $gameStmt->fetch()) {
    $word = $row['word'];
    $guessedLetters = $row["guessedLetters"];
    $attempts = $row["attempts"];
}

//checks to see if the letter exists in the guessedLetters value from the db
//if it does, it does not add it to the db to save space
$letterAlreadyGuessed = false;
for ($i = 0; $i<strlen($guessedLetters);$i++){
    if (substr($guessedLetters,$i,1)==$guess){
        $letterAlreadyGuessed = true;
    }
}
if (!$letterAlreadyGuessed && ctype_alpha($guess)){    
    $guessedLetters.=$guess;
}


//checks to see if the letter is a correct guess
$letterGuessed = false;
for ($i = 0; $i<strlen($word); $i++){
    if (substr($word,$i,1)===$guess){
        $letterGuessed=true;
    }
}

//Changes the 'message' value based off what was input by the user
if (!$letterGuessed && !$letterAlreadyGuessed && $guess!=null && ctype_alpha($guess)){
    $attempts-=1;
    $message = "Wrong guess; try again.";
}else{
    $message = "Correct guess!";
}
if ($letterAlreadyGuessed){
    $message = "You already guessed this letter; try a different one.";
}
if (!ctype_alpha($guess)){
    $message = "That is an invalid character. Try again.";
}
if ($guess==null){
    $message = "Your guess was empty.";
}

// Updates the gamesession database with newly-modified values
$updateCommand = "UPDATE gamesession SET attempts=?, guessedLetters=? WHERE user=?";
$updateStmt = $dbh->prepare($updateCommand);
$updateParams = [$attempts,$guessedLetters,$user];
$updateSuccess = $updateStmt->execute($updateParams);

$results = array('user' => $user, 'word' => $word, 'message' => $message, 'attempts' => $attempts, 'guessedLetters' => $guessedLetters);

//Returns a JSON-encoded array of results from this guess attempt
echo json_encode($results);

?>