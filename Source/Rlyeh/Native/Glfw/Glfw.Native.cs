namespace Rlyeh.Native.Glfw;

using System;
using System.Runtime.InteropServices;

public static unsafe partial class Glfw
{
    private static delegate* unmanaged<int> _glfwInitDelegate = &glfwInit;

    private static delegate* unmanaged<void> _glfwTerminateDelegate = &glfwTerminate;

    private static delegate* unmanaged<nint, int> _glfwExtensionSupported = &glfwExtensionSupported;

    private static delegate* unmanaged<int> _glfwRawMouseMotionSupportedDelegate = &glfwRawMouseMotionSupported;

    private static delegate* unmanaged<nint, Rlyeh.Native.Glfw.Glfw.InputMode, int, void> _glfwSetInputModeDelegate = &glfwSetInputMode;

    private static delegate* unmanaged<int, void> _glfwSwapIntervalDelegate = &glfwSwapInterval;

    private static delegate* unmanaged<nint, double*, double*, void> _glfwGetCursorPosDelegate = &glfwGetCursorPos;

    private static delegate* unmanaged<nint, int*, int*, void> _glfwGetMonitorPosDelegate = &glfwGetMonitorPos;

    private static delegate* unmanaged<nint, int*, int*, int*, int*, void> _glfwGetMonitorWorkareaDelegate =
        &glfwGetMonitorWorkarea;

    private static delegate* unmanaged<int, int, void> _glfwWindowHintDelegate = &glfwWindowHint;

    private static delegate* unmanaged<int, int, nint, nint, nint, nint> _glfwCreateWindowDelegate = &glfwCreateWindow;

    private static delegate* unmanaged<nint, void> _glfwDestroyWindowDelegate = &glfwDestroyWindow;

    private static delegate* unmanaged<nint, int> _glfwWindowShouldCloseDelegate = &glfwWindowShouldClose;

    private static delegate* unmanaged<nint, int, void> _glfwSetWindowShouldCloseDelegate = &glfwSetWindowShouldClose;

    private static delegate* unmanaged<void> _glfwPollEventsDelegate = &glfwPollEvents;

    private static delegate* unmanaged<double, void> _glfwWaitEventsTimeoutDelegate = &glfwWaitEventsTimeout;

    private static delegate* unmanaged<nint, void> _glfwSwapBuffersDelegate = &glfwSwapBuffers;

    private static delegate* unmanaged<nint, nint> _glfwGetProcAddressDelegate = &glfwGetProcAddress;

    private static delegate* unmanaged<nint, void> _glfwMakeContextCurrentDelegate = &glfwMakeContextCurrent;

    private static delegate* unmanaged<nint, int, int, void> _glfwSetWindowPosDelegate = &glfwSetWindowPos;

    private static delegate* unmanaged<nint, int, int, void> _glfwSetWindowSizeDelegate = &glfwSetWindowSize;

    private static delegate* unmanaged<nint, int*, int*, void> _glfwGetWindowPosDelegate = &glfwGetWindowPos;

    private static delegate* unmanaged<nint, int*, int*, void> _glfwGetWindowSizeDelegate = &glfwGetWindowSize;

    private static delegate* unmanaged<nint> _glfwGetPrimaryMonitorDelegate = &glfwGetPrimaryMonitor;

    private static delegate* unmanaged<nint, nint> _glfwGetVideoModeDelegate = &glfwGetVideoMode;

    private static delegate* unmanaged<nint, nint, void> _glfwSetKeyCallbackDelegate = &glfwSetKeyCallback;

    private static delegate* unmanaged<nint, nint, nint> _glfwSetCharCallbackDelegate = &glfwSetCharCallback;

    private static delegate* unmanaged<nint, nint, void> _glfwSetCursorPosCallbackDelegate =
        &glfwSetCursorPosCallback;

    private static delegate* unmanaged<nint, nint, void> _glfwSetCursorEnterCallbackDelegate = &glfwSetCursorEnterCallback;

    private static delegate* unmanaged<nint, nint, void> _glfwSetMouseButtonCallbackDelegate = &glfwSetMouseButtonCallback;

    private static delegate* unmanaged<nint, nint, void>
        _glfwSetWindowSizeCallbackDelegate = &glfwSetWindowSizeCallback;

    private static delegate* unmanaged<nint, nint, void> _glfwSetFramebufferSizeCallbackDelegate =
        &glfwSetFramebufferSizeCallback;

    private static delegate* unmanaged<nint, nint, void> _glfwSetScrollCallbackDelegate =
        &glfwSetScrollCallback;

