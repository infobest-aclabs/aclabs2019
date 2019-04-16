namespace BowlingGame
{
    public class Game
    {
        private int currentPin = 0;
        private int[] pins = new int [21];
        public void Roll(int knockedDownPins)
        {
            pins[currentPin] = knockedDownPins;
            currentPin++;
        }

        public int Score()
        {
            int score = 0;
            int firstInFrame = 0;
            for (int frame = 0; frame < 10; frame++)
            {
                if (pins[firstInFrame] + pins[firstInFrame + 1] == 10) //spare
                {
                    score += 10;
                    score += pins[firstInFrame + 2];
                    firstInFrame += 2;
                }
                else
                {
                    score += pins[firstInFrame] + pins[firstInFrame + 1];
                    firstInFrame += 2;
                }
            }
            return score;
        }
        static void Main()
        {
        }
    }
}