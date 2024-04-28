using Godot;
using System;
using System.Collections.Generic;

public partial class TurnSystem : Node2D
{
    public List<Player> players = new List<Player>();
    private StateMachine FSM;

    // signals
    [Signal] public delegate void StartRoundEventHandler();

    public override void _Ready()
	{
        CollectPlayers();
        FSM = GetNode<StateMachine>("FSM");

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
}
