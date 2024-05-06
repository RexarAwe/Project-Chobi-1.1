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
        GD.Print("Exiting Player" + " " + player.ID + " StartTurnState");
    }

    public override void Ready()
    {
        player = (Player)fsm.parent;
        GD.Print("Player" + " " + player.ID + " StartTurnState Ready");
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
        GD.Print("Move");

        if (player.Playing)
        {
            fsm.TransitionTo("Move"); // create a state for this
        }

        //moving = true;

        ////GD.Print("MOVE!");

        //// define the movement range tile
        //int atlus_source_id = 2;
        //Vector2I atlus_coord = new Vector2I(0, 0);
        //int alternative_tile = 0;

        //// reset the movement tiles layer (1)
        //TileMap.ClearLayer(1);

        //// MoveRange
        ////allowed_move_positions = MoveRange();
        //allowed_move_positions = MovePotential(current_player.TilePosition, current_player.Speed);
        //for (int i = 0; i < allowed_move_positions.Count; i++)
        //{
        //    //GD.Print("  " + allowed_move_positions[i]);
        //    TileMap.SetCell(1, allowed_move_positions[i], atlus_source_id, atlus_coord, alternative_tile);
        //}
    }

    //public virtual void PhysicsUpdate(float delta) { }
    //public virtual void HandleInput(InputEvent @event) { }
}
