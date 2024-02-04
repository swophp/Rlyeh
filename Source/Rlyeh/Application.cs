// ReSharper disable All
namespace Rlyeh;

using Rlyeh.Mathematics;
using Rlyeh.Native.Glfw;
using Serilog;
using System.Numerics;
using System.Threading;
using System.Threading.Tasks;
using static Rlyeh.Native.Glfw.Glfw;

public class Application : IApplication
{
    private readonly ILogger _logger;
    private readonly IApplicationContext _applicationContext;
    private nint _window;

    private Glfw.FramebufferSizeCallback? _framebufferSizeCallback;
    private Glfw.KeyCallback? _keyCallback;
    private Glfw.MouseButtonCallback? _mouseButtonCallback;
    private Glfw.ScrollCallback? _mouseScrollCallback;
    private Glfw.CursorEnterCallback? _cursorEnterLeaveCallback;
    private Glfw.CursorPositionCallback? _cursorPositionCallback;
    private Glfw.WindowSizeCallback? _windowSizeCallback;
    private Glfw.CharCallback? _windowCharCallback;

    public Application(ILogger logger, IApplicationContext applicationContext)
    {
        _logger = logger;
        _applicationContext = applicationContext;
    }

    public async Task<bool> RunAsync(CancellationToken cancellationToken)
    {
        if(!await InitializeAsync(cancellationToken))
        {
            return false;
        }

        if(!await LoadAsync(cancellationToken))
        {
            return false;
        }

        while(!Glfw.ShouldWindowClose(_window))
        {
            Glfw.PollEvents();

            Glfw.SwapBuffers(_window);
        }

        _logger.Debug("{Category}: Unloading", "App");
        
        await UnloadAsync(cancellationToken);
        Glfw.DestroyWindow(_window);

        _logger.Debug("{Category}: Unloaded", "App");
        Glfw.Terminate();

        return true;
    }

    public void Dispose()
    {
    }

    protected virtual Task<bool> InitializeAsync(CancellationToken cancellationToken)
    {
        if(!Glfw.Init())
        {
            _logger.Error("{Category}: Unable to initialize", "Glfw");
            return Task.FromResult(false);
        }

        var monitorHandle = Glfw.GetPrimaryMonitor();
        var videoMode = Glfw.GetVideoMode(monitorHandle);
        var screenWidth = videoMode.Width;
        var screenHeight = videoMode.Height;

        Glfw.GetMonitorPos(monitorHandle,
                           out var monitorLeft,
                           out var monitorTop);

        _applicationContext.ScreenSize = new Int2(screenWidth, screenHeight);
        _applicationContext.WindowSize = new Int2((int)(screenWidth * 0.8f), (int)(screenHeight * 0.8f));

        Glfw.WindowHint(Glfw.WindowInitHint.ClientApi, Glfw.ClientApi.OpenGL);
        Glfw.WindowHint(Glfw.WindowOpenGLContextHint.VersionMajor, 4);
        Glfw.WindowHint(Glfw.WindowOpenGLContextHint.VersionMinor, 6);
        Glfw.WindowHint(Glfw.WindowOpenGLContextHint.DebugContext, Glfw.True);
        Glfw.WindowHint(Glfw.WindowOpenGLContextHint.Profile, Glfw.OpenGLProfile.Core);

        _window = Glfw.CreateWindow(_applicationContext.WindowSize.X,
                                          _applicationContext.WindowSize.Y,
                                          "Rlyeh.Sandbox",
                                          nint.Zero,
                                          nint.Zero);
        if(_window == nint.Zero)
        {
            _logger.Error("{Category}: Unable to create window", "Glfw");
            return Task.FromResult(false);
        }

        Glfw.GetFramebufferSize(_window, out var framebufferWidth, out var framebufferHeight);
        _applicationContext.FramebufferSize = new Int2(framebufferWidth, framebufferHeight);

        Glfw.SetWindowPos(_window,
                          screenWidth / 2 - _applicationContext.WindowSize.X / 2 + monitorLeft,
                          screenHeight / 2 - _applicationContext.WindowSize.Y / 2 + monitorTop);

        Glfw.MakeContextCurrent(_window);
        Glfw.SwapBuffers(_window);

        BindCallbacks();

        return Task.FromResult(true);
    }

    protected virtual Task<bool> LoadAsync(CancellationToken cancellationToken)
    {
        return Task.FromResult(true);
    }

    protected virtual Task UnloadAsync(CancellationToken cancellationToken)
    {
        UnbindCallbacks();
        return Task.CompletedTask;
    }

    private void BindCallbacks()
    {
        //_debugProcCallback = DebugCallback;
        _cursorEnterLeaveCallback = OnMouseEnterLeave;
        _cursorPositionCallback = OnMouseMove;
        _keyCallback = OnKey;
        _mouseButtonCallback = OnMouseButton;
        _mouseScrollCallback = OnMouseScroll;
        _framebufferSizeCallback = OnFramebufferSize;
        _windowSizeCallback = OnWindowSize;
        _windowCharCallback = OnInputCharacter;

        Glfw.SetKeyCallback(_window, _keyCallback);
        Glfw.SetCursorPositionCallback(_window, _cursorPositionCallback);
        Glfw.SetCursorEnterCallback(_window, _cursorEnterLeaveCallback);
        Glfw.SetMouseButtonCallback(_window, _mouseButtonCallback);
        Glfw.SetScrollCallback(_window, _mouseScrollCallback);
        Glfw.SetWindowSizeCallback(_window, _windowSizeCallback);
        Glfw.SetFramebufferSizeCallback(_window, _framebufferSizeCallback);
        Glfw.SetCharCallback(_window, _windowCharCallback);
    }

    private void UnbindCallbacks()
    {
        //_debugProcCallback = null;
        Glfw.SetCharCallback(_window, null);
        Glfw.SetKeyCallback(_window, null);
        Glfw.SetCursorEnterCallback(_window, null);
        Glfw.SetCursorPositionCallback(_window, null);
        Glfw.SetMouseButtonCallback(_window, null);
        Glfw.SetScrollCallback(_window, null);
        Glfw.SetFramebufferSizeCallback(_window, null);
        Glfw.SetWindowSizeCallback(_window, null);
        Glfw.SetCharCallback(_window, null);
    }

    private void OnKey(
        nint windowHandle,
        Glfw.Key key,
        Glfw.Scancode scancode,
        Glfw.KeyAction action,
        Glfw.KeyModifiers modifiers)
    {
    }

    private void OnMouseMove(
        nint windowHandle,
        double currentCursorX,
        double currentCursorY)
    {
    }

    private void OnMouseEnterLeave(
        nint windowHandle,
        Glfw.CursorEnterMode cursorEnterMode)
    {
        _logger.Verbose("{Category}: Mode: {CursorEnterMode}", "Glfw", cursorEnterMode);
    }

    private void OnMouseButton(
        nint windowHandle,
        Glfw.MouseButton mouseButton,
        Glfw.KeyAction action,
        Glfw.KeyModifiers modifiers)
    {
    }

    private void OnMouseScroll(
        nint windowHandle,
        double scrollX,
        double scrollY)
    {
    }

    private void OnWindowSize(
        nint windowHandle,
        int width,
        int height)
    {
    }

    private void OnFramebufferSize(nint windowHandle, int width, int height)
    {
    }

    private void OnInputCharacter(nint windowHandle, uint codePoint)
    {
    }
}
