using Raylib_cs;
using System;
using System.Numerics;

namespace PokeWorld.Game
{
    class Program
    {
        public static void Main()
        {
            Window.Init();

            RenderTexture2D target = Raylib.LoadRenderTexture(Window.Width, Window.Height);
            Raylib.SetTextureFilter(target.texture, TextureFilter.TEXTURE_FILTER_POINT);

            ImguiController imgui = new ImguiController();
            imgui.Load(Window.Width, Window.Height);

            StateManager.Switch(new States.Game());

            while (!Window.ShouldClose())
            {
                float dt = Raylib.GetFrameTime();
                float scale = Math.Min((float)Raylib.GetScreenWidth() / Window.Width, (float)Raylib.GetScreenHeight() / Window.Height);

                Mouse.Update(scale);

                StateManager.Current.Update(dt);

                imgui.Update(dt);

                Raylib.BeginDrawing();

                Raylib.ClearBackground(Color.BLACK);

                Raylib.BeginTextureMode(target);

                Raylib.ClearBackground(Color.BLACK);

                StateManager.Current.Draw();

                Raylib.EndTextureMode();

                Rectangle sourceRec = new Rectangle(
                    0.0f,
                    0.0f,
                    (float)target.texture.width,
                    (float)-target.texture.height
                );

                Rectangle destRec = new Rectangle(
                    (Raylib.GetScreenWidth() - ((float)Window.Width * scale)) * 0.5f,
                    (Raylib.GetScreenHeight() - ((float)Window.Height * scale)) * 0.5f,
                    (float)Window.Width * scale,
                    (float)Window.Height * scale
                );

                Raylib.DrawTexturePro(target.texture, sourceRec, destRec, new Vector2(0, 0), 0.0f, Color.WHITE);

                imgui.Draw();

                Raylib.EndDrawing();
            }

            Raylib.UnloadRenderTexture(target);

            imgui.Dispose();

            Window.Close();
        }
    }
}