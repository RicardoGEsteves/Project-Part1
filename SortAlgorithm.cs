namespace Project_Part1
{
    internal class SortAlgorithm
    {
        public static void BubbleSort(Archive[] arr, int length)
        {
            Archive repos = null;
            for (int i = 0; i < length - 1; i++)
            {
                for (int j = 0; j < length - (i + 1); j++)
                {
                    if (arr[j].IdentificationNumber > arr[j + 1].IdentificationNumber)
                    {
                        repos = arr[j];
                        arr[j] = arr[j + 1];
                        arr[j + 1] = repos;
                    }
                }
            }
        }

    }
}