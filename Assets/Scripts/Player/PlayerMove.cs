using UnityEngine.InputSystem;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField]
    private float _minX;

    [SerializeField]
    private float _maxX;

    [SerializeField]
    private float _speed = 4;

    private PlayerInput _input;

    private Rigidbody _rb;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
        _input = GetComponent<PlayerInput>();
        // RoadMover.MoveAllToZero += MoveBack;
    }

    private void FixedUpdate()
    {
        if (GameController.IsStarted)
        {
            transform.Translate(Vector3.forward * _speed * 2.5f * Time.deltaTime);
            MoveLeftRight();
        }
    }

    private void MoveLeftRight()
    {
        Vector2 input = _input.actions["Move"].ReadValue<Vector2>();
        Vector3 move = Vector3.right * input.x;
        float nextX = (transform.localPosition + move).x;

        if (nextX >= _minX && nextX <= _maxX)
        {
            transform.Translate(move * _speed * Time.deltaTime);
        }
    }

    public void MoveBack()
    {
        float Step = 30f;
        transform.localPosition += Vector3.back * Step;
    }
}
