using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;

public class EnemyScript : MonoBehaviour
{

    public GameObject[] positionGoal;
    public int positionAim = 0;
    public int health = 3;
    public bool canBeKilled = true;
    public bool damageMeleeMode = false;
    public UnityEvent DeathEvent;
    private float damagedTimeCpt = 0;
    private bool damaged = false;
    private float stopTimeCpt = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.x == positionGoal[positionAim].transform.position.x && transform.position.z == positionGoal[positionAim].transform.position.z)
        {
            positionAim = (positionAim + 1) % positionGoal.Length;
        }
        GetComponent<NavMeshAgent>().SetDestination(positionGoal[positionAim].transform.position);

        if(damaged && damagedTimeCpt < 0.2)
        {
            GetComponent<Renderer>().material.SetColor("_Color",Color.red);
            damagedTimeCpt += Time.deltaTime;
        }
        else
        {
            GetComponent<Renderer>().material.SetColor("_Color",Color.white);
            damaged = false;
            damagedTimeCpt = 0;
        }

        if(stopTimeCpt > 0)
        {
            GetComponent<NavMeshAgent>().SetDestination(transform.position);
            stopTimeCpt-= Time.deltaTime;
        }

    }

    public void loseLife()
    {
        if(canBeKilled)
        {
            health--;
            damaged = true;
            if(health <= 0)
            {
                DeathEvent.Invoke();
                Destroy(this.gameObject);
            }
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag == "Player" && damageMeleeMode)
        {
            
            GameObject obj = other.gameObject; 
            ((PlayerScript)(obj.GetComponent<PlayerScript>())).damage();
            Vector3 force = transform.position - other.transform.position;
            force.Normalize();
            obj.GetComponent<Rigidbody>().AddForce(-force * 300);

            stopTimeCpt = 1f;
        }
    }

}
