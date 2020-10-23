/// <summary>
/// https://www.codewars.com/kata/54521e9ec8e60bc4de000d6c
/// </summary>
namespace katas.MaxSubarray
{
    public class MaxSubArray
    {
        public static int MaxSequence(int[] arr)
        {
            var sum = 0;
            var maxSum = 0;
            
            for (var i = 0; i < arr.Length; i++)
            {
                sum = sum + arr[i] < 0 ? 0 : sum + arr[i];
                if (maxSum < sum) maxSum = sum;
            }

            return maxSum;
        }
    }
}
