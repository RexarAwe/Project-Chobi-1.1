using Godot;
using System;

public partial class IdleState : State
{
    private Player player;

    public override void Enter()
    {
        // Start Round (check for all players, generate queue of randomized turn order, go to the first player!)
        GD.Print("Entering Player" + " " + player.ID + " IdleState");
        GD.Print("Parent Name: " + fsm.parent.Name);
    }

    public override void Exit()
    {
        //GD.Print("Exiting Player" + " " + player.ID + " IdleState");
    }

    public override void Ready()
    {
        player = (Player)fsm.parent;
        //GD.Print("Player" + " " + player.ID + " IdleState Ready");
    }

    public override void Update(float delta) 
    {
        //GD.Print(player.playing);
        if (player.Playing)
        {
            fsm.TransitionTo("StartTurn");
        }
    }

    //public virtual void PhysicsUpdate(float delta) { }
    //public virtual void HandleInput(InputEvent @event) { }

}
