using UnityEngine;

public class PlayerAttackingState : PlayerBaseState
{
    private float timer = 2f;

    public PlayerAttackingState(PlayerStateMachine stateMachine) : base(stateMachine)
    {
    }

    public override void Enter()
    {
        stateMachine.GetComponentInChildren<MeshRenderer>().material = stateMachine.AttackingMaterial;
    }

    public override void Tick(float deltaTime)
    {
        timer -= deltaTime;

        if (timer <= 0f)
        {
            stateMachine.SwitchState(new PlayerFreeLookState(stateMachine));
        }
    }

    public override void Exit()
    {
        stateMachine.GetComponentInChildren<MeshRenderer>().material = stateMachine.FreeLookMaterial;
    }
}