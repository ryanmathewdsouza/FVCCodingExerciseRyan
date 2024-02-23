void MonteCarloSimulation(int S, float N)
{
    // if S is outside of allowed range, print an error message and stop running the function
    if (S < 1 || S > 100)
    {
        Console.WriteLine("Error, the value of parameter S must not be smaller than 1 or greater than 100");
        return;
    }
    // if N is outside of allowed range, print an error message and stop running the function
    if (N < 1 || N > 100000)
    {
        Console.WriteLine("Error, the value of parameter N must not be smaller than 1 or greater than 100000");
        return;
    }

    // initialise dictionary to store final share prices
    Dictionary<int, float> sharePriceDictionary = new Dictionary<int, float>();

    // print headers for table
    Console.WriteLine("Share Price | Probability");

    // create another variable to track the number of steps independently of N (as N is used to calculate probabilities)
    float n = N;
    // run this loop for the number of walks passed in to function
    while (n > 0)
    {
        // create another variable to track the number of steps independently of S (in order to reset the number of steps to take, to the value of S each time the outer loop is run)
        int s = S;
        // initalise sharePrice to 100 every time the outer loop is run
        int sharePrice = 100;
        // run this loop for the number of steps passed in to function
        while (s > 0)
        {
            // generate a random number between 0 and 1
            Random rnd = new Random();
            Double randomNumber = rnd.NextDouble();
            // if random number is equal to or greater than 0.5, increase sharePrice by one
            if (randomNumber >= 0.5)
            {
                sharePrice++;
            }
            // otherwise, decrease sharePrice by one
            else
            {
                sharePrice--;
            }
            // decrease s by one every time the inner loop is run
            s--;
        }

        // if the share price is already a key in the dicitonary, then increase by the reciprocal of N
        if (sharePriceDictionary.ContainsKey(sharePrice))
        {
            sharePriceDictionary[sharePrice] += 1/N;
        }
        // otherwise, at the key of share price, set the value equal to the reciprocal of N
        else
        {
            sharePriceDictionary.Add(sharePrice, 1/N);
        }
        //decrease n by one every time the outer loop runs
        n--;
    }

    // sort sharePriceDictionary
    var sortedDictionary = new SortedDictionary<int, float>(sharePriceDictionary);
    // print the key value pairs of the sorted dictionary
    foreach (var pair in sortedDictionary)
    {
        Console.WriteLine(pair.Key + "            " + pair.Value);
    }
}

MonteCarloSimulation(10, 10000);