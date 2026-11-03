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
        // Plan:
        // I know how many multiples I need up front (length), so I can just make
        // an array that size instead of growing a list.
        // Then loop from 0 to length. The first multiple is the number itself,
        // so at index i the value is number * (i + 1). Can't use number * i
        // because that would make the first one 0.
        // Fill in each spot as I go, then return the array when the loop is done.

        double[] multiples = new double[length];
        for (int i = 0; i < length; i++)
        {
            multiples[i] = number * (i + 1);
        }

        return multiples;
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
                // Plan:
        // Rotating right by some amount really just means chopping off the last
        // 'amount' numbers and sticking them on the front.
        // So with {1,2,3,4,5,6,7,8,9} and amount 3, the last 3 are {7,8,9} and
        // they end up first.
        // The cut happens at data.Count - amount (index 6 in that example).
        // My steps:
        // 1. copy the end chunk with GetRange
        // 2. delete that chunk from the list with RemoveRange
        // 3. put the copy at the front with InsertRange at index 0
        // No return needed since the list gets changed in place. If amount is the
        // whole list, the whole thing gets pulled off and put back, so it stays
        // the same, which is what should happen anyway.

        List<int> tail = data.GetRange(data.Count - amount, amount);
        data.RemoveRange(data.Count - amount, amount);
        data.InsertRange(0, tail);
    }
}
