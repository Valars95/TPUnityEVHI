using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class FallLvl4Script : MonoBehaviour
{
    public GameObject player;
    public GameObject teleportPosition;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        ((PlayerScript)player.GetComponent<PlayerScript>()).damage();
        player.transform.position = teleportPosition.transform.position;
    }

}
