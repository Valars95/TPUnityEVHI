using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GoldPileTrigger : MonoBehaviour
{
    // Start is called before the first frame update
    public UnityEvent activate;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            activate.Invoke();
            transform.parent.GetChild(0).gameObject.SetActive(false);
            Light light = transform.parent.GetChild(1).gameObject.GetComponent<Light>();
            light.range = 50;
            light.intensity = 6;
            light.spotAngle = 90;
            GetComponent<SphereCollider>().enabled = false;
            transform.parent.GetChild(3).gameObject.SetActive(true);
        }
    }
}
