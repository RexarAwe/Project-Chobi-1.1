using Godot;
using System;

public partial class Player : Node2D
{
    [Export] public int ID { get; set; }
    public StateMachine fsm;
    public HUD hud;
    public bool Playing { get; set; } = false;
    public int ActionPoints { get; set; } = 2;
    public Vector2I TilePosition { get; set; }
    public TileData TileData { get; set; }
    public TileMap TileMap;

    public int Speed { get; set; } = 2;
    public int Strength { get; set; } = 1;
    public int Dexterity { get; set; } = 1;
    public int Defense { get; set; } = 1;
    public int Health { get; set; } = 1;
    //public int MeleeAttackRange { get; set; } = 1;
    //public int MeleeDamage { get; set; } = 1;
    //public int RangedAttackRange { get; set; } = 3;
    //public int RangedDamage { get; set; } = 1;

    public override void _Ready()
    {
        fsm = GetNode<StateMachine>("FSM");
        hud = GetNode<HUD>("HUD");
        TileMap = GetNode<TileMap>("../TileMap");
        hud.Visible = false;
    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(double delta)
	{

	}

    public void TransitionEvent(string target_state_name)
    {
        GD.Print("Transitioning to: " + target_state_name);
        fsm.TransitionTo(target_state_name);
    }
}
