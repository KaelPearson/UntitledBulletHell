using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
public class CameraFollow : NetworkBehaviour
{

    public Camera cam; // Drag camera into here
 
    void Start()
    {
        // IF I'M THE PLAYER, STOP HERE (DON'T TURN MY OWN CAMERA OFF)
        if (isLocalPlayer) return;
 
        // DISABLE CAMERA AND CONTROLS HERE (BECAUSE THEY ARE NOT ME)
        cam.enabled = false;
        //GetComponent<PlayerControls>().enabled = false;
        //GetComponent<PlayerMovement>().enabled = false;
    }
}
