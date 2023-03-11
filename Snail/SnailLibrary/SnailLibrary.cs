namespace SnailLibrary
{
    public class Snail
    {
        public static int[] DoJob(int[,] array)
        {
            int[] ans = new int[array.Length];

            int length = array.Length / array.GetLength(0);
            int lengthCurr = 0;

            int height = array.GetLength(0);
            int heightCurr = 0;

            int i = 0;
            while (i < array.Length)
            {
                int lengthCurrTmp = lengthCurr;
                int heightCurrTmp = heightCurr;

                while (lengthCurr < length && i < array.Length)
                {
                    ans[i] = array[heightCurr, lengthCurr];
                    ++i;
                    ++lengthCurr;
                }
                lengthCurr--;
                length--;
                heightCurr++;

                while (heightCurr < height && i < array.Length)
                {
                    ans[i] = array[heightCurr, lengthCurr];
                    ++i;
                    ++heightCurr;
                }
                heightCurr--;
                height--;
                lengthCurr--;

                while (lengthCurr >= lengthCurrTmp && i < array.Length)
                {
                    ans[i] = array[heightCurr, lengthCurr];
                    ++i;
                    --lengthCurr;
                }
                lengthCurr++;
                heightCurr--;

                while (heightCurr > heightCurrTmp && i < array.Length)
                {
                    ans[i] = array[heightCurr, lengthCurr];
                    ++i;
                    --heightCurr;
                }
                heightCurr++;
                lengthCurr++;
            }
            return ans;
        }
    }
}