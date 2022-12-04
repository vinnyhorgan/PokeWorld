using Humper.Responses;
using Raylib_cs;
using System.Numerics;

namespace PokeWorld.Game
{
    class Player : Entity
    {
        private int _speed = 200;

        public Player(int x, int y) : base("Graphics/025.png", x, y)
        {

        }

        public override void Update(float dt)
        {
            Vector2 velocity = Vector2.Zero;

            if (Raylib.IsKeyDown(KeyboardKey.KEY_W))
            {
                velocity.Y = -1;
            }
            else if (Raylib.IsKeyDown(KeyboardKey.KEY_S))
            {
                velocity.Y = 1;
            }

            if (Raylib.IsKeyDown(KeyboardKey.KEY_A))
            {
                velocity.X = -1;
            }
            else if (Raylib.IsKeyDown(KeyboardKey.KEY_D))
            {
                velocity.X = 1;
            }

            if (velocity != Vector2.Zero)
            {
                velocity = Vector2.Normalize(velocity) * _speed * dt;
            }

            if (velocity.Y < 0 && velocity.X > 0)
                Face(Direction.NE);
            else if (velocity.Y > 0 && velocity.X > 0)
                Face(Direction.SE);
            else if (velocity.Y > 0 && velocity.X < 0)
                Face(Direction.SW);
            else if (velocity.Y < 0 && velocity.X < 0)
                Face(Direction.NW);
            else if (velocity.Y < 0)
                Face(Direction.N);
            else if (velocity.Y > 0)
                Face(Direction.S);
            else if (velocity.X < 0)
                Face(Direction.W);
            else if (velocity.X > 0)
                Face(Direction.E);

            _collider.Move(_x + velocity.X, _y + velocity.Y, (collision) => CollisionResponses.Slide);

            base.Update(dt);
        }
    }
}