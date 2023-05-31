using System;
using SplashKitSDK;

public class Player
{
    private Window _gameWindow;
    public Bitmap CarBitmap;
    public bool Quit;

    // To control our player car, we need the X and Y value to change its position
    public double X;
    public double Y;

    public Player(Window window)
    {
        CarBitmap = SplashKit.BitmapNamed("Player");
        _gameWindow = window;
        X = Map.LANE_LEFT + Map.LANE_WIDTH * 2;
        Y = _gameWindow.Height - CarBitmap.Height;
    }

    public void HandleInput()
    {
        int movement = 60;
        double speed = 0.5;
        
        // change X and Y values to make it move
        if (SplashKit.KeyReleased(KeyCode.RightKey))
        {
            X += movement;
        }
        else if (SplashKit.KeyReleased(KeyCode.LeftKey))
        {
            X -= movement;
        }
        else if (SplashKit.KeyDown(KeyCode.UpKey))
        {
            Y -= speed;
        }
        else if (SplashKit.KeyDown(KeyCode.DownKey))
        {
            Y += speed;
        }
        else if (SplashKit.KeyDown(KeyCode.EscapeKey))
        {
            Quit = true;
        }
    }

    public void Move()
    {
        HandleInput();
        StayInTrack();
    }

    public void Draw()
    {
        CarBitmap.Draw(X, Y);
    }

    private void StayInTrack()
    {
        if (X >= Map.LANE_LEFT + Map.LANE_WIDTH * 5) //the right side of track
        {
            X -= Map.LANE_WIDTH;
        }
        if (X < Map.LANE_LEFT) //the left side of track
        {
            X += Map.LANE_WIDTH;
        }
        if (Y > _gameWindow.Height - CarBitmap.Height)
        {
            Y = _gameWindow.Height - CarBitmap.Height;
        }
        if (Y < 0)
        {
            Y = 0;
        }
    }
}