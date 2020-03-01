# I, Mahmood Abdul-Khaliq, student number 000788833, certify that all code submitted is my own work;
# that I have not copied it from any other source. I also certify that I have not allowed
# my work to be copied by others - this is solely my work.
import random

print("Hi, I'm Mahmood Abdul-Khaliq and welcome to the CompSci Squares!")
player1=str(input("Player 1, enter your name: "))
player2=str(input("Player 2, enter your name: "))

play=True

#Returns a formatted drawing of the board. Still needs to be printed via print commands
def drawBoard(board):
    line1=board[0] + " | " + board[1] + " | " + board[2]
    line2=board[3] + " | " + board[4] + " | " + board[5]
    line3=board[6] + " | " + board[7] + " | " + board[8]
    return ("\n" + line1 + "\n---------\n" + line2 + "\n---------\n" + line3)

#Plays the Rock, Scissors, Paper, Lizard, Spock minigame.
def rspLizardSpock(name):
    choices=["rock","scissors","paper","lizard","spock"]

    print("In order to win your square, you must win a game of Rock, Scissors, Paper, Lizard, Spock!")
    
    playerChoice=str(input(name+", pick one of the choices (rock, scissors, paper, lizard or Spock): "))
    playerChoice=playerChoice.lower() #turns the choice to lowercase because it's easier to check
    
    while (playerChoice not in choices):
        print("Invalid choice - try again!")
        playerChoice=(str(input(name+", pick one of the choices (rock, scissors, paper, lizard or Spock): "))).lower()

    guestChoice=random.choice(choices) #randomly selects a choice from the list
    #secretly rerolls the guest's choice if the choice is the same as the users
    while (guestChoice==playerChoice):
        guestChoice=random.choice(choices)

    miniGameWin=False
    condition=""

    #checks for player win conditions
    if (playerChoice=="rock" and (guestChoice=="scissors" or guestChoice=="lizard")):
        miniGameWin=True
        condition="crushes"
    if (playerChoice=="scissors" and (guestChoice=="paper" or guestChoice=="lizard")):
        miniGameWin=True
        if (guestChoice=="paper"):
            condition="cuts"
        else:
            condition="decapitates"
    if (playerChoice=="paper" and (guestChoice=="rock" or guestChoice=="spock")):
        miniGameWin=True
        if (guestChoice=="rock"):
            condition="covers"
        else:
            condition="disproves"
    if (playerChoice=="lizard" and (guestChoice=="paper" or guestChoice=="spock")):
        miniGameWin=True
        if (guestChoice=="paper"):
            condition="eats"
        else:
            condition="poisons"
    if (playerChoice=="spock" and (guestChoice=="scissors" or guestChoice=="rock")):
        miniGameWin=True
        if (guestChoice=="scissors"):
            condition="smashes"
        else:
            condition="vaporizes"

        
    #checks conditions for guest win conditions
    if (guestChoice=="rock" and (playerChoice=="scissors" or playerChoice=="lizard")):
        condition="crushes"
    if (guestChoice=="scissors" and (playerChoice=="paper" or playerChoice=="lizard")):
        if (playerChoice=="paper"):
            condition="cuts"
        else:
            condition="decapitates"
    if (guestChoice=="paper" and (playerChoice=="rock" or playerChoice=="spock")):
        if (playerChoice=="rock"):
            condition="covers"
        else:
            condition="disproves"
    if (guestChoice=="lizard" and (playerChoice=="paper" or playerChoice=="spock")):
        if (playerChoice=="paper"):
            condition="eats"
        else:
            condition="poisons"
    if (guestChoice=="spock" and (playerChoice=="scissors" or playerChoice=="rock")):
        if (playerChoice=="scissors"):
            condition="smashes"
        else:
            condition="vaporizes"

    #capitalizes the name Spock for the end
    if (playerChoice=="spock"):
        playerChoice=playerChoice.capitalize()
    if (guestChoice=="spock"):
        guestChoice=guestChoice.capitalize()

    if (miniGameWin==True):
        print("Our celebrity guest picked "+guestChoice + "! " +playerChoice.capitalize() +" " +condition +" " +guestChoice +"; " +name +", you win the square!")
        return True
    else:
        print("Our celebrity guest picked "+guestChoice + "! " +guestChoice.capitalize() +" " +condition +" " +playerChoice +"; I'm sorry, " +name +", you lost the square!")
        return False
    
    

