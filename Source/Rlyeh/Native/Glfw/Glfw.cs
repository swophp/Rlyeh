namespace Rlyeh.Native.Glfw;

using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;

public static unsafe partial class Glfw
{
    private static nint _glfwLibraryHandle;
    private static bool _glfwLibraryLoaded;

    public const int True = 1;
    public const int False = 0;

    public const int CursorNormal = 0x00034001;
    public const int CursorHidden = 0x00034002;
    public const int CursorDisabled = 0x00034003;

    public static bool Init()
    {
        if(_glfwLibraryLoaded)
        {
            return _glfwInitDelegate() == True;
        }

        var libraryName = "./runtimes/win-x64/native/glfw3.dll";
        if(RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
        {
            libraryName = RuntimeInformation.RuntimeIdentifier.Contains("ubuntu")
                ? File.Exists("/usr/local/lib/libglfw.so")
                    ? "/usr/local/lib/libglfw.so"
                    : "libglfw.so.3"
                : "libglfw.so.3";
        }

        if(!NativeLibrary.TryLoad(libraryName, out _glfwLibraryHandle))
        {
            Debug.WriteLine($"GLFW: Unable to load {libraryName}");
            return false;
        }

        _glfwLibraryLoaded = true;

        return _glfwInitDelegate() == True;
    }

    public static void Terminate()
    {
        _glfwTerminateDelegate();
        if(_glfwLibraryLoaded)
        {
            NativeLibrary.Free(_glfwLibraryHandle);
        }
    }

    public static bool IsRawMouseMotionSupported()
    {
        return _glfwRawMouseMotionSupportedDelegate() == True;
    }

    public static bool IsExtensionSupported(string extensionName)
    {
        var extensionNamePtr = Marshal.StringToHGlobalAnsi(extensionName);
        var result = _glfwExtensionSupported(extensionNamePtr);
        Marshal.FreeHGlobal(extensionNamePtr);

        return result == True;
    }

    public static KeyAction GetKey(nint windowHandle, Key key)
    {
        return _glfwGetKeyDelegate(windowHandle, key);
    }

    public static bool GetKeyPressed(nint windowHandle, Key key)
    {
        var keyAction = _glfwGetKeyDelegate(windowHandle, key);
        return keyAction is KeyAction.Pressed or KeyAction.Repeat;
    }

    public static void SetInputMode(
        nint windowHandle,
        InputMode inputMode,
        int value)
    {
        _glfwSetInputModeDelegate(windowHandle, inputMode, value);
    }

    public static void GetCursorPos(
        nint windowHandle,
        out int x,
        out int y)
    {
        double cursorPosX;
        double cursorPosY;
        _glfwGetCursorPosDelegate(windowHandle, &cursorPosX, &cursorPosY);
        x = (int) cursorPosX;
        y = (int) cursorPosY;
    }

    public static void GetMonitorPos(
        nint monitorHandle,
        out int left,
        out int top)
    {
        int leftNative;
        int topNative;
        _glfwGetMonitorPosDelegate(monitorHandle, &leftNative, &topNative);
        left = leftNative;
        top = topNative;
    }

    public static void GetMonitorWorkarea(
        nint monitorHandle,
        out int left,
        out int top,
        out int width,
        out int height)
    {
        int leftNative;
        int topNative;
        int widthNative;
        int heightNative;
        _glfwGetMonitorWorkareaDelegate(monitorHandle, &leftNative, &topNative, &widthNative, &heightNative);
        left = leftNative;
        top = topNative;
        width = widthNative;
        height = heightNative;
    }

    public static void SetCursorPos(
        nint windowHandle,
        float x,
        float y)
    {
        _glfwSetCursorPosDelegate(windowHandle, x, y);
    }

    public static void WindowHint(
        WindowInitHint windowInitHint,
        bool value)
    {
        _glfwWindowHintDelegate((int) windowInitHint, value ? True : False);
    }

    public static void WindowHint(
        WindowInitHint windowInitHint,
        int value)
    {
        _glfwWindowHintDelegate((int) windowInitHint, value);
    }

    public static void WindowHint(
        WindowInitHint windowInitHint,
        ClientApi clientApi)
    {
        _glfwWindowHintDelegate((int) windowInitHint, (int) clientApi);
    }

    public static void WindowHint(
        FramebufferInitHint framebufferInitHint,
        int value)
    {
        _glfwWindowHintDelegate((int) framebufferInitHint, value);
    }

    public static void WindowHint(
        FramebufferInitHint framebufferInitHint,
        bool value)
    {
        _glfwWindowHintDelegate((int) framebufferInitHint, value ? True : False);
    }

    public static void WindowHint(
        WindowOpenGLContextHint openglContextHint,
        int value)
    {
        _glfwWindowHintDelegate((int) openglContextHint, value);
    }

    public static void WindowHint(
        WindowOpenGLContextHint openglContextHint,
        bool value)
    {
        _glfwWindowHintDelegate((int) openglContextHint, value ? True : False);
    }

    public static void WindowHint(
        WindowOpenGLContextHint openglContextHint,
        OpenGLProfile openGlProfile)
    {
        _glfwWindowHintDelegate((int) openglContextHint, (int) openGlProfile);
    }

    public static nint CreateWindow(
        int width,
        int height,
        string title,
        nint monitorHandle,
        nint sharedHandle)
    {
        var titlePtr = Marshal.StringToHGlobalAnsi(title);
        var windowHandle = _glfwCreateWindowDelegate(
            width,
            height,
            titlePtr,
            monitorHandle,
            sharedHandle);
        Marshal.FreeHGlobal(titlePtr);
        return windowHandle;
    }

    public static void DestroyWindow(nint windowHandle)
    {
        _glfwDestroyWindowDelegate(windowHandle);
    }

    public static bool ShouldWindowClose(nint windowHandle)
    {
        return _glfwWindowShouldCloseDelegate(windowHandle) == True;
    }

    public static void SetWindowShouldClose(
        nint windowHandle,
        int closeFlag)
    {
        _glfwSetWindowShouldCloseDelegate(windowHandle, closeFlag);
    }

    public static void PollEvents()
    {
        _glfwPollEventsDelegate();
    }

    public static void WaitEventsTimeout(double timeout)
    {
        _glfwWaitEventsTimeoutDelegate(timeout);
    }

    public static void SwapBuffers(nint windowHandle)
    {
        _glfwSwapBuffersDelegate(windowHandle);
    }

    public static nint GetProcAddress(string functionName)
    {
        var functionNamePtr = Marshal.StringToHGlobalAnsi(functionName);
        var functionAddress = _glfwGetProcAddressDelegate(functionNamePtr);
        Marshal.FreeHGlobal(functionNamePtr);

        return functionAddress;
    }

    public static void MakeContextCurrent(nint windowHandle)
    {
        _glfwMakeContextCurrentDelegate(windowHandle);
    }

    public static void SwapInterval(int interval)
    {
        _glfwSwapIntervalDelegate(interval);
    }

    public static void SetWindowPos(
        nint windowHandle,
        int left,
        int top)
    {
        _glfwSetWindowPosDelegate(windowHandle, left, top);
    }

    public static void SetWindowSize(
        nint windowHandle,
        int width,
        int height)
    {
        _glfwSetWindowSizeDelegate(windowHandle, width, height);
    }

    public static void GetWindowSize(
        nint windowHandle,
        out int width,
        out int height)
    {
        var windowWidth = 0;
        var windowHeight = 0;
        _glfwGetWindowSizeDelegate(windowHandle, &windowWidth, &windowHeight);
        width = windowWidth;
        height = windowHeight;
    }

    public static void GetWindowPos(
        nint windowHandle,
        out int left,
        out int top)
    {
        var windowPosLeft = 0;
        var windowPosTop = 0;
        _glfwGetWindowPosDelegate(windowHandle, &windowPosLeft, &windowPosTop);
        left = windowPosLeft;
        top = windowPosTop;
    }

    public static nint GetPrimaryMonitor()
    {
        return _glfwGetPrimaryMonitorDelegate();
    }

    public static VideoMode GetVideoMode(nint monitorHandle)
    {
        var videoMode = _glfwGetVideoModeDelegate(monitorHandle);
        return Marshal.PtrToStructure<VideoMode>(videoMode);
    }

    public static void SetKeyCallback(
        nint windowHandle,
        KeyCallback? keyCallback)
    {
        var keyCallbackPtr = keyCallback == null
            ? nint.Zero
            : Marshal.GetFunctionPointerForDelegate(keyCallback);
        _glfwSetKeyCallbackDelegate(windowHandle, keyCallbackPtr);
    }

    public static void SetCharCallback(
        nint windowHandle,
        CharCallback? charCallback)
    {
        var charCallbackPtr = charCallback == null
            ? nint.Zero
            : Marshal.GetFunctionPointerForDelegate(charCallback);
        _glfwSetCharCallbackDelegate(windowHandle, charCallbackPtr);
    }

    public static void SetCursorPositionCallback(
        nint windowHandle,
        CursorPositionCallback? cursorPositionCallback)
    {
        var cursorPositionCallbackPtr = cursorPositionCallback == null
            ? nint.Zero
            : Marshal.GetFunctionPointerForDelegate(cursorPositionCallback);
        _glfwSetCursorPosCallbackDelegate(windowHandle, cursorPositionCallbackPtr);
    }

    public static void SetCursorEnterCallback(
        nint windowHandle,
        CursorEnterCallback? cursorEnterCallback)
    {
        var cursorEnterCallbackPtr = cursorEnterCallback == null
            ? nint.Zero
            : Marshal.GetFunctionPointerForDelegate(cursorEnterCallback);
        _glfwSetCursorEnterCallbackDelegate(windowHandle, cursorEnterCallbackPtr);
    }

    public static void SetMouseButtonCallback(
        nint windowHandle,
        MouseButtonCallback? mouseButtonCallback)
    {
        var mouseButtonCallbackPtr = mouseButtonCallback == null
            ? nint.Zero
            : Marshal.GetFunctionPointerForDelegate(mouseButtonCallback);
        _glfwSetMouseButtonCallbackDelegate(windowHandle, mouseButtonCallbackPtr);
    }

    public static void SetWindowSizeCallback(
        nint windowHandle,
        WindowSizeCallback? windowSizeCallback)
    {
        var sizeWindowCallbackPtr = windowSizeCallback == null
            ? nint.Zero
            : Marshal.GetFunctionPointerForDelegate(windowSizeCallback);
        _glfwSetWindowSizeCallbackDelegate(windowHandle, sizeWindowCallbackPtr);
    }

    public static void SetFramebufferSizeCallback(
        nint windowHandle,
        FramebufferSizeCallback? framebufferSizeCallback)
    {
        var framebufferSizeCallbackPtr = framebufferSizeCallback == null
            ? nint.Zero
            : Marshal.GetFunctionPointerForDelegate(framebufferSizeCallback);
        _glfwSetFramebufferSizeCallbackDelegate(windowHandle, framebufferSizeCallbackPtr);
    }

    public static void SetScrollCallback(nint windowHandle, ScrollCallback? scrollCallback)
    {
        var scrollCallbackPtr = scrollCallback == null
            ? nint.Zero
            : Marshal.GetFunctionPointerForDelegate(scrollCallback);
        _glfwSetScrollCallbackDelegate(windowHandle, scrollCallbackPtr);
    }

    public static void SetErrorCallback(ErrorCallback? errorCallback)
    {
        var errorCallbackPtr = errorCallback == null
            ? nint.Zero
            : Marshal.GetFunctionPointerForDelegate(errorCallback);
        _glfwSetErrorCallbackDelegate(errorCallbackPtr);
    }

    public static float GetTime()
    {
        return (float) _glfwGetTimeDelegate();
    }


    public static void GetFramebufferSize(
        nint windowHandle,
        out int framebufferWidth,
        out int framebufferHeight)
    {
        int width;
        int height;
        _glfwGetFramebufferSizeDelegate(windowHandle, &width, &height);
        framebufferWidth = width;
        framebufferHeight = height;
    }

    public static void SetWindowIcon(nint windowHandle, Image image)
    {
        _glfwSetWindowIconDelegate(windowHandle, 1, &image);
    }

    public static void MaximizeWindow(nint windowHandle)
    {
        _glfwMaximizeWindowDelegate(windowHandle);
    }

    public static void RestoreWindow(nint windowHandle)
    {
        _glfwRestoreWindowDelegate(windowHandle);
    }
}