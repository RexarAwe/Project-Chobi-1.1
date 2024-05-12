using Godot;
using System;

public partial class PlayTurnsState : State
{
    private TurnSystem turn_system;

    public override void Enter()
    {
        // Play turns (go through each non-dead player in order)
        GD.Print("Entering Turn System PlayTurnState");

        // Get first player
        GD.Print("Turn System's player count: " + turn_system.players.Count);
        turn_system.current_player = turn_system.players[turn_system.current_player_idx]; 
        GD.Print("current player: " + turn_system.current_player.ID);
        turn_system.current_player.Playing = true;
        //turn_system.players[current_player_idx].Playing = true;

        // go through each player's fsm
    }

    public override void Exit()
    {
        //GD.Print("Exiting Turn System PlayTurnState");
        //GetNode<Timer>("Timer").Stop();
        //GetNode<Node3D>("Light").Visible = false;
    }

    public override void Ready()
    {
        //GD.Print("Turn System PlayTurnState Ready");
        turn_system = (TurnSystem)fsm.parent;
    }
}
