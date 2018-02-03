﻿using AptitudeEngine.CoordinateSystem;
using AptitudeEngine.Events;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AptitudeEngine.Components.Flairs
{
    public class FPanel : AptComponent
    {
        public Color BackColor { get; set; } = Color.LightGray;

        public override void Render(FrameEventArgs a)
        {
            ScreenHandler.Poly(new PolyPoint[] {
                new PolyPoint(Vector2.Zero, BackColor),
                new PolyPoint(new Vector2(Transform.Size.X, 0), BackColor),
                new PolyPoint(new Vector2(Transform.Size.X, Transform.Size.Y), BackColor),
                new PolyPoint(new Vector2(0, Transform.Size.Y), BackColor),
            }, owner);

            ScreenHandler.Lines(new Vector2[] {
                Vector2.Zero,
                new Vector2(Transform.Size.X, 0),
                new Vector2(Transform.Size.X, Transform.Size.Y),
                new Vector2(0, Transform.Size.Y),
                Vector2.Zero,
            }, 2f, Color.Black, owner);
        }
    }
}