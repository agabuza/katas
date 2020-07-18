namespace katas.StripComments
{
    public class StripCommnetsKata
    {
        public static string StripComments(string text, string[] commentSymbols)
        {
            var result = string.Empty;
            var lines = text.Split('\n');

            for (int i = 0; i < lines.Length; i++)
            {
                var firstCommentIndex = lines[i].Length;
                foreach (var commentSymbol in commentSymbols)
                {
                    var commentSymbolIndex = lines[i].IndexOf(commentSymbol);
                    firstCommentIndex = firstCommentIndex > commentSymbolIndex && commentSymbolIndex >= 0 ? commentSymbolIndex : firstCommentIndex;
                }

                lines[i] = lines[i].Substring(0, firstCommentIndex).TrimEnd(' ');
            }

            return string.Join("\n", lines);
        }
    }
}
