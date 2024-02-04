namespace Rlyeh;

using Rlyeh.Mathematics;

internal sealed class ApplicationContext : IApplicationContext
{
    public Int2 FramebufferSize { get; set; }

    public Int2 ScreenSize { get; set; }

    public Int2 WindowSize { get; set; }
}