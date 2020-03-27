using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
public class HideGUI : NetworkBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        NetworkManagerHUD hud = FindObjectOfType<NetworkManagerHUD>();
        if( hud != null ){
            hud.showGUI = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
