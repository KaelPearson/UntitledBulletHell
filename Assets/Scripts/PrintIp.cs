using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrintIp : MonoBehaviour {
    void Start() {
        string ipv6 = IpGrab.GetIP(ADDRESSFAM.IPv6);
        string ipv4 = IpGrab.GetIP(ADDRESSFAM.IPv4);
        Debug.Log("IPV6 " + ipv6);
        Debug.Log("IPV4 " + ipv4);
    }
}