using Raylib_cs;
using System.Numerics;

namespace PokeWorld.Game
{
    static class Mouse
    {
        public static Vector2 Position;

        public static void Update(float scale)
        {
            Vector2 mouse = Raylib.GetMousePosition();

            Position.X = (mouse.X - (Raylib.GetScreenWidth() - (Window.Width * scale)) * 0.5f) / scale;
            Position.Y = (mouse.Y - (Raylib.GetScreenHeight() - (Window.Height * scale)) * 0.5f) / scale;

            Vector2 max = new Vector2((float)Window.Width, (float)Window.Height);
            Position = Vector2.Clamp(Position, Vector2.Zero, max);
        }
    }
}