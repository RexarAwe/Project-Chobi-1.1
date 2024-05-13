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

    public override void _Ready()
    {
        fsm = GetNode<StateMachine>("FSM");
        hud = GetNode<HUD>("HUD");
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
