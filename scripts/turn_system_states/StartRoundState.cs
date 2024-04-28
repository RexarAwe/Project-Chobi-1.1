using Godot;
using System;
using System.Collections.Generic;
using System.Numerics;
using static Godot.Projection;

public partial class StartRoundState : State
{
    private TurnSystem turn_system;

    public override void Enter()
    {
        // Start Round (check for all players, generate queue of randomized turn order, go to the first player!)
        GD.Print("Entering Turn System StartRoundState");

        // Randomizing turn order
        CheckPlayers();
        ShufflePlayersList();
        CheckPlayers();
    }

    public override void Exit()
    {
        GD.Print("Exiting Turn System StartRoundState");
    }

    public override void Ready()
    {
        GD.Print("Turn System StartRoundState Ready");
        turn_system = (TurnSystem)fsm.parent;
    }

    //public virtual void Update(float delta) { }
    //public virtual void PhysicsUpdate(float delta) { }
    //public virtual void HandleInput(InputEvent @event) { }

    private void ShufflePlayersList()
    {
        GD.Print("ShufflePlayersList");
        Random random = new Random();

        // Perform Fisher-Yates shuffle
        int n = turn_system.players.Count;
        while (n > 1)
        {
            n--;
            int k = random.Next(n + 1);
            Player value = turn_system.players[k];
            turn_system.players[k] = turn_system.players[n];
            turn_system.players[n] = value;
        }
    }

    private void CheckPlayers()
    {
        GD.Print("CheckPlayers");
        GD.Print("players.Count: " + turn_system.players.Count);
        GD.Print("Listing player IDs...");
        foreach (Player player in turn_system.players)
        {
            GD.Print(player.ID);
        }
    }
}