    private static delegate* unmanaged<nint, int*, int*, void> _glfwGetFramebufferSizeDelegate = &glfwGetFramebufferSize;

    private static delegate* unmanaged<double> _glfwGetTimeDelegate = &glfwGetTime;

    private static delegate* unmanaged<nint, double, double, void> _glfwSetCursorPosDelegate = &glfwSetCursorPos;

    private static delegate* unmanaged<nint, Rlyeh.Native.Glfw.Glfw.Key, Rlyeh.Native.Glfw.Glfw.KeyAction> _glfwGetKeyDelegate = &glfwGetKey;

    private static delegate* unmanaged<nint, void> _glfwSetErrorCallbackDelegate = &glfwSetErrorCallback;

    private static delegate* unmanaged<nint, int, Image*, void> _glfwSetWindowIconDelegate = &glfwSetWindowIcon;

    private static delegate* unmanaged<nint, void> _glfwMaximizeWindowDelegate = &glfwMaximizeWindow;

    private static delegate* unmanaged<nint, void> _glfwRestoreWindowDelegate = &glfwRestoreWindow;

    [UnmanagedCallersOnly]
    private static void glfwSetErrorCallback(nint callback)
    {
        _glfwSetErrorCallbackDelegate = (delegate* unmanaged<nint, void>) NativeLibrary.GetExport(_glfwLibraryHandle, nameof(glfwSetErrorCallback));
        _glfwSetErrorCallbackDelegate(callback);
    }

    [UnmanagedCallersOnly]
    private static int glfwInit()
    {
        _glfwInitDelegate = (delegate* unmanaged<int>) NativeLibrary.GetExport(_glfwLibraryHandle, nameof(glfwInit));
        return _glfwInitDelegate();
    }

    [UnmanagedCallersOnly]
    private static void glfwSetCursorPos(nint windowHandle, double x, double y)
    {
        _glfwSetCursorPosDelegate =
            (delegate* unmanaged<nint, double, double, void>) NativeLibrary.GetExport(_glfwLibraryHandle,
                nameof(glfwSetCursorPos));
        _glfwSetCursorPosDelegate(windowHandle, x, y);
    }

    [UnmanagedCallersOnly]
    private static Rlyeh.Native.Glfw.Glfw.KeyAction glfwGetKey(nint windowHandle, Rlyeh.Native.Glfw.Glfw.Key key)
    {
        _glfwGetKeyDelegate = (delegate* unmanaged<nint, Rlyeh.Native.Glfw.Glfw.Key, Rlyeh.Native.Glfw.Glfw.KeyAction>) NativeLibrary.GetExport(_glfwLibraryHandle, nameof(glfwGetKey));
        return _glfwGetKeyDelegate(windowHandle, key);
    }

    [UnmanagedCallersOnly]
    private static void glfwTerminate()
    {
        _glfwTerminateDelegate = (delegate* unmanaged<void>) NativeLibrary.GetExport(_glfwLibraryHandle, nameof(glfwTerminate));
        if(_glfwTerminateDelegate != null)
        {
            _glfwTerminateDelegate();
        }
    }

    [UnmanagedCallersOnly]
    private static int glfwExtensionSupported(nint extensionName)
    {
        _glfwExtensionSupported = (delegate* unmanaged<nint, int>) NativeLibrary.GetExport(_glfwLibraryHandle, nameof(glfwExtensionSupported));
        return _glfwExtensionSupported(extensionName);
    }

    [UnmanagedCallersOnly]
    private static int glfwRawMouseMotionSupported()
    {
        _glfwRawMouseMotionSupportedDelegate = (delegate* unmanaged<int>) NativeLibrary.GetExport(_glfwLibraryHandle,
            nameof(glfwRawMouseMotionSupported));
        return _glfwRawMouseMotionSupportedDelegate();
    }

    [UnmanagedCallersOnly]
    private static void glfwSetInputMode(nint windowHandle, Rlyeh.Native.Glfw.Glfw.InputMode mode, int value)
    {
        _glfwSetInputModeDelegate = (delegate* unmanaged<nint, Rlyeh.Native.Glfw.Glfw.InputMode, int, void>) NativeLibrary.GetExport(_glfwLibraryHandle, nameof(glfwSetInputMode));
        _glfwSetInputModeDelegate(windowHandle, mode, value);
    }

