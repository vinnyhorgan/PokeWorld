using Humper;

namespace PokeWorld.Game
{
    static class Collision
    {
        public static World World;

        public static void Init()
        {
            World = new World(1000, 1000);
        }
    }
}