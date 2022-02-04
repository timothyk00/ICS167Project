using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Timothy Kwon
public class CameraRig : MonoBehaviour
{
    public GameObject _player;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(_player.transform.position.x - 10, 15f, _player.transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(_player.transform.position.x - 10, 15f, _player.transform.position.z);
    }
}