    [UnmanagedCallersOnly]
    private static void glfwGetMonitorPos(
        nint monitorHandle,
        int* left,
        int* top)
    {
        _glfwGetMonitorPosDelegate = (delegate* unmanaged<nint, int*, int*, void>) NativeLibrary.GetExport(_glfwLibraryHandle, nameof(glfwGetMonitorPos));
        _glfwGetMonitorPosDelegate(monitorHandle, left, top);
    }

    [UnmanagedCallersOnly]
    private static void glfwGetMonitorWorkarea(
        nint monitorHandle,
        int* left,
        int* top,
        int* width,
        int* height)
    {
        _glfwGetMonitorWorkareaDelegate = (delegate* unmanaged<nint, int*, int*, int*, int*, void>) NativeLibrary.GetExport(_glfwLibraryHandle, nameof(glfwGetMonitorWorkarea));
        _glfwGetMonitorWorkareaDelegate(monitorHandle, left, top, width, height);
    }

    [UnmanagedCallersOnly]
    private static void glfwGetCursorPos(
        nint windowHandle,
        double* x,
        double* y)
    {
        _glfwGetCursorPosDelegate = (delegate* unmanaged<nint, double*, double*, void>) NativeLibrary.GetExport(_glfwLibraryHandle, nameof(glfwGetCursorPos));
        _glfwGetCursorPosDelegate(windowHandle, x, y);
    }

    [UnmanagedCallersOnly]
    private static void glfwWindowHint(
        int hint,
        int value)
    {
        _glfwWindowHintDelegate = (delegate* unmanaged<int, int, void>) NativeLibrary.GetExport(_glfwLibraryHandle, nameof(glfwWindowHint));
        _glfwWindowHintDelegate(hint, value);
    }

    [UnmanagedCallersOnly]
    private static nint glfwCreateWindow(
        int width,
        int height,
        nint windowTitle,
        nint monitorHandle,
        nint sharedHandle)
    {
        _glfwCreateWindowDelegate = (delegate* unmanaged<int, int, nint, nint, nint, nint>) NativeLibrary.GetExport(_glfwLibraryHandle, nameof(glfwCreateWindow));
        return _glfwCreateWindowDelegate(width, height, windowTitle, monitorHandle, sharedHandle);
    }

    [UnmanagedCallersOnly]
    private static void glfwDestroyWindow(nint windowHandle)
    {
        _glfwDestroyWindowDelegate = (delegate* unmanaged<nint, void>) NativeLibrary.GetExport(_glfwLibraryHandle, nameof(glfwDestroyWindow));
        _glfwDestroyWindowDelegate(windowHandle);
    }

    [UnmanagedCallersOnly]
    private static int glfwWindowShouldClose(nint windowHandle)
    {
        _glfwWindowShouldCloseDelegate = (delegate* unmanaged<nint, int>) NativeLibrary.GetExport(_glfwLibraryHandle, nameof(glfwWindowShouldClose));
        return _glfwWindowShouldCloseDelegate(windowHandle);
    }

    [UnmanagedCallersOnly]
    private static void glfwSetWindowShouldClose(nint windowHandle, int closeFlag)
    {
        _glfwSetWindowShouldCloseDelegate = (delegate* unmanaged<nint, int, void>) NativeLibrary.GetExport(_glfwLibraryHandle,
            nameof(glfwSetWindowShouldClose));
        _glfwSetWindowShouldCloseDelegate(windowHandle, closeFlag);
    }

    [UnmanagedCallersOnly]
    private static void glfwPollEvents()
    {
        _glfwPollEventsDelegate = (delegate* unmanaged<void>) NativeLibrary.GetExport(_glfwLibraryHandle, nameof(glfwPollEvents));
        _glfwPollEventsDelegate();
    }

    [UnmanagedCallersOnly]
    private static void glfwWaitEventsTimeout(double timeout)
    {
        _glfwWaitEventsTimeoutDelegate = (delegate* unmanaged<double, void>) NativeLibrary.GetExport(_glfwLibraryHandle, nameof(glfwWaitEventsTimeout));
        _glfwWaitEventsTimeoutDelegate(timeout);
    }

    [UnmanagedCallersOnly]
    private static void glfwSwapBuffers(nint windowHandle)
    {
        _glfwSwapBuffersDelegate = (delegate* unmanaged<nint, void>) NativeLibrary.GetExport(_glfwLibraryHandle, nameof(glfwSwapBuffers));
        _glfwSwapBuffersDelegate(windowHandle);
    }

    [UnmanagedCallersOnly]
    private static nint glfwGetProcAddress(nint functionName)
    {
        _glfwGetProcAddressDelegate =
            (delegate* unmanaged<nint, nint>) NativeLibrary.GetExport(_glfwLibraryHandle,
                nameof(glfwGetProcAddress));
        return _glfwGetProcAddressDelegate(functionName);
    }

