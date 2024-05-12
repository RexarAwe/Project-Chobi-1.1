using Godot;
using System;
using System.Collections.Generic;

public partial class TurnSystem : Node2D
{
    public List<Player> players = new List<Player>();
    private StateMachine FSM;
    public int current_player_idx { get; set; }
    public Player current_player { get; set; }

    //public TileMap 

    // signals
    [Signal] public delegate void StartRoundEventHandler();
    //[Signal] public delegate void MoveActionSelectedEventHandler();

    public override void _Ready()
	{
        CollectPlayers();
        FSM = GetNode<StateMachine>("FSM");

        // get tilemap here

        GD.Print("Emitting Signal: StartRound");
        EmitSignal(SignalName.StartRound);
    }

	public override void _Process(double delta)
	{

	}

	private void CollectPlayers()
	{
        // get all child CharacterBody2D nodes as players
        players = new List<Player>();

        // get the players within the scene
        foreach (Node node in GetChildren())
        {
            if (node is Player player)
            {
                players.Add(player);
            }
        }

        GD.Print("players.Count: " + players.Count);
    }

    private void OnHUDMoveActionSelected() // do i need this to send to the player state eventually?
    {
        GD.Print("OnHUDMoveActionSelected");
        //EmitSignal(SignalName.MoveActionSelected);
        GD.Print("current player ID: " + current_player.ID);
        current_player.TransitionEvent("Move");
    }
}
