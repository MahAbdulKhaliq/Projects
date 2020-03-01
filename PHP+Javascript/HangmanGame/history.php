<?php

/**
 * Views the 10 last Hangman games played
 * 
 * Mahmood Abdul-Khaliq, Mohawk College, 2019
 */
session_start();

include "connect.php";

//Empty arrays to-be-filled with history data
$historyUsers = array();
$historyWins = array();
$historyAttempts = array();
$historyWords = array();
$historyDates = array();

// Finds the game history stats for all games
$selectCommand = "SELECT user, win, attempts, word, dateFinished FROM history ORDER BY dateFinished DESC LIMIT 10";
$selectStmt = $dbh->prepare($selectCommand);
$selectSuccess = $selectStmt->execute();

//Adds results to arrays
while ($row = $selectStmt->fetch()) {
    array_push($historyUsers, $row['user']);
    array_push($historyWins, $row['win']);
    array_push($historyAttempts, $row['attempts']);
    array_push($historyWords, $row['word']);
    array_push($historyDates, $row['dateFinished']);
}

for ($i = 0; $i < count($historyWins); $i++) {
    if ($historyWins[$i] == 0) {
        $historyWins[$i] = "LOSS";
    } else {
        $historyWins[$i] = "WIN";
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
        <h1>Game History</h1>
        <h2>Game history is for the last 10 games played</h2>
        <h3>(sorted by most recently played)</h3>
        <?php
        for ($i = 0; $i < count($historyUsers); $i++) {
            echo "<div id = 'historyGameBox'>";
            echo "<p id='historyTitle'>Game " . ($i + 1) . "</p><br/>";
            echo "<p>User: " . $historyUsers[$i] . "</p><br/>";
            echo "<p>Result: " . $historyWins[$i] . "</p><br/>";
            echo "<p>Attempts Remaining: " . $historyAttempts[$i] . "</p><br/>";
            echo "<p>Word: " . $historyWords[$i] . "</p><br/>";
            echo "<p>Date Completed: " . $historyDates[$i] . "</p><br/>";
            echo "</div>";
        }
        ?>
        <button><a href="main.php">Go back</a></button><br />
    </div>
</body>

</html>