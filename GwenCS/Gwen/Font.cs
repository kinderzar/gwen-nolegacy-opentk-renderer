using System;

namespace Gwen
{
    [Flags]
    public enum FontStyle
    {
        /// <summary>
        /// Regular text
        /// </summary>
        Regular = 0,
        /// <summary>
        /// Bold text
        /// </summary>
        Bold = 1,
        /// <summary>
        /// Italic text
        /// </summary>
        Italic = 2,
        /// <summary>
        /// Underlined text
        /// </summary>
        Underline = 4,
        /// <summary>
        /// Text with a line through the middle.
        /// </summary>
        StrikeThrough = 8
    }

    /// <summary>
    /// Represents font resource.
    /// </summary>
    public class Font : IDisposable
    {
        /// <summary>
        /// Font face name. Exact meaning depends on renderer. Do not include font style like bold or italic here.
        /// </summary>
        public string FaceName { get; set; }

        /// <summary>
        /// Font size.
        /// </summary>
        public int Size { get; set; }

        /// <summary>
        /// Font style like bold or italic. Use bitwise or (|) to combine styles.
        /// </summary>
        public FontStyle FontStyle { get; set; }

        /// <summary>
        /// Enables or disables font smoothing (default: disabled).
        /// </summary>
        public bool Smooth { get; set; }

        /// <summary>
        /// This should be set by the renderer if it tries to use a font where it's null.
        /// </summary>
        public object RendererData { get; set; }

        /// <summary>
        /// This is the real font size, after it's been scaled by Renderer.Scale()
        /// </summary>
        public float RealSize { get; set; }

        private readonly Renderer.Base m_Renderer;

        /// <summary>
        /// Initializes a new instance of the <see cref="Font"/> class.
        /// </summary>
        public Font(Renderer.Base renderer)
            : this(renderer, "Arial", 10)
        {

        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Font"/> class.
        /// </summary>
        /// <param name="renderer">Renderer to use.</param>
        /// <param name="faceName">Face name.</param>
        /// <param name="size">Font size.</param>
        public Font(Renderer.Base renderer, string faceName, int size = 10, FontStyle fontStyle = FontStyle.Regular)
        {
            m_Renderer = renderer;
            FaceName = faceName;
            Size = size;
            FontStyle = fontStyle;
            Smooth = false;
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            m_Renderer.FreeFont(this);
            GC.SuppressFinalize(this);
        }

#if DEBUG
        ~Font()
        {
            throw new InvalidOperationException(String.Format("IDisposable object finalized: {0}", GetType()));
            //Debug.Print(String.Format("IDisposable object finalized: {0}", GetType()));
        }
#endif

        /// <summary>
        /// Duplicates font data (except renderer data which must be reinitialized).
        /// </summary>
        /// <returns></returns>
        public Font Copy()
        {
            Font f = new Font(m_Renderer, FaceName)
            {
                Size = Size,
                FontStyle = FontStyle,
                RealSize = RealSize,
                RendererData = null // must be reinitialized
            };

            return f;
        }
    }
}
