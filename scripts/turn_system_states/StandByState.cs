using Godot;
using System;

public partial class StandByState : State
{
    private TurnSystem turn_system;

    public override void Enter()
    {
        // Start Round (check for all players, generate queue of randomized turn order, go to the first player!)
        GD.Print("Entering Turn System StandByState");
        GD.Print("Parent Name: " + fsm.parent.Name);
    }

    public override void Exit()
    {
        GD.Print("Exiting Turn System StandByState");
    }

    public override void Ready()
    {
        GD.Print("Turn System StandByState Ready");
        turn_system = (TurnSystem)fsm.parent;
    }

    //public virtual void Update(float delta) { }
    //public virtual void PhysicsUpdate(float delta) { }
    //public virtual void HandleInput(InputEvent @event) { }

    public void OnTurnSystemStartRound()
    {
        GD.Print("Transitioning to StartRoundState");
        fsm.TransitionTo("StartRound");
    }
}