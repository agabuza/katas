using System.Collections.Generic;
/// <summary>
/// https://www.codewars.com/kata/5279f6fe5ab7f447890006a7
/// </summary>
namespace katas.PickPeaks
{
    class PickPeaks
    {
        public static Dictionary<string, List<int>> GetPeaks(int[] arr)
        {
            var position = 0;
            var result = new Dictionary<string, List<int>>();
            result.Add("pos", new List<int>());
            result.Add("peaks", new List<int>());

            bool onRaise = false, isFlat = false, onDescent = false;
            for (int i = 0; i < arr.Length - 1; i++)
            {
                onRaise = arr[i] < arr[i + 1];
                isFlat = arr[i] == arr[i + 1];
                onDescent = arr[i] > arr[i + 1];

                if (onRaise)
                {
                    position = i + 1;
                }

                if (onDescent && position != 0)
                {
                    result["pos"].Add(position);
                    result["peaks"].Add(arr[position]);
                    position = 0;
                }
            }

            return result;
        }
    }
}
