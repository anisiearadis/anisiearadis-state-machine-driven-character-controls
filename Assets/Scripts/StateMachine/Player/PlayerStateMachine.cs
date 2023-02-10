using UnityEngine;

public class PlayerStateMachine : StateMachine
{
    // Fields
    [SerializeField] private GameObject cameraAnchor;
    [SerializeField] private float bottomClamp = -30.0f; // -30
    [SerializeField] private float topClamp = 70.0f;
    [SerializeField] private float lookSensitivity;
    [SerializeField] private bool invert;

    [SerializeField] private Material freeLookMaterial;
    [SerializeField] private Material attackingMaterial;

    // Components
    private Transform _mainCameraTransform;
    private InputReader _inputReader;

    // Properties
    public Transform MainCameraTransform => _mainCameraTransform;
    public InputReader InputReader => _inputReader;

    public GameObject CameraAnchor => cameraAnchor;
    public float BottomClamp => bottomClamp;
    public float TopClamp => topClamp;
    public float LookSensitivity => lookSensitivity;
    public bool Invert => invert;
    public Material FreeLookMaterial => freeLookMaterial;
    public Material AttackingMaterial => attackingMaterial;

    private void Awake()
    {
        _mainCameraTransform = Camera.main.transform;
        _inputReader = GetComponent<InputReader>();
    }

    private void Start()
    {
        SwitchState(new PlayerFreeLookState(this));

        Cursor.lockState = CursorLockMode.Locked;
    }
}