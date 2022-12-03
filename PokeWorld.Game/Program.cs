using Raylib_cs;

namespace PokeWorld.Game
{
    class Program
    {
        public static void Main()
        {
            const int width = 800;
            const int height = 600;

            Raylib.SetTraceLogLevel(TraceLogLevel.LOG_NONE);
            Raylib.SetConfigFlags(ConfigFlags.FLAG_MSAA_4X_HINT | ConfigFlags.FLAG_WINDOW_RESIZABLE);
            Raylib.InitWindow(width, height, "PokeWorld Alpha");
            Raylib.SetTargetFPS(60);
            Raylib.SetExitKey(KeyboardKey.KEY_NULL);

            ImguiController imgui = new ImguiController();
            imgui.Load(width, height);

            StateManager.Switch(new States.Game());

            while (!Raylib.WindowShouldClose())
            {
                float dt = Raylib.GetFrameTime();

                StateManager.Current.Update(dt);

                imgui.Update(dt);

                Raylib.BeginDrawing();

                Raylib.ClearBackground(Color.BLACK);

                StateManager.Current.Draw();

                imgui.Draw();

                Raylib.EndDrawing();
            }

            imgui.Dispose();

            Raylib.CloseWindow();
        }
    }
}