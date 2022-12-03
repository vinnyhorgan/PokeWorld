using Raylib_cs;
using System;

namespace PokeWorld.Game.States
{
    class Game : State
    {
        public override void Update(float dt)
        {
            Console.WriteLine("Hello");
        }

        public override void Draw()
        {
            Raylib.DrawText("X: " + Mouse.Position.X + " Y: " + Mouse.Position.Y, 10, 10, 50, Color.WHITE);
        }
    }
}