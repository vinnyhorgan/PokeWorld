namespace PokeWorld.Game
{
    static class StateManager
    {
        public static State Current;

        public static void Switch(State state)
        {
            Current = state;
        }
    }
}