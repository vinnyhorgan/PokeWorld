namespace PokeWorld.Game
{
    static class StateManager
    {
        public static State Current;

        public static void Switch(State state)
        {
            if (Current != null)
            {
                Current.Leave();
            }

            Current = state;
            Current.Enter();
        }
    }
}