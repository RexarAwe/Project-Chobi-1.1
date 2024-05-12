using Godot;
using System;

public partial class MoveState : State
{
    private Player player;
    public override void Enter()
    {
        // Start Round (check for all players, generate queue of randomized turn order, go to the first player!)
        GD.Print("Entering Player" + " " + player.ID + " MoveState");

    }

    public override void Exit()
    {
        //GD.Print("Exiting Player" + " " + player.ID + " MoveState");
    }

    public override void Ready()
    {
        player = (Player)fsm.parent;
        //GD.Print("Player" + " " + player.ID + " MoveState Ready");
    }

    //public override void Update(float delta)
    //{
    //    //GD.Print(player.playing);
    //    if (player.playing)
    //    {
    //        // wait for user input to go to correct action state

    //    }
    //}
}
