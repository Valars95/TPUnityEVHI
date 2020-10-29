using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeScript : MonoBehaviour
{
    public bool invincibility = false;
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
        if(other.tag == "Player"){
            GameObject obj = other.gameObject; 
            if(invincibility){
                ((PlayerScript)(obj.GetComponent<PlayerScript>())).activateInvincibility();
                Destroy(this.gameObject);
            }
            else{
                if( ((PlayerScript)(obj.GetComponent<PlayerScript>())).health < 3)
                {
                    ((PlayerScript)(obj.GetComponent<PlayerScript>())).heal();
                    Destroy(this.gameObject);
                }
            }
        }
    }
}
