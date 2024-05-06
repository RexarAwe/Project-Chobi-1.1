using Godot;
using System;

public partial class Player : Node2D
{
    [Export] public int ID { get; set; }
    //private StateMachine fsm;
    public bool Playing { get; set; } = false;
    public int ActionPoints { get; set; } = 2;

    public override void _Ready()
    {
        //fsm = GetNode<StateMachine>("FSM");
    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(double delta)
	{

	}
}
