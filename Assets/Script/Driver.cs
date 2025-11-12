using UnityEngine;

public class Driver : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] private Rigidbody2D _frontTireRB;
    [SerializeField] private Rigidbody2D _backTireRB;
    [SerializeField] private Rigidbody2D _carRB;
    [SerializeField] private float _speed = 150f;
    [SerializeField] private float _rotationSpeed ;

    
    [SerializeField] private bool gasPressed = false;
    [SerializeField] private bool brakePressed = false;

    private float _moveInput;
    void Start()
    {
        
    }

    // Update is called once per frame
   private void Update()
    {
        _moveInput = Input.GetAxisRaw("Horizontal");

        if (gasPressed)
            _moveInput = 1f;
        else if (brakePressed)
            _moveInput = -1f;
    }

    private void FixedUpdate()
    {
        _frontTireRB.AddTorque(-_moveInput * _speed * Time.fixedDeltaTime);
        _backTireRB.AddTorque(-_moveInput * _speed * Time.fixedDeltaTime);
        _carRB.AddTorque(_moveInput * _rotationSpeed * Time.fixedDeltaTime);
    }

    public void GasDown() => gasPressed = true;
    public void GasUp() => gasPressed = false;
    public void BrakeDown() => brakePressed = true;
    public void BrakeUp() => brakePressed = false;
}
