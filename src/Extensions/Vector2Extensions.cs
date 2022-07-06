using Microsoft.Xna.Framework;

namespace BoidSimulation.Extensions
{
    public static class Vector2Extensions
    {
        public static Vector2 LimitLength(this Vector2 vector, float length)
        {
            if (vector.LengthSquared() > length * length)
            {
                vector.Normalize();
                vector *= length;
            }

            return vector;
        }

        public static float ToRotation(this Vector2 vector)
        {
            return MathF.Atan2(vector.Y, vector.X);
        }
    }
}