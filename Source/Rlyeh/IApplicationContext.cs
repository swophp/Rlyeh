namespace Rlyeh;

using Rlyeh.Mathematics;

public interface IApplicationContext
{
    public Int2 FramebufferSize { get; set; }

    public Int2 ScreenSize { get; set; }

    public Int2 WindowSize { get; set; }
}