def ticTacToe(board,player1,player2):
    win=False
    playerTurn=1
    numOccupied=0 #numOccupied defines how many blocks have been filled up

    #randomly chooses which player will be X or O by swapping the players around
    swap=random.randint(1,2)
    if (swap==2):
        player1,player2=player2,player1

    print(player1 + " will be playing X today and gets first pick on the board; " +player2 +" is O.")
    
    def checkWin(board):
        #checks horizontally
        if (board[0] == board[1] == board[2]) and board[0]!=" ":
            return True
        if (board[3] == board[4] == board[5]) and board[3]!=" ":
            return True
        if (board[6] == board[7] == board[8]) and board[6]!=" ":
            return True
        #checks vertically
        if (board[0] == board[3] == board[6]) and board[0]!=" ":
            return True
        if (board[1] == board[4] == board[7]) and board[1]!=" ":
            return True
        if (board[2] == board[5] == board[8]) and board[2]!=" ":
            return True
        #checks diagonally
        if (board[0] == board[4] == board[8]) and board[0]!=" ":
            return True
        if (board[2] == board[4] == board[6]) and board[2]!=" ":
            return True
        else:
            return False

    while (win==False):
        print (drawBoard(board))

        if (numOccupied==9):
            break

        rspInstance=False #checks if the last turn made was due to the RSPLS minigame
        
        if (playerTurn==1):
            print(player1+", where would you like to place your X?")
            row = ((int(input("Row: "))) - 1) * 3 #-1 * 3 because lists start at 0 and each column occurs every increment of 3
            while (row<0 or row>6):
                    row = ((int(input("Invalid row, try again. Row: "))) - 1) * 3
            column = (int(input("Column: "))) - 1 # -1 because lists start at 0
            while (column<0 or column>2):
                    column = (int(input("Invalid column, try again. Column: "))) - 1

            while(board[row+column]!=" "):
                print("I'm sorry "+player1+", but that spot is occupied. Try a different one!")
                row = ((int(input("Row: "))) - 1) * 3
                while (row<0 or row>6):
                    row = ((int(input("Invalid row, try again. Row: "))) - 1) * 3
                column = (int(input("Column: "))) - 1
                while (column<0 or column>2):
                    column = (int(input("Invalid column, try again. Column: "))) - 1
            if (rspLizardSpock(player1)==True):
                board[row+column]="X"
                numOccupied+=1
            else:
                if (numOccupied==8):
                    board[row+column]=" "
                    playerTurn=2
                else:
                    board[row+column]="O"
                    playerTurn=2
                    numOccupied+=1
                    rspInstance=True
            if (rspInstance==True and checkWin(board)==True):
                rspInstance=False
                numOccupied-=1
                board[row+column]=" "
            elif (checkWin(board)==True):
                win=True
                break
            playerTurn=2

        else:
            print(player2+", where would you like to place your O?")
            row = ((int(input("Row: "))) - 1) * 3 
            while (row<0 or row>6):
                    row = ((int(input("Invalid row, try again. Row: "))) - 1) * 3
            column = (int(input("Column: "))) - 1 
            while (column<0 or column>2):
                    column = (int(input("Invalid column, try again. Column: "))) - 1

            while(board[row+column]!=" "):
                print("I'm sorry "+player2+", but that spot is occupied. Try a different one!")
                row = ((int(input("Row: "))) - 1) * 3
                while (row<0 or row>6):
                    row = ((int(input("Invalid row, try again. Row: "))) - 1) * 3
                column = (int(input("Column: "))) - 1
                while (column<0 or column>2):
                    column = (int(input("Invalid column, try again. Column: "))) - 1
            if (rspLizardSpock(player2)==True):
                board[row+column]="O"
                numOccupied+=1
            else:
                if (numOccupied==8):
                    board[row+column]=" "
                    playerTurn=2
                else:
                    board[row+column]="X"
                    playerTurn=1
                    numOccupied+=1
                    rspInstance=True
            if (rspInstance==True and checkWin(board)==True):
                rspInstance=False
                numOccupied-=1
                board[row+column]=" "
            elif (checkWin(board)==True):
                win=True
                break
            playerTurn=1           

    if (win==True and playerTurn==1):
        print(drawBoard(board))
        print(player1+", you won!")
    if (win==True and playerTurn==2):
        print(drawBoard(board))
        print(player2+", you won!")
    if (win==False):
        print("Draw!")


    repeat=str(input("Play again? (Y/N): "))
    repeat=repeat.lower()

    while (repeat!="y" and repeat!="n"):
        repeat=str(input("Invalid input, please try again. Play again? (Y/N): "))
        repeat=repeat.lower()

    if (repeat.lower()=="y"):
        #ticTacToe([" ", " ", " ", " ", " ", " ", " ", " ", " "],player1,player2)
        return True
    else:
        print("Thanks for playing!")
        return False
        
        
while (play==True):
    play=(ticTacToe([" ", " ", " ", " ", " ", " ", " ", " ", " "],player1,player2))


