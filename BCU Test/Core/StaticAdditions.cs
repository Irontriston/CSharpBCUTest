using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace BCU_Test.Core
{
    public static class StaticAdditions
    {
        public static float GetRandom(this Vector2 vec)
        {
            return vec.X == vec.Y ? vec.X : BattleCatsUltimate.Instance.Rand.NextFloat(vec.X, vec.Y);
        }
        public static float NextFloat(this Random rand, float low, float high) => low + rand.NextSingle()*(high-low);

        public static float DecideValue(this bool b, float True = 1f, float False = 0f) => b ? True : False;
        public static int DecideValue(this bool b, int True = 1, int False = 0) => b ? True : False;

        public static void DrawLine(this SpriteBatch spriteBatch, Vector2 start, Vector2 end, Color color)
        {
            spriteBatch.Draw(BattleCatsUltimate.Pixel, start, null, color, MathF.Atan2(end.Y-start.Y, end.X-start.X), new Vector2(0.5f), new Vector2(1f, (end-start).Length()), SpriteEffects.None, 1f);
        }
        public static void DrawOpenRectangle(this SpriteBatch spriteBatch, Rectangle rect, Color color)
        {
            Vector2[] Points = [
                rect.Location.ToVector2(),
                new Vector2(rect.Location.X, rect.Location.Y+rect.Size.Y),
                new Vector2(rect.Location.X+rect.Size.X, rect.Location.Y+rect.Size.Y),
                new Vector2(rect.Location.X+rect.Size.X, rect.Location.Y)];

            for (int i = 0; i < 4; i++)
                spriteBatch.DrawLine(Points[i], Points[(i+1)%4], color);
        }
        public static void DrawFilledRectangle(this SpriteBatch spriteBatch, Rectangle rect, Color color)
        {
            spriteBatch.Draw(BattleCatsUltimate.Pixel, rect.Location.ToVector2(), null, color, 0f, new Vector2(0.5f), rect.Size.ToVector2(), SpriteEffects.None, 1);
        }


        /// <summary>
        /// Abuses the fact that Floor(val+0.5) acts the same as traditional rounding.
        /// Can be switch to do what BC does for rounding, just truncating the value.
        /// </summary>
        /// <param name="val">Float to round.</param>
        /// <returns></returns>
        public static int BCRound(this float val) => (int)MathF.Floor(val+(BattleCatsUltimate.Instance.BCAccurateRounding ? 0f : 0.5f));
        /// <summary>
        /// Automatically rounds the float to the next closest int
        /// using the right-hand rule for (x).5
        /// </summary>
        /// <param name="val">Float to round.</param>
        /// <returns></returns>
        public static int AutoRound(this float val) => (int)MathF.Floor(val + 0.5f);
    }
}
