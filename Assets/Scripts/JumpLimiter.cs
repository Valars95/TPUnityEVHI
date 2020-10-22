using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpLimiter : MonoBehaviour
{

    public bool canJump = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.tag == "LevelComponent")
        {
            canJump = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "LevelComponent")
        {
            canJump = false;
        }
    }
}