    [UnmanagedCallersOnly]
    private static void glfwMakeContextCurrent(nint windowHandle)
    {
        _glfwMakeContextCurrentDelegate = (delegate* unmanaged<nint, void>) NativeLibrary.GetExport(_glfwLibraryHandle, nameof(glfwMakeContextCurrent));
        _glfwMakeContextCurrentDelegate(windowHandle);
    }

    [UnmanagedCallersOnly]
    private static void glfwSwapInterval(int interval)
    {
        _glfwSwapIntervalDelegate = (delegate* unmanaged<int, void>) NativeLibrary.GetExport(_glfwLibraryHandle, nameof(glfwSwapInterval));
        _glfwSwapIntervalDelegate(interval);
    }

    [UnmanagedCallersOnly]
    private static void glfwSetWindowPos(
        nint windowHandle,
        int left,
        int top)
    {
        _glfwSetWindowPosDelegate = (delegate* unmanaged<nint, int, int, void>) NativeLibrary.GetExport(_glfwLibraryHandle, nameof(glfwSetWindowPos));
        _glfwSetWindowPosDelegate(windowHandle, left, top);
    }

    [UnmanagedCallersOnly]
    private static void glfwSetWindowSize(
        nint windowHandle,
        int width,
        int height)
    {
        _glfwSetWindowSizeDelegate =
            (delegate* unmanaged<nint, int, int, void>) NativeLibrary.GetExport(_glfwLibraryHandle,
                nameof(glfwSetWindowSize));
        _glfwSetWindowSizeDelegate(windowHandle, width, height);
    }

    [UnmanagedCallersOnly]
    private static void glfwGetWindowSize(
        nint windowHandle,
        int* width,
        int* height)
    {
        _glfwGetWindowSizeDelegate = (delegate* unmanaged<nint, int*, int*, void>) NativeLibrary.GetExport(_glfwLibraryHandle, nameof(glfwGetWindowSize));
        _glfwGetWindowSizeDelegate(windowHandle, width, height);
    }

    [UnmanagedCallersOnly]
    private static void glfwGetWindowPos(
        nint windowHandle,
        int* left,
        int* top)
    {
        _glfwGetWindowPosDelegate = (delegate* unmanaged<nint, int*, int*, void>) NativeLibrary.GetExport(_glfwLibraryHandle, nameof(glfwGetWindowPos));
        _glfwGetWindowPosDelegate(windowHandle, left, top);
    }

    [UnmanagedCallersOnly]
    private static nint glfwGetPrimaryMonitor()
    {
        _glfwGetPrimaryMonitorDelegate =
            (delegate* unmanaged<nint>) NativeLibrary.GetExport(_glfwLibraryHandle, nameof(glfwGetPrimaryMonitor));
        return _glfwGetPrimaryMonitorDelegate();
    }

    [UnmanagedCallersOnly]
    private static nint glfwGetVideoMode(nint monitorHandle)
    {
        _glfwGetVideoModeDelegate =
            (delegate* unmanaged<nint, nint>) NativeLibrary.GetExport(_glfwLibraryHandle, nameof(glfwGetVideoMode));
        return _glfwGetVideoModeDelegate(monitorHandle);
    }

    [UnmanagedCallersOnly]
    private static void glfwSetKeyCallback(
        nint windowHandle,
        nint keyCallback)
    {
        _glfwSetKeyCallbackDelegate =
            (delegate* unmanaged<nint, nint, void>) NativeLibrary.GetExport(_glfwLibraryHandle,
                nameof(glfwSetKeyCallback));
        _glfwSetKeyCallbackDelegate(windowHandle, keyCallback);
    }

    [UnmanagedCallersOnly]
    private static nint glfwSetCharCallback(
        nint windowHandle,
        nint charCallback)
    {
        _glfwSetCharCallbackDelegate =
            (delegate* unmanaged<nint, nint, nint>) NativeLibrary.GetExport(_glfwLibraryHandle,
                nameof(glfwSetCharCallback));
        return _glfwSetCharCallbackDelegate(windowHandle, charCallback);
    }

    [UnmanagedCallersOnly]
    private static void glfwSetCursorPosCallback(
        nint windowHandle,
        nint cursorPositionCallback)
    {
        _glfwSetCursorPosCallbackDelegate = (delegate* unmanaged<nint, nint, void>) NativeLibrary.GetExport(
            _glfwLibraryHandle,
            nameof(glfwSetCursorPosCallback));
        _glfwSetCursorPosCallbackDelegate(windowHandle, cursorPositionCallback);
    }

