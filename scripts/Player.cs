using Godot;
using System;

public partial class Player : Node2D
{
    [Export] public int ID { get; set; }
    private StateMachine FSM;
    public override void _Ready()
    {
        FSM = GetNode<StateMachine>("FSM");
    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(double delta)
	{
	}
}
