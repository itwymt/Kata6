#region 

using System;

#endregion


namespace Kata6
{
    public class Wrapper
    {
        private const short MinColumnWidthForLineWrap = 20;

        public string Wrap(string text, int columnWidth, Boolean breakAtWordBoundaries)
        {
            if (breakAtWordBoundaries && columnWidth < MinColumnWidthForLineWrap)
            {
                throw new Exception("The column width is rejected as too short for a line wrap");
            }
            if (columnWidth == 0 || text.Length < columnWidth)
            {
                return text;
            }

            int indexOfNewLine = 0;

            while (indexOfNewLine < text.Length - columnWidth)
            {
                string line = text.Substring(indexOfNewLine, columnWidth);
                var lastIndexOfSpace = line.LastIndexOf(" ", StringComparison.Ordinal);
                if (lastIndexOfSpace == -1 && breakAtWordBoundaries)
                {
                    throw new Exception("One or more words is longer then column width");
                }
                indexOfNewLine += breakAtWordBoundaries ? lastIndexOfSpace + 1 : columnWidth;
                text = text.Insert(indexOfNewLine, "\n");
                indexOfNewLine += 1;
            }

            return text;
        }
    }
}
