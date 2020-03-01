<?php

/**
 * PHP page that goes through user registration.
 * 
 * If a user exists, it will display an appropriate message.
 * If the user does not exist, it will add them to the users database.
 * 
 * Mahmood Abdul-Khaliq, Mohawk College, 2019
 */


// Checks login information first
$user = filter_input(INPUT_POST, "user", FILTER_SANITIZE_SPECIAL_CHARS);
$user = strtolower($user); //ensures usernames are in lowercase
$pw = filter_input(INPUT_POST, "pw", FILTER_SANITIZE_SPECIAL_CHARS);
$hashedPassword = password_hash($pw, PASSWORD_DEFAULT); //hashes the password

//Connects to the database
include "connect.php";

// Prepare and execute the DB query
$command = "SELECT user, pw FROM users";
$stmt = $dbh->prepare($command);
$success = $stmt->execute();

$usernameInUse = false;

//Checks to see if the username and password entered was null.
//If not, checks to see if the username exists in the database.
//If it does; changes $usernameInUse to true and modifies the php
//code in the body.
if ($user !== null and $pw !== null) {
    while ($row = $stmt->fetch()) {
        if ($user == $row["user"]) {
            $usernameInUse = true;
            break;
        }
    }
}

?>

<!DOCTYPE html>
<html>

<head>
    <title>Hangman - Logout</title>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <link rel="stylesheet" type="text/css" href="style.css">
</head>

<body>
    <div id="main">
        <?php
        //Returns a result if the username was in use or not
        if ($usernameInUse) {
            $message = "That username is in already in use; try again.";
            echo "<h1>That username is in already in use; try again.</h1>";
        }
        //Adds user to database if username is not in use.
        else {
            $insertCommand = "INSERT INTO users VALUES (?,?,NULL)";
            $insertStmt = $dbh->prepare($insertCommand);
            $insertParams = [$user, $hashedPassword];
            $insertSuccess = $insertStmt->execute($insertParams);
            $message = "User " . $user . " has been registered!";
            echo "<h1>User " . $user . " has been registered!</h1>";
        }
        ?>

        <button><a href="index.html">Go back to the login page</a></button>
    </div>
</body>

</html>