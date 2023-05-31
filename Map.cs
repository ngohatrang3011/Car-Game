using System;
using SplashKitSDK;

public class Map
{
    private Bitmap _roadBitmap;
    private Window _gameWindow;
    private Timer _myTimer;
    public const int LANE_LEFT = 250;
    public const int LANE_WIDTH = 60;

    public Map(Window window)
    {
        _gameWindow = window;
        _myTimer = new Timer("timer");
        _myTimer.Start();
    }

    public void Move()
    {
        RoadMove();
    }

    public void Draw()
    {
        _roadBitmap.Draw((_gameWindow.Width - _roadBitmap.Width) / 2, 0);
    }

    public void RoadMove()
    {
        if (_myTimer.Ticks < 200)
        {
            _roadBitmap = SplashKit.BitmapNamed("Road1");
        }
        if (_myTimer.Ticks >= 200 && _myTimer.Ticks < 400)
        {
            _roadBitmap = SplashKit.BitmapNamed("Road2");
        }
        if (_myTimer.Ticks >= 400 && _myTimer.Ticks < 600)
        {
            _roadBitmap = SplashKit.BitmapNamed("Road3");
        }
        if (_myTimer.Ticks >= 600)
        {
            _myTimer.Start();         //reset time recording
        }
    }
}