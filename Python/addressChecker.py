# I, Mahmood Abdul-Khaliq, student number 000788833, certify that all code submitted is my own work;
# that I have not copied it from any other source. I also certify that I have not allowed
# my work to be copied by others - this is solely my work.

def printErrors(errorlist):
    #function used to print out existing errors in check functions
    #only used to reduce the amount of times this is copy-pasted
    print("The following errors were detected: ")
    for i in range(0,len(errorlist)):
        print(errorlist[i])

def clearAbbreviations(abbreviation):
    #simple function that strips leading and trailing spaces from
    #abbreviation; not entirely necessary in a function
    return abbreviation.strip()
    

def checkStreetAddress(string):
    word=string[string.find(" ")+1:len(string)] #separates the number from the street address. Returns the entire string if no space is detected
    errorlist=[] #error list allows the number of unique errors to be displayed separately
    while (string[0].isdecimal()==False) or (len(word)<6) or (string.find(" ")==-1): #Checks for various errors - see if statements for error types
        #if statements allow the while loop to check which errors occur
        #despite being defined in the while loop, there is no way to display the
        #unique errors without these
        if string[0].isdecimal()==False:
            errorlist.append("-Street address does not contain a number")
        elif len(word)<6:
            errorlist.append("-The length of the street name is less than 6")
        if string.find(" ")==-1:
            errorlist.append("-The input lacks a space separating the number from the street name")

        printErrors(errorlist) #calls to the printErrors function (see above)
        string=str(input("Enter a valid street address: "))
        word=string[string.find(" ")+1:len(string)]
        errorlist=[] #resets the error list for next loop
    return string

def checkCity(string):
    validAbbreviations=["AB","BC","MB","NB","NL","NT","NS","NU","ON","PE","QC","SK","YT"] #a list of valid abbreviations
    abbreviation=clearAbbreviations(string[string.find(",")+1:len(string)]).upper()
    """a plethora of functions to ensure the abbreviation is:
       -cleared of trailing spaces (clearAbbreviations)
       -does not contain a comma when found (string.find(",")+1)
       -goes until the end of the sentence (sliced to len(string))
       -is in uppercase (.upper())"""
    errorlist=[]

    #for an explanation on these errors, see the errorlist.append statements
    while (string.find(",")==-1) or (abbreviation not in validAbbreviations):
        if string.find(",")==-1:
            errorlist.append("-Input does not contain any commas separating city and provincial abbreviation")
        elif abbreviation not in validAbbreviations:
            errorlist.append("-Provincial abbreviation is not valid. Valid provincial abbreviations are: "+', '.join(validAbbreviations)+". Your entered abbreviation was: "+abbreviation)
        printErrors(errorlist)
        string=str(input("Enter a valid city followed by a province (abbreviated): "))
        errorlist=[]
        abbreviation=clearAbbreviations(string[string.find(",")+1:len(string)]).upper()
    return string

def checkPostalCode(string,abbreviation):
    errorlist=[]
    provincialList=[]
    #since the previous function checkCity ensures that the abbreviation is always one of the options, no additional check is needed
    if (abbreviation=="AB"):
        provincialList=["T"]
    if (abbreviation=="BC"):
        provincialList=["V"]
    if (abbreviation=="MB"):
        provincialList=["R"]
    if (abbreviation=="NB"):
        provincialList=["E"]
    if (abbreviation=="NL"):
        provincialList=["A"]
    if (abbreviation=="NT"):
        provincialList=["X"]
    if (abbreviation=="NS"):
        provincialList=["B"]
    if (abbreviation=="NU"):
        provincialList=["T"]
    if (abbreviation=="ON"):
        provincialList=["K","L","M","N","P"]
    if (abbreviation=="PE"):
        provincialList=["C"]
    if (abbreviation=="QC"):
        provincialList=["G","H","J"]
    if (abbreviation=="SK"):
        provincialList=["S"]
    if (abbreviation=="YT"):
        provincialList=["Y"]

    #see error.append statements for explanations on what errors do what
    while (len(string)!=6) or (string[0] not in provincialList) or (string[0].isalpha()==False or string[1].isdecimal()==False or string[2].isalpha()==False or string[3].isdecimal()==False or string[4].isalpha()==False or string[5].isdecimal()==False):
        if (len(string)!=6):
            errorlist.append("-Postal codes need to be exactly 6 characters")
        if len(string)==6 and (string[0].isalpha()==False or string[1].isdecimal()==False or string[2].isalpha()==False or string[3].isdecimal()==False or string[4].isalpha()==False or string[5].isdecimal()==False):
            errorlist.append("-Postal codes need to be in the format: X#X#X#, where X is a letter and # is a number")
        if string[0] not in provincialList:
            errorlist.append("-Postal code does not contain a valid first letter for this province. Valid first letters are: " +', '.join(provincialList))
        printErrors(errorlist)

        string=str(input("Enter a valid postal code: ")).upper().replace(" ","") #replaces all instances of spaces that the user inputs for the postal code with nothing for the sake of making checking the postal code easier
        errorlist=[]

    return string[0:3]+" "+string[3:6] #returns the string WITH spaces for the sake of formatting

streetAddress=str(input("Enter a street address: "))
streetAddress=checkStreetAddress(streetAddress)


city=str(input("Enter a city followed by a province (abbreviated): "))
city=checkCity(city)
abbreviation=clearAbbreviations(city[city.find(",")+1:len(city)]).upper() #obtains the abbreviation since it wasn't dragged out from checkCity. In this case, since the abbreviation is checked it's 100% right.

postalCode=str(input("Enter a postal code: "))
postalCode=checkPostalCode(postalCode.upper().replace(" ",""),abbreviation).upper() #checks the postal code by running checkPostalCode with an uppercase postal code that has no spaces alongside the abbreviation obtained from previous

#function that returns an appropriate shipping cost based on the provincial abbreviation provided
def shippingCost(abbreviation):
    if abbreviation=="AB" or abbreviation=="BC" or abbreviation=="MB" or abbreviation=="SK":
        return "$12"
    if abbreviation=="NB" or abbreviation=="NL" or abbreviation=="NS" or abbreviation=="PE":
        return "$15"
    if abbreviation=="NT" or abbreviation=="NU" or abbreviation=="YK":
        return "$20"
    if abbreviation=="ON" or abbreviation=="QC":
        return "$8"

print ("Shipping to " +streetAddress +", "+city[0:city.find(",")] +", " +abbreviation +" - " +postalCode +" will cost " +shippingCost(abbreviation))
