int manticoreHitPoints = 10;
int consolasHitPoints = 15;
int currentRound = 1;

//This method asks for a number within a given range, you must pass this method the text for the question
//as well as a minimum and maximum value
int AskForANumberInRange(string text, int min, int max)
{
    Console.Write(text);
    int number = Convert.ToInt32(Console.ReadLine());
    while (true)
    {

        if (number < min || number > max)
        {
            Console.WriteLine("Incorrect Input, please try again:");
            number = Convert.ToInt32(Console.ReadLine());
        }
        else
        {
            return number;
            break;
        }
    }

}

//This method detects if the manticore was hit, it then deals the appropriate amount of damage
void detectHit(int manticoreCoordinates, int cannonRange, int damage)
{
    if (manticoreCoordinates == cannonRange)
    {
        Console.WriteLine("That round was a DIRECT HIT!");
        manticoreHitPoints -= damage;
    }
    else if (manticoreCoordinates > cannonRange)
    {
        Console.WriteLine("That round FELL SHORT of the target");
        consolasHitPoints--;
    }
    else
    {
        Console.WriteLine("That round OVERSHOT the target");
        consolasHitPoints--;
    }
}

int manticoreCoordinates = AskForANumberInRange("How far from the city do you want to station the Manticore? (0-100)", 0, 100);
Console.Clear();

//This method runs through all the information that must be displayed each round as well as checking how much damage
//will be dealt based off the round/cannon
void Round()
{
    int cannonRange;
    Console.WriteLine("STATUS: Round: " + currentRound + " City: " + consolasHitPoints + "/15 " + "Manticore: " + manticoreHitPoints + "/10");
    if (currentRound % 3 == 0 && currentRound % 5 == 0)
    {
        Console.WriteLine("The cannon is expected to deal 10 damage this round");
        cannonRange = AskForANumberInRange("Enter desired cannon range: (0-100)", 0, 100);
        detectHit(manticoreCoordinates, cannonRange, 10);
    }

    else if (currentRound % 5 == 0)
    {
        Console.WriteLine("The cannon is expected to deal 5 damage this round");
        cannonRange = AskForANumberInRange("Enter desired cannon range: (0-100)", 0, 100);
        detectHit(manticoreCoordinates, cannonRange, 5);
    }
    else if (currentRound % 3 == 0)
    {
        Console.WriteLine("The cannon is expected to deal 3 damage this round");
        cannonRange = AskForANumberInRange("Enter desired cannon range: (0-100)", 0, 100);
        detectHit(manticoreCoordinates, cannonRange, 3);
    }
    else
    {
        Console.WriteLine("The cannon is expected to deal 1 damage this round");
        cannonRange = AskForANumberInRange("Enter desired cannon range (0-100): ", 0, 100);
        detectHit(manticoreCoordinates, cannonRange, 1);
    }

    currentRound++;
}


//This loop iterates through the rounds until either the manticore is destroyed or the city is destroyed.
while (true)
{
    if (manticoreHitPoints <= 0)
    {
        Console.WriteLine("The Manticore has been destroyed! The city of Consolas has been saved!");
        break;
    }
    else if (consolasHitPoints <= 0)
    {
        Console.WriteLine("The city has fallen! All is lost!");
        break;
    }
    else
        Round();
}


