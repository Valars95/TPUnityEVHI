using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthScript : MonoBehaviour
{
    // Start is called before the first frame update
    public Sprite empty;
    public Sprite full;
    private float damagedScreenCpt = 0;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(damagedScreenCpt > 0)
        {
            gameObject.transform.parent.GetChild(3).gameObject.SetActive(true);
            damagedScreenCpt -= Time.deltaTime;
        }
        else
        {
            gameObject.transform.parent.GetChild(3).gameObject.SetActive(false);
        }
    }

    public void invincibilityScreen()
    {
        gameObject.transform.parent.GetChild(3).gameObject.GetComponent<Image>().color = new Color(1f,1f,0f,0.1f);
        damagedScreenCpt = 5f;
    }

    public void setHealth(int health, bool type)
    {
        if(type)
            gameObject.transform.parent.GetChild(3).gameObject.GetComponent<Image>().color = new Color(1f,0f,0f,0.4f);
        else
            gameObject.transform.parent.GetChild(3).gameObject.GetComponent<Image>().color = new Color(0f,1f,0f,0.4f);

        damagedScreenCpt = 0.2f;
        if(health == 0)
        {
            gameObject.transform.GetChild(0).GetComponent<Image>().sprite = empty;
            gameObject.transform.GetChild(1).GetComponent<Image>().sprite = empty;
            gameObject.transform.GetChild(2).GetComponent<Image>().sprite = empty;
        }
        else if(health == 1)
        {
            gameObject.transform.GetChild(0).GetComponent<Image>().sprite = full;
            gameObject.transform.GetChild(1).GetComponent<Image>().sprite = empty;
            gameObject.transform.GetChild(2).GetComponent<Image>().sprite = empty;
        }
        else if(health == 2)
        {
            gameObject.transform.GetChild(0).GetComponent<Image>().sprite = full;
            gameObject.transform.GetChild(1).GetComponent<Image>().sprite = full;
            gameObject.transform.GetChild(2).GetComponent<Image>().sprite = empty;
        }
        else if(health == 3)
        {
            gameObject.transform.GetChild(0).GetComponent<Image>().sprite = full;
            gameObject.transform.GetChild(1).GetComponent<Image>().sprite = full;
            gameObject.transform.GetChild(2).GetComponent<Image>().sprite = full;
        }
    }
}
