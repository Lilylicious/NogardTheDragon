using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

internal static class KeyMouseReader
{
    public static KeyboardState KeyState, OldKeyState = Keyboard.GetState();
    public static MouseState MouseState, OldMouseState = Mouse.GetState();
    public static Vector2 MousePosition = Vector2.Zero;

    public static bool KeyPressed(Keys key)
    {
        return KeyState.IsKeyDown(key) && OldKeyState.IsKeyUp(key);
    }

    public static bool KeyDown(Keys key)
    {
        return KeyState.IsKeyDown(key);
    }

    public static bool LeftClick()
    {
        return MouseState.LeftButton == ButtonState.Pressed && OldMouseState.LeftButton == ButtonState.Released;
    }

    public static bool RightClick()
    {
        return MouseState.RightButton == ButtonState.Pressed && OldMouseState.RightButton == ButtonState.Released;
    }

    public static bool MiddleClick()
    {
        return MouseState.MiddleButton == ButtonState.Pressed && OldMouseState.MiddleButton == ButtonState.Released;
    }

    public static bool ScrollUp()
    {
        return MouseState.ScrollWheelValue > OldMouseState.ScrollWheelValue;
    }

    public static bool ScrollDown()
    {
        return MouseState.ScrollWheelValue < OldMouseState.ScrollWheelValue;
    }

    //Should be called at beginning of Update in Game
    public static void Update()
    {
        OldKeyState = KeyState;
        KeyState = Keyboard.GetState();
        OldMouseState = MouseState;
        MouseState = Mouse.GetState();
        MousePosition = new Vector2(MouseState.X, MouseState.Y);
    }
}