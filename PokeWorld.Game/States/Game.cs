using Humper;

namespace PokeWorld.Game.States
{
    class Game : State
    {
        public static World World;

        Player _pika;
        Entity _test;

        public override void Enter()
        {
            World = new World(1000, 1000);

            _pika = new Player(100, 100);
            _test = new Entity("Graphics/025.png", 400, 400);
        }

        public override void Update(float dt)
        {
            _pika.Update(dt);
            _test.Update(dt);
        }

        public override void Draw()
        {
            _pika.Draw();
            _test.Draw();
        }
    }
}