using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Timothy Kwon
public class CameraRig : MonoBehaviour
{

    // Start is called before the first frame update
    private void Start()
    {
        if (GameManager.GManager.GetNumCameras() == 2)
        {
            //change viewports
            int playerNum = GetComponentInParent<PlayerMovementController>()._playerNum;
            Camera cam = this.GetComponent<Camera>();

            if (playerNum == 1)
                cam.rect = new Rect(0, 0, .5f, 1);
            else if (playerNum == 2)
                cam.rect = new Rect(.5f, 0, .5f, 1);
        }
    }

    // Update is called once per frame
    private void Update()
    {

    }
    
}
