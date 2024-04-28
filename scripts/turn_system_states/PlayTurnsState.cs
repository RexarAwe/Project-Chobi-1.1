using Godot;
using System;

public partial class PlayTurnsState : State
{
    public override void Enter()
    {
        // Play turns (go through each non-dead player in order)
        GD.Print("Entering Turn System PlayTurnState");
        //GetNode<Timer>("Timer").Start();
        //GetNode<Node3D>("Light").Visible = true;

        // go through each player's fsm
    }

    public override void Exit()
    {
        GD.Print("Exiting Turn System PlayTurnState");
        //GetNode<Timer>("Timer").Stop();
        //GetNode<Node3D>("Light").Visible = false;
    }

    public override void Ready()
    {
        GD.Print("Turn System PlayTurnState Ready");
        //Events.RedButtonClicked += _OnRedButtonClicked;
    }
}
