using System;
using SplashKitSDK;
using System.Collections.Generic;

public class RaceGame
{
    private Window _window;
    private Player _player;
    private Map _map;
    private List<AI> _ai = new List<AI>();
    public bool Restart;
    private bool _addNew;
    private Timer _timer;
    private int _score;
    private int _level;
    private int _basicSpeed;
    public bool ESC
    {
        get
        {
            return _player.Quit;
        }
    }
    
    
    public void LoadResource()
    {
        SplashKit.LoadBitmap("Player", "PlayerCar2.png");
        SplashKit.LoadBitmap("Road1", "Road1.png");
        SplashKit.LoadBitmap("Road2", "Road2.png");
        SplashKit.LoadBitmap("Road3", "Road3.png");
        SplashKit.LoadBitmap("AI", "AICar1.png");
        SplashKit.LoadFont("FontC", "calibri.ttf");
        SplashKit.LoadFont("FontU", "unknown.ttf");
    }

    public RaceGame(Window w)
    {
        _window = w;
        LoadResource();
        _player = new Player(_window);
        _map = new Map(_window);
        _ai.Add(new AI());
        _timer = new Timer("gameTimer");
        _timer.Start();
    }


    public void Update()
    {
        _player.Move();
        _map.Move();
        foreach (AI ai in _ai)
        {
            ai.Move();
        } 
        Collision();
        CheckOverLine();
        AddNewCar();
        RemoveAI();
        Level();
    }

    public void Draw()
    {
        DrawUI();
        _map.Draw();
        _player.Draw();
        foreach (AI ai in _ai)
        {
            ai.Draw();
        } 
    }

    public void Collision()
    {
        foreach (AI ai in _ai)
        {
            if (ai.ColliedWith(_player))
            {
                SplashKit.DisplayDialog("GameOver", $"Your Score is: {_score} m", SplashKit.FontNamed("FontC"), 20);
                Restart = true;
            }
        }
    }

    public void CheckOverLine()
    {
        foreach (AI ai in _ai)
        {
            if (ai.IsOverLine != true && ai.Y > _window.Height / 4)
            {
                _addNew = true;
                ai.IsOverLine = true;
            }
        }
    }

    public void AddNewCar()
    {
        if (_addNew == true)
        {
            _ai.Add(new AI());
            _addNew = false;
        }
    }

    public void RemoveAI()
    {
        List<AI> _uselessAI = new List<AI>();
        foreach (AI ai in _ai)
        {
            if (ai.Y > _window.Height || ai.ColliedWith(_player))
            {
                _uselessAI.Add(ai);
            }
        }
        foreach (AI r in _uselessAI)
        {
            _ai.Remove(r);
        }
    }

    public void Level()
    {
        _basicSpeed = 3 + _level;
        _score += _basicSpeed;
        _level = Convert.ToInt32(_timer.Ticks) / 20000;
    }

    public void DrawUI()
    {
        _window.DrawText($"Your Score: {_score} M", Color.White, SplashKit.FontNamed("FontU"), 20, 20, 20);
    }
}