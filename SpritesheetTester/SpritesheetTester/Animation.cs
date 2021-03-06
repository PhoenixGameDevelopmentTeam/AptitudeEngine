﻿using System.Collections.Generic;

namespace SpritesheetTester
{
    public class Animation
    {
        public string Name { get; set; }
        public List<AnimatedFramePosition> Frames = new List<AnimatedFramePosition>();
        public int FrameDelay;

        public int FrameCount => Frames.Count;

        public float CellWidth;
        public float CellHeight;

        public string Spritesheet { get; set; }

        public int DrawIndex { get; set; } = 0;
        public int DrawMsIndex { get; set; } = 0;
    }
}