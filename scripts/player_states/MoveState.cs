using Godot;
using System;
using System.Collections.Generic;
using static Godot.Projection;

public partial class MoveState : State
{
    private Player player;

    private List<Vector2I> allowed_move_positions = new List<Vector2I>();

    public override void Enter()
    {
        // Start Round (check for all players, generate queue of randomized turn order, go to the first player!)
        GD.Print("Entering Player" + " " + player.ID + " MoveState");

        // perform the move action stuff here
        Move();
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

    //private bool is_occupied(Vector2I pos)
    //{
    //    //GD.Print("checking if occupied...");

    //    List<Vector2I> player_positions = new List<Vector2I>();
    //    foreach (Player player in players)
    //    {

    //        if (player.ID != current_player.ID && !player.dead)
    //        {
    //            player_positions.Add(TileMap.LocalToMap(player.Position));
    //            GD.Print(TileMap.LocalToMap(player.Position));
    //        }
    //    }

    //    if (player_positions.Contains(pos))
    //    {
    //        //GD.Print("true");
    //        return true;
    //    }
    //    return false;
    //}

    public void Move()
    {
        GD.Print("Move");

        //GD.Print("MOVE!");

        // define the movement range tile
        int atlus_source_id = 2;
        Vector2I atlus_coord = new Vector2I(0, 0);
        int alternative_tile = 0;

        // reset the movement tiles layer (1)
        player.TileMap.ClearLayer(1);

        // MoveRange
        //allowed_move_positions = MoveRange();
        allowed_move_positions = MovePotential(player.TilePosition, player.Speed);
        for (int i = 0; i < allowed_move_positions.Count; i++)
        {
            GD.Print("  " + allowed_move_positions[i]);
            player.TileMap.SetCell(1, allowed_move_positions[i], atlus_source_id, atlus_coord, alternative_tile);
        }

        //player.TileData.SetCustomData("occupied", false); // set old position back to false occupied status
    }

    public List<Vector2I> MovePotential(Vector2I orig_map_position, int move_points)
    {
        List<Vector2I> map_pos_list = new List<Vector2I>();
        Vector2I map_position;

        // Function to check move cost and add position if move points are sufficient and there is no one else occupying it
        void CheckAndAddNeighbor(TileSet.CellNeighbor neighbor)
        {
            map_position = player.TileMap.GetNeighborCell(orig_map_position, neighbor);
            //GD.Print("HERE: " + player.TileMap.GetCellTileData(0, map_position).GetCustomData("move_cost"));

            //var temp = TileMap.GetCellTileData(0, map_position).GetCustomData("move_cost");
            int move_cost = (int)player.TileMap.GetCellTileData(0, map_position).GetCustomData("move_cost");
            //GD.Print("HERE: " + move_cost);

            bool is_occupied = (bool)player.TileMap.GetCellTileData(0, map_position).GetCustomData("occupied");
            string terrain_type = (string)player.TileMap.GetCellTileData(0, map_position).GetCustomData("terrain_type");
            GD.Print("player TilePosition: " + player.TilePosition);
            GD.Print("check position: " + map_position);
            GD.Print("is_occupied: " + is_occupied);
            GD.Print("terrain_type: " + terrain_type);
            if (move_cost <= move_points && !is_occupied)
            {
                map_pos_list.Add(map_position);
            }
        }

        // Check and add neighbors based on move points
        CheckAndAddNeighbor(TileSet.CellNeighbor.TopLeftSide);
        CheckAndAddNeighbor(TileSet.CellNeighbor.TopSide);
        CheckAndAddNeighbor(TileSet.CellNeighbor.TopRightSide);
        CheckAndAddNeighbor(TileSet.CellNeighbor.BottomRightSide);
        CheckAndAddNeighbor(TileSet.CellNeighbor.BottomSide);
        CheckAndAddNeighbor(TileSet.CellNeighbor.BottomLeftSide);

        // Recursively call GetNeighbors on each added position if move points remain
        foreach (Vector2I position in map_pos_list.ToArray())
        {
            int remaining_move_points = move_points - (int)player.TileMap.GetCellTileData(0, position).GetCustomData("move_cost");
            if (remaining_move_points > 0)
            {
                List<Vector2I> additional_neighbors = MovePotential(position, remaining_move_points);
                map_pos_list.AddRange(additional_neighbors);
            }
        }

        return map_pos_list;
    }
}
