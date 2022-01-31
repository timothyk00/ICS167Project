using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerController : MonoBehaviour
{
    public int _playerNum = 1;

    public int _health = 100;
    public Slider _healthSlider;

    public float _moveSpeed = 5f;
    public float _turnSpeed = 90f;

    public GameObject[] _weapons = new GameObject[2]; // index 0 = primary, index 1 = secondary
    public TextMeshProUGUI _primText;
    public TextMeshProUGUI _secText;

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

        UpdateWeapons();

        _rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();

        if (Input.GetKeyDown("e"))
            Swap();

        if (Input.GetKeyDown("space"))
            Fire();

        UpdateWeapons();
    }

    private void Move()
    {
        _horiInputValue = Input.GetAxis(_horiAxisName);
        _vertInputValue = Input.GetAxis(_vertAxisName);

        Vector3 movement = new Vector3(_horiInputValue, 0.0f, -_vertInputValue);
        transform.LookAt(movement + transform.position);
        transform.Translate(movement * _moveSpeed * Time.deltaTime, Space.World);
    }
    private void Fire()
    {
        if (_weapons.Length != 0)
        {
            Debug.Log("fired");
            Vector3 location = new Vector3(transform.position.x + 1f, 1f, transform.position.z);
            Instantiate(_weapons[0], location, Quaternion.identity);
        }
    }

    private void Swap()
    {
        //Debug.Log("swapping weapons");
        if (_weapons.Length == 2)
            System.Array.Reverse(_weapons);
    }

    private void UpdateWeapons()
    {
        if (_weapons.Length == 0)
        {
            _primText.text = "Primary:";
            _secText.text = "Secondary:";
        }
        else if (_weapons.Length == 1)
        {
            _primText.text = "Primary: " + _weapons[0].name;
            _secText.text = "Secondary: ";
        }
        else if (_weapons.Length == 2)
        {
            _primText.text = "Primary: " + _weapons[0].name;
            _secText.text = "Secondary: " + _weapons[1].name;
        }
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

