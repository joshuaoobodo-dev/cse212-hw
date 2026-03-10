public static class Arrays
{
    /// <summary>
    /// This function will produce an array of size 'length' starting with 'number' followed by multiples of 'number'.  For 
    /// example, MultiplesOf(7, 5) will result in: {7, 14, 21, 28, 35}.  Assume that length is a positive
    /// integer greater than 0.
    /// </summary>
    /// <returns>array of doubles that are the multiples of the supplied number</returns>
    public static double[] MultiplesOf(double number, int length)
    {
        // TODO Problem 1 Start
        // Remember: Using comments in your program, write down your process for solving this problem
        // step by step before you write the code. The plan should be clear enough that it could
        // be implemented by another person.

        // Step 1: Create an array of doubles with the specified length to hold the multiples.
        // Step 2: Use a loop to calculate each multiple of the number and store it in the array.
        // Step 3: Return the array of multiples.

        var multiples = new double[length]; // Step 1
        for (int i = 0; i < length; i++)
        {
            double next_multiple = number * (i + 1); // Compute the value of the next multiple. For example, if number is 7 and i is 3, then next_multiple will be 21.
            multiples[i] = next_multiple; // Step 2
        }
        return multiples; // replace this return statement with your own : (done)
    }

    /// <summary>
    /// Rotate the 'data' to the right by the 'amount'.  For example, if the data is 
    /// List<int>{1, 2, 3, 4, 5, 6, 7, 8, 9} and an amount is 3 then the list after the function runs should be 
    /// List<int>{7, 8, 9, 1, 2, 3, 4, 5, 6}.  The value of amount will be in the range of 1 to data.Count, inclusive.
    ///
    /// Because a list is dynamic, this function will modify the existing data list rather than returning a new list.
    /// </summary>
    public static void RotateListRight(List<int> data, int amount)
    {
        // TODO Problem 2 Start
        // Remember: Using comments in your program, write down your process for solving this problem
        // step by step before you write the code. The plan should be clear enough that it could
        // be implemented by another person.

        // Step 1: Create a new list to hold the rotated values.
        // Step 2: Use a loop to populate the new list with the values from the original list in the correct order.
        // Step 3: Clear the original list and add the values from the new list back to it.

        var rotated_data = new List<int>(); // Step 1 - We can't use a fixed-size array here because we don't know the size of the input list, and we want to be able to add elements dynamically.
        int n = data.Count(); // Get the number of elements in the original list.
        for (int i = 0; i < n; i++)
        {
            int next_index = (n - amount + i) % n; // Compute the index of the next value to add to the rotated list. For example, if n is 9, amount is 3, and i is 0, then next_index will be 6.
            int next_value = data[next_index]; // Get the value from the original list at the computed index.
            
            rotated_data.Add(next_value); // Step 2 - Add the value to the rotated list.
        }

        data.Clear(); // Step 3 - Clear the original list to prepare for adding the rotated values back to it.
        data.AddRange(rotated_data); // Add the values from the rotated list back to the original list.
    }

    ///static void Main(string[] args)
    ///{
    ///    // You can use this main method to do some quick manual testing of your code.
    ///    // However, the unit tests in Arrays_Tests.cs will be used to grade your code, so make sure to run those tests after you have implemented the functions.

    ///    double[] first_7_multiples_of_5 = MultiplesOf(5, 7);
    ///    Console.WriteLine(string.Join(", ", first_7_multiples_of_5)); // Should print: 5, 10, 15, 20, 25, 30, 35
    ///    
    ///    RotateListRight(new List<int> { 1, 2, 3, 4, 5 }, 2); // Should modify the list to be: {4, 5, 1, 2, 3}
    ///}
}
