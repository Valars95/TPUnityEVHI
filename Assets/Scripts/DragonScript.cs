using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DragonScript : MonoBehaviour
{
    [System.Serializable]
    public class EventFloat : UnityEvent<float> {}
    
    [SerializeField]
    public EventFloat LifeEvent;  
    public GameObject[] positionGoal;
    public GameObject Player;
    public GameObject head;
    public GameObject fireballPrefab;
    private int positionGoalIndice = 3;
    private float waitCpt = 0;
    public float fireCooldown = 0.2f;
    private float fireCoolDownCpt = 0;
    private float spawnCpt = 0;
    public int health = 5;
    private int maxHealth;
    public UnityEvent Damaged;

    public float damagedCpt = 0;

    public Color originalColor;

    public float shootSpeed = 180f;

    public UnityEvent Death;
    // Start is called before the first frame update
    void Start()
    {
        originalColor = GetComponent<Renderer>().material.color;
        maxHealth = health;
        spawnCpt = 3f;
    }

    // Update is called once per frame
    void Update()
    {
        if(health > 0)
        {
            if(Vector3.Distance(transform.position,positionGoal[positionGoalIndice].transform.position) < 1f)
            {
                positionGoalIndice = Random.Range(0,4);
                waitCpt = 3f;
            }
            //Look
            Vector3 rotation = Quaternion.LookRotation(Player.transform.position - transform.position).eulerAngles;
            rotation.x = 0f;
            rotation.z = 129.701f;
            rotation.y -= 90;
            transform.rotation = Quaternion.Euler(rotation);

            //Move
            if(waitCpt <= 0)
                transform.position = Vector3.MoveTowards(transform.position, positionGoal[positionGoalIndice].transform.position, 10 * Time.deltaTime);
            else
                waitCpt -= Time.deltaTime;


            //Fire
            if(fireCoolDownCpt <= 0 && spawnCpt <= 0)
            {
                GameObject fireBall;
                Vector3 aim = Quaternion.LookRotation(Player.transform.position - head.transform.position).eulerAngles;
                fireBall = Instantiate(fireballPrefab, head.transform.position, Quaternion.Euler(aim));
                fireBall.GetComponent<FireBallScript>().setAlly(false);

                float randMax = 0.05f;
                Vector3 rand = new Vector3(Random.Range(-randMax,randMax),Random.Range(-randMax,randMax),Random.Range(-randMax,randMax));

                fireBall.GetComponent<Rigidbody>().AddForce((fireBall.transform.forward + rand)* shootSpeed);
                fireCoolDownCpt = fireCooldown;
            }
            else
            {
                fireCoolDownCpt -= Time.deltaTime;
                spawnCpt -= Time.deltaTime;
            }

            if(damagedCpt > 0)
            {
                GetComponent<Renderer>().material.color = Color.red;
                damagedCpt -= Time.deltaTime;
            }
            else
                GetComponent<Renderer>().material.color = originalColor;
        }
    }

    public void loseLife()
    {
        health--;
        Damaged.Invoke();
        LifeEvent.Invoke(1.0f*health/maxHealth);
        damagedCpt = 0.2f;
        if(health <= 0)
        {
            Death.Invoke();
            GetComponent<Rigidbody>().useGravity = true;
            //Destroy(this.gameObject);
        }
    }
}
