using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class PlayerMovementController : MonoBehaviour
{
    public int _playerNum = 1;
    public float _moveSpeed = 5f;
    public float _turnSpeed = 45f;

    private string _horiAxisName;
    private string _vertAxisName;
    private float _horiInputValue = 0f;
    private float _vertInputValue = 0f;

    private Rigidbody _rb;

    // Start is called before the first frame update
    void Start()
    {
        _horiAxisName = "Vertical" + _playerNum;
        _vertAxisName = "Horizontal" + _playerNum;

        _rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    private void Move()
    {
        _horiInputValue = Input.GetAxis(_horiAxisName);
        _vertInputValue = Input.GetAxis(_vertAxisName);

        _rb.velocity = transform.forward * _horiInputValue * _moveSpeed * 100f * Time.fixedDeltaTime;
        transform.Rotate((transform.up * _vertInputValue) * _turnSpeed * Time.fixedDeltaTime);
    }
}

