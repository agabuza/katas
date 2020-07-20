namespace katas.RangeExtension
{
    public class RangeExtraction
    {
        public static string Extract(int[] args)
        {
            var result = string.Empty;
            var sequence = 0;
            var i = 0;

            do
            {                
                sequence = 0;
                result += args[i];

                i++;
                // sequence in range
                while (i < args.Length && (args[i] == args[i - 1] + 1))
                {
                    sequence++;
                    i++;
                }

                if (sequence == 1) result += "," + args[i -1];
                
                if (sequence > 1)
                {
                    result += "-" + args[i - 1];
                }

                result += ",";
            }
            while (i < args.Length);

            return result.TrimEnd(',');
        }
    }
}
