using System;
using SplashKitSDK;

public class AI
{
    public Bitmap CarBitmap;
    public double X;
    public double Y;
    public double Speed = 0.5;
    public bool IsOverLine;
    
    public AI()
    {
        CarBitmap = SplashKit.BitmapNamed("AI");
        //Load bitmap resources in LoadResource()
        Y = - CarBitmap.Height;

        double r = SplashKit.Rnd();
        if (r < 0.2)
        {
            X = Map.LANE_LEFT;
        }
        if (r >= 0.2 && r < 0.4)
        {
            X = Map.LANE_LEFT + Map.LANE_WIDTH;
        }
        if (r >= 0.4 && r < 0.6)
        {
            X = Map.LANE_LEFT + Map.LANE_WIDTH * 2;
        }
        if (r >= 0.6 && r < 0.8)
        {
            X = Map.LANE_LEFT + Map.LANE_WIDTH * 3;
        }
        if (r >=  0.8)
        {
            X = Map.LANE_LEFT + Map.LANE_WIDTH * 4;
        }
    }

    public void Draw()
    {
        CarBitmap.Draw(X,Y);
    }

    public void Move()
    {
        Y += Speed;
    }

    public bool ColliedWith(Player p)
    {
        return CarBitmap.BitmapCollision(X, Y, p.CarBitmap, p.X, p.Y);
    }
}