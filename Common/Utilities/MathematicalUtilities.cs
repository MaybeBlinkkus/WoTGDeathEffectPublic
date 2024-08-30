using System;
using Microsoft.Xna.Framework;
using Terraria;

namespace WotGDeath.Common.Utilities
{
    public static partial class Utilities
    {
        public static Rectangle Subdivide(this Rectangle rectangle, int horizontalFrames, int verticalFrames, int frameX, int frameY)
        {
            int width = rectangle.Width / horizontalFrames;
            int height = rectangle.Height / verticalFrames;
            return new Rectangle(rectangle.Left + width * frameX, rectangle.Top + height * frameY, width, height);
        }
    }
}