    [UnmanagedCallersOnly]
    private static void glfwSetCursorEnterCallback(
        nint windowHandle,
        nint cursorEnterCallback)
    {
        _glfwSetCursorEnterCallbackDelegate = (delegate* unmanaged<nint, nint, void>) NativeLibrary.GetExport(_glfwLibraryHandle,
            nameof(glfwSetCursorEnterCallback));
        _glfwSetCursorEnterCallbackDelegate(windowHandle, cursorEnterCallback);
    }

    [UnmanagedCallersOnly]
    private static void glfwSetMouseButtonCallback(
        nint windowHandle,
        nint mouseButtonCallback)
    {
        _glfwSetMouseButtonCallbackDelegate = (delegate* unmanaged<nint, nint, void>) NativeLibrary.GetExport(_glfwLibraryHandle,
            nameof(glfwSetMouseButtonCallback));
        _glfwSetMouseButtonCallbackDelegate(windowHandle, mouseButtonCallback);
    }

    [UnmanagedCallersOnly]
    private static void glfwSetWindowSizeCallback(
        nint windowHandle,
        nint windowSizeCallback)
    {
        _glfwSetWindowSizeCallbackDelegate = (delegate* unmanaged<nint, nint, void>) NativeLibrary.GetExport(_glfwLibraryHandle,
            nameof(glfwSetWindowSizeCallback));
        _glfwSetWindowSizeCallbackDelegate(windowHandle, windowSizeCallback);
    }

    [UnmanagedCallersOnly]
    private static void glfwSetFramebufferSizeCallback(
        nint windowHandle,
        nint framebufferSizeCallback)
    {
        _glfwSetFramebufferSizeCallbackDelegate =
            (delegate* unmanaged<nint, nint, void>) NativeLibrary.GetExport(_glfwLibraryHandle,
                nameof(glfwSetFramebufferSizeCallback));
        _glfwSetFramebufferSizeCallbackDelegate(windowHandle, framebufferSizeCallback);
    }

    [UnmanagedCallersOnly]
    private static void glfwSetScrollCallback(nint windowHandle, nint scrollCallback)
    {
        _glfwSetScrollCallbackDelegate =
            (delegate* unmanaged<nint, nint, void>) NativeLibrary.GetExport(_glfwLibraryHandle,
                nameof(glfwSetScrollCallback));
        _glfwSetScrollCallbackDelegate(windowHandle, scrollCallback);
    }

    [UnmanagedCallersOnly]
    private static void glfwGetFramebufferSize(nint windowHandle, int* width, int* height)
    {
        _glfwGetFramebufferSizeDelegate =
            (delegate* unmanaged<nint, int*, int*, void>) NativeLibrary.GetExport(_glfwLibraryHandle,
                nameof(glfwGetFramebufferSize));
        _glfwGetFramebufferSizeDelegate(windowHandle, width, height);
    }

    [UnmanagedCallersOnly]
    private static double glfwGetTime()
    {
        _glfwGetTimeDelegate =
            (delegate* unmanaged<double>) NativeLibrary.GetExport(_glfwLibraryHandle, nameof(glfwGetTime));
        return _glfwGetTimeDelegate();
    }

    [UnmanagedCallersOnly]
    private static void glfwSetWindowIcon(nint windowHandle, int imageCount, Image* images)
    {
        _glfwSetWindowIconDelegate = (delegate* unmanaged<nint, int, Image*, void>) NativeLibrary.GetExport(_glfwLibraryHandle, nameof(glfwSetWindowIcon));
        _glfwSetWindowIconDelegate(windowHandle, imageCount, images);
    }

    [UnmanagedCallersOnly]
    private static void glfwMaximizeWindow(nint windowHandle)
    {
        _glfwMaximizeWindowDelegate = (delegate* unmanaged<nint, void>) NativeLibrary.GetExport(_glfwLibraryHandle, nameof(glfwMaximizeWindow));
        _glfwMaximizeWindowDelegate(windowHandle);
    }

    [UnmanagedCallersOnly]
    private static void glfwRestoreWindow(nint windowHandle)
    {
        _glfwRestoreWindowDelegate = (delegate* unmanaged<nint, void>) NativeLibrary.GetExport(_glfwLibraryHandle, nameof(glfwRestoreWindow));
        _glfwRestoreWindowDelegate(windowHandle);
    }
}