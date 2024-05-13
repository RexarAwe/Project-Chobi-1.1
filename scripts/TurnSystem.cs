using Godot;
using System;
using System.Collections.Generic;

public partial class TurnSystem : Node2D
{
    public List<Player> players = new List<Player>();
    private StateMachine FSM;
    public TileMap tilemap;
    public int current_player_idx { get; set; }
    public Player current_player { get; set; }

    //public TileMap 

    // signals
    [Signal] public delegate void StartRoundEventHandler();
    //[Signal] public delegate void MoveActionSelectedEventHandler();

    public override void _Ready()
	{
        FSM = GetNode<StateMachine>("FSM");
        tilemap = GetNode<TileMap>("TileMap");

        CollectPlayers();
        PreparePlayers();

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

    private void PreparePlayers()
    {
        foreach (Player player in players)
        {
            var map_position = tilemap.LocalToMap(player.Position);
            var centered_position = tilemap.MapToLocal(map_position);

            // center the position to the tilemap
            player.Position = centered_position;
            player.TilePosition = tilemap.LocalToMap(player.Position);
            player.TileData = tilemap.GetCellTileData(0, player.TilePosition);
        }
    }
}
