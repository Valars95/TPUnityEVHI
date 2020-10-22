using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ButtonScript : MonoBehaviour
{
    public UnityEvent ActivateEvent;
    public UnityEvent DesactivateEvent;
    public bool activated = false;
    public bool translationButton = false;
    private float moveSpeed = 1f;
    public float activatedTrack = 0;
    public bool canReverse = false;
    public bool locked = false;
    // Start is called before the first frame update
    void Start()
    {
        SetColor();
    }

    // Update is called once per frame
    void Update()
    {

        if(activated && activatedTrack < transform.localScale.x/2)
        {
            float translation = Mathf.Lerp(0, transform.localScale.x/2, moveSpeed) * Time.deltaTime;
            transform.Translate(-Vector3.forward * translation);
            activatedTrack += translation;
        }
        else if(!activated && activatedTrack > 0)
        {
            float translation = Mathf.Lerp(0, transform.localScale.x/2, moveSpeed) * Time.deltaTime;
            transform.Translate(Vector3.forward * translation);
            activatedTrack -= translation;
        }
    }

    public void trigger()
    {
        if(!locked){
            if(!activated)
            {
                activated = true;
                Debug.Log("Button activated");
                ActivateEvent.Invoke();
            }
            else if(activated)
            {
                activated = false;
                Debug.Log("Button desactivated");
                DesactivateEvent.Invoke();
            }
        }

        SetColor();
    }

    public void SetUnlock()
    {
        locked = false;
        SetColor();
    }

    public void SetLock()
    {
        locked = true;
        SetColor();
    }

    void SetColor()
    {
        if(locked)
            GetComponent<Renderer>().material.SetColor("_Color",Color.red);
        else if(!locked && activated)
            GetComponent<Renderer>().material.SetColor("_Color",Color.green);
        else if(!locked && !activated)
            GetComponent<Renderer>().material.SetColor("_Color",Color.yellow);
    }
}
