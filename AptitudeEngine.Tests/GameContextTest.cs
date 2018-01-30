﻿using System;
using System.Drawing;
using AptitudeEngine.Assets;
using AptitudeEngine.Components.Visuals;
using AptitudeEngine.Components.Flairs;
using AptitudeEngine.CoordinateSystem;
using AptitudeEngine.Enums;

namespace AptitudeEngine.Tests
{
    public static class EntryPoint
    {
        public static void Main(string[] args)
        {
            var test = new GameTest();
            test.GameTestStart();
        }
    }

    public class GameTest : IDisposable
    {
        private bool disposed;

        private AptContext context;

        public void GameTestStart()
        {
            context = new AptContext("Test Context", 600);
            context.Load += Context_Load;
            context.Begin();
        }

        private void Context_Load(object sender, EventArgs e)
        {
            context.ClearColor = Color.Fuchsia;
            ScreenHandler.Blending(true);

            var camera = context.Instantiate().AddComponent<Camera>();
            camera.SetAsMain();
            camera.Owner.AddComponent<MoveController>();
            camera.Owner.Transform.Size = new Vector2(2, 2);
            camera.Owner.Transform.Position = new Vector2(-0.5f, -0.5f);

            var someSprite = context.Instantiate().AddComponent<SpriteRenderer>();
            someSprite.Sprite = Asset.Load<SpriteAsset>("./assets/arrow.png");
            someSprite.Transform.Position = new Vector2(-0.5f, -0.5f);

            var somePoly = context.Instantiate().AddComponent<PolyRenderer>();
            somePoly.Points = new PolyPoint[3]
            {
                new PolyPoint(new Vector2(-0.25f, -0.25f), Color.FromArgb(0, 0, 0, 0)),
                new PolyPoint(new Vector2(0.25f, -0.25f), Color.FromArgb(0, 0, 0, 0)),
                new PolyPoint(new Vector2(0, 0.25f), Color.Black),
            };

            var someCanvas = context.Instantiate().AddComponent<FlairCanvas>();
            var someFlair = context.Instantiate().AddComponent<Flair>();
            someFlair.Transform.Size = new Vector2(0.25f, 0.25f);
            someFlair.Owner.SetParent(someCanvas.Owner);

            camera.Owner.AddComponent<CustomTestingComponent>();
        }

        public AptRectangle Rec(float x, float y, float width, float height) =>
            new AptRectangle(x, y, width, height);

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if (disposed)
            {
                return;
            }

            if (disposing)
            {
                context.Dispose();
            }

            context = null;

            disposed = true;
        }
    }

    public class CustomTestingComponent : AptComponent
    {
        public override void MouseDown(InputCode mouseCode) =>
            Console.WriteLine("CustomTestingComponent: MouseDown, Button " + mouseCode.ToString());

        public override void MouseUp(InputCode mouseCode) =>
            Console.WriteLine("CustomTestingComponent: MouseUp, Button " + mouseCode.ToString());

        public override void MouseClick(InputCode mouseCode) =>
            Console.WriteLine("CustomTestingComponent: MouseClick, Button " + mouseCode.ToString());
    }
}