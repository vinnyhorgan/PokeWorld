using Humper;
using Raylib_cs;

namespace PokeWorld.Game
{
    enum Direction
    {
        S,
        SE,
        E,
        NE,
        N,
        NW,
        W,
        SW
    }

    class Entity
    {
        protected Texture2D _texture;
        protected float _x;
        protected float _y;
        protected Animation[] _walkAnimation;
        protected Animation _currentAnimation;
        protected Direction _currentDirection;
        protected IBox _collider;

        public Entity(string texturePath, int x, int y)
        {
            _texture = Raylib.LoadTexture(texturePath);
            _x = x;
            _y = y;

            _walkAnimation = new Animation[8];
            _walkAnimation[(int)Direction.S] = new Animation(_texture, 4, 8, 8, (int)Direction.S);
            _walkAnimation[(int)Direction.SE] = new Animation(_texture, 4, 8, 8, (int)Direction.SE);
            _walkAnimation[(int)Direction.E] = new Animation(_texture, 4, 8, 8, (int)Direction.E);
            _walkAnimation[(int)Direction.NE] = new Animation(_texture, 4, 8, 8, (int)Direction.NE);
            _walkAnimation[(int)Direction.N] = new Animation(_texture, 4, 8, 8, (int)Direction.N);
            _walkAnimation[(int)Direction.NW] = new Animation(_texture, 4, 8, 8, (int)Direction.NW);
            _walkAnimation[(int)Direction.W] = new Animation(_texture, 4, 8, 8, (int)Direction.W);
            _walkAnimation[(int)Direction.SW] = new Animation(_texture, 4, 8, 8, (int)Direction.SW);

            Face(Direction.S);

            _collider = Collision.World.Create(_x, _y, _texture.width / 4, _texture.height / 8);
        }

        public virtual void Update(float dt)
        {
            _currentAnimation.Update(dt);

            _x = _collider.X;
            _y = _collider.Y;
        }

        public virtual void Draw()
        {
            _currentAnimation.Draw((int)_x, (int)_y);
        }

        public void Face(Direction direction)
        {
            _currentDirection = direction;
            _currentAnimation = _walkAnimation[(int)_currentDirection];
        }
    }
}