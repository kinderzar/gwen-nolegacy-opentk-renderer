namespace Gwen.Renderer
{
    internal static class FontStyleExtention
    {
        public static System.Drawing.FontStyle ToSystemDrawing(this FontStyle fontStyle)
        {
            var result = System.Drawing.FontStyle.Regular;

            if (fontStyle == FontStyle.Regular)
                return result;

            if (fontStyle.HasFlag(FontStyle.Bold))
                result |= System.Drawing.FontStyle.Bold;
            if (fontStyle.HasFlag(FontStyle.Italic))
                result |= System.Drawing.FontStyle.Italic;
            if (fontStyle.HasFlag(FontStyle.Underline))
                result |= System.Drawing.FontStyle.Underline;
            if (fontStyle.HasFlag(FontStyle.StrikeThrough))
                result |= System.Drawing.FontStyle.Strikeout;

            return result;
        }
    }
}
