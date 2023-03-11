class HelloWorld
{
    static void Main()
    {
        Random rnd = new Random();
        Console.Write("Enter number of rows in matrice: ");
        var height = Convert.ToInt32(Console.ReadLine());
        Console.Write("Enter number of columns in matrice: ");
        var length = Convert.ToInt32(Console.ReadLine());
        int[,] input = new int[height, length];

        Console.Write("Matrice with randomly generated values [0,100]:\n");
        for (int i = 0; i < height; ++i)
        {
            for (int q = 0; q < length; ++q)
            {
                input[i, q] = rnd.Next(100);
                Console.Write(input[i, q] + " ");
            }
            Console.Write("\n");
        }

        int[] output = SnailLibrary.Snail.doJob(input);
        int ind = 0;

        Console.Write("Snail array from matrice:\n");
        while (ind < output.Length)
        {
            Console.Write(output[ind] + " ");
            ++ind;
        }
    }
}
