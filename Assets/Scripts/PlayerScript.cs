using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    [System.Serializable]
    public class MyEvent : UnityEvent<int, bool> {}
    [SerializeField]
    public MyEvent Damaged;

    public UnityEvent Death;
    public UnityEvent Pause;
    public GameObject fireballPrefab;
    public float moveSpeed = 10f;
    private float XSensivity = 1f;
    private float YSensivity = 1f;
    public float shootSpeed = 180f;
    public float fireCooldown = 0.5f;
    private float fireCooldownCpt = 0;
    private float shakeCpt = 0;

    public int health = 3;

    public float interactionDistance = 0.5f;

    private float rotationX = 0f;
    private float rotationY = 0f;
    private float lockMinY = -50f;
    private float lockMaxY = 50f;
    private float shakeMagnitude = 2;

    private Vector3 originalPosition;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        originalPosition = transform.GetChild(0).transform.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
        if(health > 0 && Time.timeScale > 0)
        {
            Transform camera = transform.GetChild(0);
            JumpLimiter jumpLimiter = transform.GetChild(1).gameObject.GetComponent<JumpLimiter>();

            //Move
            transform.Translate(Vector3.forward * Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime);
            transform.Translate(Vector3.right * Input.GetAxis("Horizontal") *  moveSpeed * Time.deltaTime);

            //Camera rotations

            rotationX = 0;
            if(Input.GetAxis("JoystickY") > 0.1 || Input.GetAxis("JoystickY") < -0.1 )
            {
                Debug.Log(Input.GetAxis("JoystickY"));
                rotationY -= Input.GetAxis("JoystickY") * YSensivity;
            }

            if(Input.GetAxis("JoystickX") > 0.1 || Input.GetAxis("JoystickX") < -0.1)
            {
                Debug.Log(Input.GetAxis("JoystickX") * XSensivity);
                rotationX = Input.GetAxis("JoystickX") * XSensivity;
            }
            else
                rotationX = Input.GetAxis("Mouse X") * XSensivity;

            
            rotationY -= Input.GetAxis("Mouse Y") * YSensivity;
            rotationY = Mathf.Clamp(rotationY, lockMinY, lockMaxY);

            //Rotate cam on Y
            camera.localRotation = Quaternion.Euler(rotationY, 0, 0);

            //Rotate body + cam on X
            transform.Rotate(Vector3.up, rotationX);
            GetComponent<Rigidbody>().MoveRotation(transform.rotation);


            //Jump
            if(Input.GetButtonDown("Jump") && jumpLimiter.canJump)
            {
                GetComponent<Rigidbody>().AddForce(new Vector3(0f,5f,0f), ForceMode.Impulse);
                jumpLimiter.canJump = false;
            }

            //RayCast
            RaycastHit hit;


            Debug.DrawRay(camera.position, camera.forward, Color.red);
            if(Physics.Raycast(camera.position, camera.forward, out hit, interactionDistance, LayerMask.GetMask("Default")))
            {
                Debug.DrawRay(camera.position, camera.forward * hit.distance, Color.yellow);
                //Debug.Log("hit");
                GameObject obj;
                obj = hit.collider.gameObject;
                if(Input.GetButtonDown("Interact") && obj.tag == "Button")
                {
                    ((ButtonScript)obj.GetComponent<ButtonScript>()).trigger();
                }

            }

            if(fireCooldownCpt > 0)
                fireCooldownCpt -= Time.deltaTime;
            //Fire
            if((Input.GetButtonDown("Fire1") || Input.GetAxis("Fire1") > 0) && fireCooldownCpt <= 0)
            {
                GameObject fireBall;
                fireBall = Instantiate(fireballPrefab, camera.position, camera.rotation);
                fireBall.GetComponent<Rigidbody>().AddForce(camera.forward * shootSpeed);
                fireCooldownCpt = fireCooldown;
            }

            if(shakeCpt > 0)
            {
                camera.transform.Translate(camera.forward * Random.Range(-1f,1f) * Time.deltaTime * shakeMagnitude);
                camera.transform.Translate(camera.right * Random.Range(-1f,1f) * Time.deltaTime * shakeMagnitude);
                camera.transform.Translate(camera.up * Random.Range(-1f,1f) * Time.deltaTime * shakeMagnitude);
                shakeCpt -= Time.deltaTime;
            }
            else
                camera.transform.localPosition = originalPosition;
            

            if(Input.GetButtonDown("Cancel"))
            {
                pause();
            }
        }

    }

    void OnDrawGizmos()
    {
        Gizmos.DrawSphere(transform.GetChild(0).position + transform.GetChild(0).forward *2, 0.02f);
    }

    public void damage()
    {
        health--;
        Damaged.Invoke(health, true);
        if(health <= 0)
        {
            Death.Invoke();
        }

    }

    public void heal()
    {
        if(health < 3)
            health++;
        Damaged.Invoke(health, false);
    }

    public void pause()
    {
        Time.timeScale = 0;
        Pause.Invoke();
    }

    public void unPause()
    {
        Time.timeScale = 1;
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void shake()
    {
        shakeCpt = 2f;
    }
}
