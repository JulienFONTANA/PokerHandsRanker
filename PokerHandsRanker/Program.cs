namespace PokerHandsRanker
{
    public class Program
    {
        public static void Main()
        {
            // TODO :
            // 1. Tests
            // 2. Proper hand name display
            //      ie : Full House Name Display -> (K K K 4 4 is Kings over Fours)
            // 3. Stop the screen from flickering + have not too many input at once            

            var phr = new PokerHands();
            phr.Rank();
        }
    }
}
