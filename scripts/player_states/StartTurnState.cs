using Godot;
using System;

public partial class StartTurnState : State
{
    public override void Enter()
    {
        // Start Round (check for all players, generate queue of randomized turn order, go to the first player!)
        GD.Print("Entering Player StartTurnState");

        // 
    }

    public override void Exit()
    {
        GD.Print("Exiting Player StartTurnState");
        //GetNode<Timer>("Timer").Stop();
        //GetNode<Node3D>("Light").Visible = false;
    }

    public override void Ready()
    {
        GD.Print("Player StartTurnState Ready");
        //Events.RedButtonClicked += _OnRedButtonClicked;
    }

    //public virtual void Update(float delta) { }
    //public virtual void PhysicsUpdate(float delta) { }
    //public virtual void HandleInput(InputEvent @event) { }
}
