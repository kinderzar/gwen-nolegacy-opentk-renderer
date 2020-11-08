﻿using Gwen.Control;
using System.Drawing;

namespace Gwen.UnitTest
{
    public class RichLabel : GUnit
    {
        private readonly Font f1, f2, f3;

        public RichLabel(Base parent) : base(parent)
        {
            Control.RichLabel label = new Control.RichLabel(this);
            label.SetBounds(10, 10, 400, 200);

            f1 = new Font(Skin.Renderer, "Arial", 15);
            label.AddText("This test uses Arial 15, Red. Padding. ", Color.Red, f1);

            f2 = new Font(Skin.Renderer, "Times New Roman", 20, FontStyle.Bold);
            label.AddText("This text uses Times New Roman Bold 20, Green. Padding. ", Color.Green, f2);

            f3 = new Font(Skin.Renderer, "Courier New", 15, FontStyle.Italic);
            label.AddText("This text uses Courier New Italic 15, Blue. Padding. ", Color.Blue, f3);

            label.AddLineBreak();

            label.AddText("This test uses Arial 15 Bold Italic Strikethrough, Magenta. Padding. ", Color.Magenta, new Font(Skin.Renderer, "Arial", 15, FontStyle.Bold | FontStyle.Italic | FontStyle.StrikeThrough));
        }

        public override void Dispose()
        {
            f1.Dispose();
            f2.Dispose();
            f3.Dispose();
            base.Dispose();
        }
    }
}
