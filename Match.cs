using Godot;
using System;

public partial class Match : Node2D
{
	private Camera2D camera;
	[Export]
	public int CameraSpeed { get; set; } = 400;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		camera = GetNode<Camera2D>("Camera");
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		Vector2 velocity = Vector2.Zero;

		// camera movement through wasd
		if (Input.IsActionPressed("camera_up"))
		{
			velocity.Y -= 1;
		}

		if (Input.IsActionPressed("camera_down"))
		{
			velocity.Y += 1;
		}

		if (Input.IsActionPressed("camera_left"))
		{
			velocity.X -= 1;
		}

		if (Input.IsActionPressed("camera_right"))
		{
			velocity.X += 1;
		}

		if (velocity.Length() > 0)
		{
			velocity = velocity.Normalized() * CameraSpeed;
		}

		camera.Position += velocity * (float)delta;
		camera.Position = new Vector2(
			x: Mathf.Clamp(camera.Position.X, (camera.GetViewportRect().Size.X / 2), 1900 - (camera.GetViewportRect().Size.X / 2)),
			y: Mathf.Clamp(camera.Position.Y, (camera.GetViewportRect().Size.Y / 2), 1154 - (camera.GetViewportRect().Size.Y / 2))
		);
	}
}
