namespace PokeWorld.Game.States
{
    class Game : State
    {
        Player _pika;

        public override void Enter()
        {
            _pika = new Player(100, 100);
        }

        public override void Update(float dt)
        {
            _pika.Update(dt);
        }

        public override void Draw()
        {
            _pika.Draw();
        }
    }
}