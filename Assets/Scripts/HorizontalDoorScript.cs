﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorizontalDoorScript : MonoBehaviour
{
    public bool isOpen = false;
    public float moveSpeed = 2f;
    public float openTrack = 0;
    private Color baseColor;
    // Start is called before the first frame update
    void Start()
    {
        baseColor =  GetComponent<Renderer>().material.color;
    }

    // Update is called once per frame
    void Update()
    {
        if(isOpen && openTrack < transform.localScale.x)
        {
            float translation = Mathf.Lerp(0, transform.localScale.x, moveSpeed) * Time.deltaTime;
            transform.Translate(Vector3.right * translation);
            openTrack += translation;
        }
        else if (!isOpen && openTrack > 0)
        {
            float translation = Mathf.Lerp(0, transform.localScale.x, moveSpeed) * Time.deltaTime;
            transform.Translate(-Vector3.right * translation);
            openTrack -= translation;
        }
    }

    public void open()
    {
        isOpen = true;
        GetComponent<Renderer>().material.color = Color.red;
    }

    public void close()
    {
        isOpen = false;
        GetComponent<Renderer>().material.color = baseColor;
    }
}
