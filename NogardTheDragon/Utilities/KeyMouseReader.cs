using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

internal static class KeyMouseReader
{
    public static KeyboardState keyState, oldKeyState = Keyboard.GetState();
    public static MouseState mouseState, oldMouseState = Mouse.GetState();
    public static Vector2 mousePosition = Vector2.Zero;

    public static bool KeyPressed(Keys key)
    {
        return keyState.IsKeyDown(key) && oldKeyState.IsKeyUp(key);
    }

    public static bool KeyDown(Keys key)
    {
        return keyState.IsKeyDown(key);
    }

    public static bool LeftClick()
    {
        return mouseState.LeftButton == ButtonState.Pressed && oldMouseState.LeftButton == ButtonState.Released;
    }

    public static bool RightClick()
    {
        return mouseState.RightButton == ButtonState.Pressed && oldMouseState.RightButton == ButtonState.Released;
    }

    public static bool MiddleClick()
    {
        return mouseState.MiddleButton == ButtonState.Pressed && oldMouseState.MiddleButton == ButtonState.Released;
    }

    public static bool ScrollUp()
    {
        return mouseState.ScrollWheelValue > oldMouseState.ScrollWheelValue;
    }

    public static bool ScrollDown()
    {
        return mouseState.ScrollWheelValue < oldMouseState.ScrollWheelValue;
    }

    //Should be called at beginning of Update in Game
    public static void Update()
    {
        oldKeyState = keyState;
        keyState = Keyboard.GetState();
        oldMouseState = mouseState;
        mouseState = Mouse.GetState();
        mousePosition = new Vector2(mouseState.X, mouseState.Y);
    }
}