<?php
/**
 * Connects to the database.
 * 
 * Mahmood Abdul-Khaliq, Mohawk College, 2019
 */
try {
    //local db
    $dbh = new PDO(
        "mysql:host=localhost;dbname=000788833",
        "root",
        ""
    );
    //csunix db
    /*$dbh = new PDO(
        "mysql:host=localhost;dbname=000788833",
        "000788833",
        "19980714"
    );*/
} catch (Exception $e) {
    die("ERROR: Couldn't connect. {$e->getMessage()}");
}
