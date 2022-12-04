using Raylib_cs;
using System.Numerics;

namespace PokeWorld.Game
{
    class Animation
    {
        private Texture2D _texture;
        private int _cols;
        private int _rows;
        private int _fps;
        private int _animationRow;
        private Rectangle _grid;
        private int _currentFrame;
        private float _timer;
        private bool _play;

        public Animation(Texture2D texture, int cols, int rows, int fps, int animationRow)
        {
            _texture = texture;
            _cols = cols;
            _rows = rows;
            _fps = fps;
            _animationRow = animationRow;

            _grid = new Rectangle(0.0f, _animationRow * (float)_texture.height / _rows, (float)_texture.width / _cols, (float)_texture.height / _rows);
            _currentFrame = 0;
            _timer = 0;
            _play = true;
        }

        public void Update(float dt)
        {
            if (_play)
            {
                _timer += dt;

                if (_timer > 1.0f / _fps)
                {
                    _currentFrame++;

                    if (_currentFrame > _cols - 1)
                    {
                        _currentFrame = 0;
                    }

                    _grid.x = (float)_currentFrame * (float)_texture.width / _cols;

                    _timer = 0;
                }
            }
        }

        public void Draw(int x, int y)
        {
            Raylib.DrawTextureRec(_texture, _grid, new Vector2(x, y), Color.WHITE);
        }

        public void Stop()
        {
            _play = false;
        }

        public void Resume()
        {
            _play = true;
        }

        public void GotoFrame(int frame)
        {
            _currentFrame = frame;

            if (_currentFrame > _cols - 1)
            {
                _currentFrame = 0;
            }

            _grid.x = (float)_currentFrame * (float)_texture.width / _cols;
        }
    }
}