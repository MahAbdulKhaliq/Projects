<?php

/**
 * Simple log-out page
 * 
 * Mahmood Abdul-Khaliq, Mohawk College, 2019
 */
session_start();
session_unset();
session_destroy();
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
        <h1>You have logged out!</h1>
        <button><a href="index.html">Go back to the login page</a></button>
    </div>
</body>

</html>