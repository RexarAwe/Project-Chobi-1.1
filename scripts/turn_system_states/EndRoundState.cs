using Godot;
using System;

public partial class EndRoundState : State
{
    public override void Enter()
    {
        // End Round (clean up, check for win conditions?)
        GD.Print("Entering Turn System EndRoundState");
        //GetNode<Timer>("Timer").Start();
        //GetNode<Node3D>("Light").Visible = true;
    }

    public override void Exit()
    {
        GD.Print("Exiting Turn System EndRoundState");
        //GetNode<Timer>("Timer").Stop();
        //GetNode<Node3D>("Light").Visible = false;
    }

    public override void Ready()
    {
        GD.Print("Turn System EndRoundState Ready");
        //Events.RedButtonClicked += _OnRedButtonClicked;
    }
}
