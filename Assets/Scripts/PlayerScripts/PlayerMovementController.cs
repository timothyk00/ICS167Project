using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class PlayerMovementController : MonoBehaviour
{
    public int _playerNum = 1;
    public int _health = 100;
    public Slider _healthSlider;

    public float _moveSpeed = 5f;
    public float _turnSpeed = 90f;

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

        Vector3 movement = new Vector3(_horiInputValue, 0.0f, -_vertInputValue);
        transform.LookAt(movement + transform.position);
        transform.Translate(movement * _moveSpeed * Time.deltaTime, Space.World);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Debug.Log("collided with enemy");
            _health -= 10;   // change with enemy damage
            _healthSlider.value = _health;

            if (_health == 0)
                gameObject.SetActive(false);
        }
    }
}

