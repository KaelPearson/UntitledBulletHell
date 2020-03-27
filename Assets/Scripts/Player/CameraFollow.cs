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
        if (isLocalPlayer) {
            return;
        }
        
        cam.enabled = false;
    }
}
