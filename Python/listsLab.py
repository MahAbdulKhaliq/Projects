# I, Mahmood Abdul-Khaliq, student number 000788833, certify that all code submitted is my own work;
# that I have not copied it from any other source. I also certify that I have not allowed
# my work to be copied by others - this is solely my work.

def oneDimensionalList():
    inputs=[] #list that is intended to contain user inputs; returned at end of function
    loop=True; #sentinel value

    print("\nOne Dimensional List Example - Sorting")
    print("This program will take a variety of inputs, place them into a list, and then sort them alphabetically.")

    
    while (loop==True):
        userInput=str(input("Enter a word (enter 'quit' to stop): "))
        if userInput.lower()=="quit":
            loop=False;
            break;
        else:
            inputs.append(userInput.lower().capitalize())

    return inputs

def twoDimensionalList():
    finalList=[]

    print("\nTwo Dimensional List Example - Power Tables")
    print("This program will take an integer and creates times tables from 0*0 to n*n")

    userInput=int(input("Please enter a number between 3-9: "))

    while userInput<3 or userInput>9:
        print("Invalid input, try again.")
        userInput=int(input("Please enter a number between 3-9: "))

    while (len(finalList)!=userInput+1):
        finalList.append([])

    for i in range(0,len(finalList)):            
        for j in range(0,len(finalList)):
            finalList[j].append(str(i*j))

    return finalList




print("Welcome to listsLab.py; this lab is all about utilizing lists and their functions.")
choice=str(input("Would you like to try an example of one-dimensional lists, or two dimensional lists? "))

validChoices1=["one","1","one-dimensional","1-dimensional","one dimensional","1 dimensional"] #a list of predetermined "valid" choices for one-dimensional arrays
validChoices2=["two","2","two-dimensional","2-dimensional","two dimensional","2 dimensional"] #a list of predetermined "valid" choices for two-dimensional arrays

#while loop to check if the user choice is valid
while (choice.lower() not in validChoices1) and (choice.lower() not in validChoices2):
    print("Invalid input, try again.")
    choice=str(input("Would you like to try an example of one-dimensional lists, or two dimensional lists? "))

if (choice.lower() in validChoices1):
    exampleList=oneDimensionalList()
    exampleList.sort()
    print("\nYour inputs sorted are:")
    print("\n".join(exampleList))

if (choice.lower() in validChoices2):
    exampleList=twoDimensionalList()
    for i in range(0,len(exampleList)):
        print(" ".join(exampleList[i]))
