using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Battle_Cats_Ultimate_Test
{
    public static class ExtraStuff
    {
        public static float GetRandom(this Vector2 vec)
        {
            return vec.X == vec.Y ? vec.X : BCUltimate.Rand.NextFloat(vec.X, vec.Y);
        }
        public static float NextFloat(this Random rand, float low, float high)
        {
            return low + (float)(rand.NextDouble()*(high-low));
        }
        //It's called StupidRound bc it doesn't actually use Round() at all,
        //instead abusing the fact that Floor(val+0.5) acts the same as traditional rounding.
        public static int StupidRound(this float val)
        {
            return (int)MathF.Floor(val+0.5f);
        }
    }
}
