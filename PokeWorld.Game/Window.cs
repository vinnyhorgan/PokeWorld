using Raylib_cs;

namespace PokeWorld.Game
{
    static class Window
    {
        public static int Width = 960;
        public static int Height = 540;

        private static string _title = "PokeWorld Alpha";

        public static void Init()
        {
            Raylib.SetTraceLogLevel(TraceLogLevel.LOG_NONE);
            Raylib.SetConfigFlags(ConfigFlags.FLAG_MSAA_4X_HINT | ConfigFlags.FLAG_WINDOW_RESIZABLE);
            Raylib.InitWindow(Width, Height, _title);
            Raylib.SetWindowMinSize(Width, Height);

            Raylib.InitAudioDevice();

            Raylib.SetTargetFPS(60);
            Raylib.SetExitKey(KeyboardKey.KEY_NULL);
        }

        public static bool ShouldClose()
        {
            return Raylib.WindowShouldClose();
        }

        public static void Close()
        {
            Raylib.CloseAudioDevice();
            Raylib.CloseWindow();
        }
    }
}