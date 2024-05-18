using Godot;
using Godot.Collections;
using System;
using System.Collections.Generic;

public partial class TurnSystem : Node2D
{
    public List<Player> players = new List<Player>();
    private StateMachine FSM;
    public TileMap tilemap;
    public Dictionary tile_occupancy; 
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

        tile_occupancy = new Dictionary{};

        CollectPlayers();
        PreparePlayers();

        // loop through all tilemap used tile positions and update occupancy status
        // check if player position is on any map to make it true, otherwise false

        Array<Vector2I> used_cells = tilemap.GetUsedCells(0);
        GD.Print("used_cells idx 0:" + used_cells[0]);

        foreach (Vector2I cell in used_cells)
        {
            tile_occupancy[cell] = false; // set default value to false

            // check if a player is occupying it
            foreach (Player player in players)
            {
                if (player.TilePosition == cell)
                {
                    tile_occupancy[cell] = true;
                }
            }
        }

        // test how the dictionary will be used
        //Vector2I key = new Vector2I(11, 5);
        //GD.Print("tile_occupancy: " + tile_occupancy[key]);
        //GD.Print("tile_occupancy: " + tile_occupancy);

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
            GD.Print("player tile position: " + player.TilePosition);
            GD.Print("tile data occupied status before: " + player.TileData.GetCustomData("occupied"));
            player.TileData.SetCustomData("occupied", true);
            GD.Print("tile data occupied status after: " + player.TileData.GetCustomData("occupied"));
        }
    }
}
