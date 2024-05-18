using Godot;
using System;

public partial class TileMap : Godot.TileMap
{
    //public TileData TileData { get; set; }

    // create a dictionary of tilemap position as key and occupancy status as the value (get_used_cells_by_id)


    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
        //if (Input.IsActionJustReleased("left_mouse_click"))
        //{
        //    GD.Print("left mouse click");

        //    GD.Print(GetCellTileData(0, LocalToMap(GetLocalMousePosition())).GetCustomData("terrain_type"));
        //    GD.Print(GetCellTileData(0, LocalToMap(GetLocalMousePosition())).GetCustomData("occupied"));

        //    TileData = GetCellTileData(0, LocalToMap(GetLocalMousePosition()));
        //    TileData.SetCustomData("occupied", !(bool)GetCellTileData(0, LocalToMap(GetLocalMousePosition())).GetCustomData("occupied"));
        //}
    }
}
