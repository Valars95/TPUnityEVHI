using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBallScript : MonoBehaviour
{
    // Start is called before the first frame update
    private float time = 0;
    private bool isAlly = true;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if(time > 5)
            Destroy(this.gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "LevelComponent"){
            Destroy(this.gameObject);
        }
        else if(other.tag == "Enemy" && isAlly)
        {
            GameObject obj = other.gameObject; 
            ((EnemyScript)(obj.GetComponent<EnemyScript>())).loseLife();
            Destroy(this.gameObject);
        }
        else if(other.tag == "Player" && !isAlly)
        {
            GameObject obj = other.gameObject; 
            ((PlayerScript)(obj.GetComponent<PlayerScript>())).damage();
            Destroy(this.gameObject);
        }
        else if(other.tag == "Dragon" && isAlly)
        {
            GameObject obj = other.gameObject; 
            ((DragonScript)(obj.GetComponent<DragonScript>())).loseLife();
            Destroy(this.gameObject);
        }
    }

    public void setAlly(bool ally)
    {
        isAlly = ally;
    }
}
