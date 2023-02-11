using UnityEngine;

public class PlayerFreeLookState : PlayerBaseState
{
    private float _curXRot;

    public PlayerFreeLookState(PlayerStateMachine stateMachine) : base(stateMachine)
    {
        _curXRot = Utils.EulerAngleNegative(stateMachine.CameraAnchor.transform.eulerAngles.x);
    }

    public override void Enter()
    {
    }

    public override void Tick(float deltaTime)
    {
        HandleStateChanges();
        HandleCameraRotation();
    }

    public override void Exit()
    {
    }

    private void HandleStateChanges()
    {
        if (stateMachine.InputReader.IsAttacking)
        {
            stateMachine.SwitchState(new PlayerAttackingState(stateMachine));
        }
    }

    private void HandleCameraRotation()
    {
        // get the mouse X and Y inputs
        float x = stateMachine.InputReader.LookInput.x;
        float y = stateMachine.InputReader.LookInput.y;

        // rotate the player horizontally
        stateMachine.transform.eulerAngles += Vector3.up * x * stateMachine.LookSensitivity;

        // modify curXRot to move camera up and down based if the rotation is set to inverted or not
        if (stateMachine.Invert)
        {
            _curXRot += y * stateMachine.LookSensitivity;
        }
        else
        {
            _curXRot -= y * stateMachine.LookSensitivity;
        }

        // restrict the curXRot to be in between minXLook and maxXLook
        _curXRot = Mathf.Clamp(_curXRot, stateMachine.BottomClamp, stateMachine.TopClamp);

        // store the angle of camAnchor in a temporary Vector3 variable
        Vector3 clampedAngle = stateMachine.CameraAnchor.transform.eulerAngles;

        // apply the current X rotation to clampedAngle on the x-axis
        clampedAngle.x = _curXRot;

        // and assign it back to the camera 
        stateMachine.CameraAnchor.transform.rotation = Quaternion.Euler(clampedAngle);
    }
}