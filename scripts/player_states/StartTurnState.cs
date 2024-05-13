using Godot;
using System;

public partial class StartTurnState : State
{
    private Player player;

    public override void Enter()
    {
        // Start Round (check for all players, generate queue of randomized turn order, go to the first player!)
        GD.Print("Entering Player" + " " + player.ID + " StartTurnState");

        // Assign action points
        player.ActionPoints = 2;
        GD.Print("Assigned Player" + " " + player.ID + " 2 action points");
    }

    public override void Exit()
    {
        //GD.Print("Exiting Player" + " " + player.ID + " StartTurnState");
    }

    public override void Ready()
    {
        player = (Player)fsm.parent;
        //GD.Print("Player" + " " + player.ID + " StartTurnState Ready");
    }

    //public override void Update(float delta)
    //{
    //    //GD.Print(player.playing);
    //    if (player.playing)
    //    {
    //        // wait for user input to go to correct action state

    //    }
    //}

    public void Move()
    {
        if (player.Playing)
        {
            fsm.TransitionTo("Move"); // create a state for this
        }
    }

    //public virtual void PhysicsUpdate(float delta) { }
    //public virtual void HandleInput(InputEvent @event) { }
}
