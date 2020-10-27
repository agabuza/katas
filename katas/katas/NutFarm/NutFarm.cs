using System.Linq;
/// <summary>
/// https://www.codewars.com/kata/59884371d1d8d3d9270000a5
/// </summary>
namespace katas.NutFarm
{
    public class NutFarm
    {
        public static int[] ShakeTree(string[] tree)
        {
            var nuts = tree[0].Select(v => v == 'o' ? 1 : 0).ToArray();
            for (int i = 1; i < tree.Length; i++)
            {
                var currentLevel = tree[i];
                for (int j = 1; j < nuts.Length; j++)
                {                    
                    switch (currentLevel[j])
                    {
                        case '\\': 
                            nuts[j + 1] += nuts[j]; 
                            nuts[j] = 0; 
                            break;
                        case '/':
                            nuts[j - 1] += nuts[j];
                            nuts[j] = 0;
                            break;
                        case '_': 
                            nuts[j] = 0; 
                            break;                        
                    }
                }
            }

            return nuts;
        }
    }
}
