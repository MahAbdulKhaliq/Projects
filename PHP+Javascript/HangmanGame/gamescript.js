/**
 * Handles multiple functions of the Hangman game.
 * 
 * 
 * 
 * Mahmood Abdul-Khaliq, Mohawk College, 2019
 */

window.addEventListener("load", function () {

    //Starts off by showing the user their current guess status
    function updateCurrentGuess() {
        let user = document.getElementById("username").innerHTML;
        let params = "user=" + user;
        console.log(user);
        fetch("listletters.php", {
                method: "POST",
                creditentials: "include",
                headers: {
                    "Content-Type": "application/x-www-form-urlencoded",
                },
                body: params
            })
            .then(response => response.json())
            .then(showWord)
    }
    updateCurrentGuess();

    //Shows the currently tracked guessed word
    function showWord(word) {
        let currentGuess = document.getElementById("currentGuess");
        currentGuess.innerHTML = word;
    }

    //Updates the attempts and displays a message based on whether the user
    //correctly or incorrectly guessed a letter
    function updateResults(results) {
        console.log(results);
        let currentAttempts = document.getElementById("attemptsRemaining");
        currentAttempts.innerHTML = "<p>" + results.attempts + "</p><p>" + results.message + "</p>";
        let currentLetters = document.getElementById("guessed");
        currentLetters.innerHTML = "<p>" + results.guessedLetters + "</p>"
        updateCurrentGuess();
        setTimeout(function () {
            checkWin(results)
        }, 250);
    }

    //Checks to see if the user won (or lost)
    function checkWin(results) {
        console.log(results);
        let user = document.getElementById("username").innerHTML;
        let mainGame = document.getElementById("game");
        let gameResult = document.getElementById("gameResult");
        let winMessage = document.getElementById("winMessage");
        let currentGuess = document.getElementById("currentGuess").innerHTML;
        let gameEnded = false;
        let win = false;
        //Checks to see if win or loss conditions are met
        if (results.attempts === 0) {
            winMessage.innerHTML = "You lose. Your word was '"+results.word+"'.";
            gameEnded = true;
            win = false;
        } else if (currentGuess === results.word) {
            winMessage.innerHTML = "You win!";
            gameEnded = true;
            win = true;
        }

        //If the game has ended, show the win/loss result and
        //run endgame.php, which sets current game progress
        //to 'false' and logs the results
        if (gameEnded == true) {
            mainGame.style.display = "none";
            gameResult.style.display = "block";
            let url = "endgame.php";
            let params = "user=" + user + "&win=" + win;

            // Does a fetch that involves POST paramaters for the params above
            fetch(url, {
                method: 'POST',
                credentials: 'include',
                headers: {
                    "Content-Type": "application/x-www-form-urlencoded"
                },
                body: params
            })
        }
    }

    //Checks the letter if the 'Guess!' button was clicked
    let guessButton = document.getElementById("guessbutton");
    guessButton.addEventListener("click", function () {
        let url = "tryguess.php";
        let user = document.getElementById("username").innerHTML;
        let guess = document.getElementById("guess").value;
        let params = "user=" + user + "&guess=" + guess;

        // Does a fetch that involves POST paramaters for the params above
        fetch(url, {
                method: 'POST',
                credentials: 'include',
                headers: {
                    "Content-Type": "application/x-www-form-urlencoded"
                },
                body: params
            })
            .then(response2 => response2.json())
            .then(updateResults)
    });

    //Resets the current game if the 'Try again' button was clicked
    let tryButton = document.getElementById("tryagain");
    tryButton.addEventListener("click", function () {

        let url = "reset.php";
        let user = document.getElementById("username").innerHTML;
        let params = "user=" + user;
        let gameDetected = document.getElementById('gameDetected');
        gameDetected.innerHTML = "New game created.";

        // Does a fetch that involves POST paramaters for the params above
        fetch(url, {
                method: 'POST',
                credentials: 'include',
                headers: {
                    "Content-Type": "application/x-www-form-urlencoded"
                },
                body: params
            })
            .then(response3 => response3.json())
            .then(updateResults)

        //Code to ensure that main game shows and game result is hidden
        let gameResult = document.getElementById("gameResult");
        let mainGame = document.getElementById("game");
        mainGame.style.display = "block";
        gameResult.style.display = "none";
    });

    //Resets the current game if the 'Try another word' button was clicked
    let resetButton = document.getElementById("resetbutton");
    resetButton.addEventListener("click", function () {

        let url = "reset.php";
        let user = document.getElementById("username").innerHTML;
        let params = "user=" + user;
        let gameDetected = document.getElementById("gameDetected");
        gameDetected.innerHTML = "New game created.";

        // Does a fetch that involves POST paramaters for the params above
        fetch(url, {
                method: 'POST',
                credentials: 'include',
                headers: {
                    "Content-Type": "application/x-www-form-urlencoded"
                },
                body: params
            })
            .then(response4 => response4.json())
            .then(updateResults)

        //Redundant code to ensure that main game shows and game result is hidden (failsafe)
        let gameResult = document.getElementById("gameResult");
        let mainGame = document.getElementById("game");
        mainGame.style.display = "block";
        gameResult.style.display = "none";
    });
});