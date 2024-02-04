namespace Rlyeh.Native.Glfw;

using System;

public static partial class Glfw
{
    public delegate void KeyCallback(
        nint windowHandle,
        Key key,
        Scancode scanCode,
        KeyAction action,
        KeyModifiers modifiers);

    public delegate void CharCallback(
        nint windowHandle,
        uint codePoint);

    public delegate void CursorPositionCallback(
        nint windowHandle,
        double x,
        double y);

    public delegate void CursorEnterCallback(
        nint windowHandle,
        CursorEnterMode cursorEnterMode);

    public delegate void MouseButtonCallback(
        nint windowHandle,
        MouseButton mouseButton,
        KeyAction action,
        KeyModifiers modifiers);

    public delegate void WindowSizeCallback(
        nint windowHandle,
        int width,
        int height);

    public delegate void FramebufferSizeCallback(
        nint windowHandle,
        int width,
        int height);

    public delegate void ScrollCallback(
        nint windowHandle,
        double scrollX,
        double scrollY);

    public delegate void ErrorCallback(
        ErrorCode error,
        string description);
}


