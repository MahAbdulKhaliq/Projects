<?php

/**
 * Main page that is displayed.
 * If a user is logged in, it will allow them to perform
 * actions (play, view history, log out).
 * 
 * If a user is not logged in, they will be forced back to
 * the login screen.
 * 
 * Mahmood Abdul-Khaliq, Mohawk College, 2019
 */
session_start();

// Checks login information first
$user = filter_input(INPUT_POST, "user", FILTER_SANITIZE_SPECIAL_CHARS);
$user = strtolower($user); //turns username to lowercase
$pw = filter_input(INPUT_POST, "pw", FILTER_SANITIZE_SPECIAL_CHARS);

//Connects to the database
include "connect.php";

// Prepare and execute the DB query
$command = "SELECT user, pw FROM users";
$stmt = $dbh->prepare($command);
$success = $stmt->execute();

//Checks to see if the username and password entered was null.
//If not, checks to see if the username and password exist in the database.
if ($user !== null and $pw !== null) {
    while ($row = $stmt->fetch()) {
        if ($user == $row["user"]) {
            
            if (password_verify($pw,$row['pw'])) {
                $_SESSION["user"] = $user;
                break;
            }
        }
        //Invalid login attempt handling
        else {
            session_unset();
        }
    }
}
?>

<!DOCTYPE html>
<html>

<head>
    <title>Hangman - Main</title>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <link rel="stylesheet" type="text/css" href="style.css">
</head>

<body>
    <div id="main">
        <?php
        if (isset($_SESSION["user"])) {
            ?>
            <h1>Welcome <?= $_SESSION["user"] ?>!</h1>
            <p>What would you like to do?</p>
            <button><a href="game.php">Play a game of Hangman</a></button><br />
            <button><a href="history.php">View history</a></button><br />
            <button><a href="logout.php">Logout</a></button>
        <?php
        } else {
            ?>
            <h1>Login Error! Access denied.</h1>
            <h2>Either the username or password was not correct</h2>
            <button><a href="index.html">Go back</a></button>
        <?php
        }
        ?>
    </div>
</body>

</html>