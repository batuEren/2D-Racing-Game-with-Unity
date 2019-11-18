using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarControl : MonoBehaviour {

    [SerializeField] public float maxSpeed = 30f;
    [SerializeField] private float accelaration = 0.5f;
    public float speed;
    private float oldturnSpeed;
    private float oldDriftFactor;
    private float rotation;
    [SerializeField] private float turnSpeed = -5f;
    [SerializeField] private float driftFactor = 0.50f;
    [SerializeField] private float breakSpeed;
    [SerializeField] private KeyCode turnLeft;
    [SerializeField] private KeyCode turnRight;
    [SerializeField] private KeyCode extremeStaier;
    [SerializeField] private KeyCode breaks;
    [SerializeField] private KeyCode gas;
    [SerializeField] private KeyCode reverse;
    [SerializeField] Rigidbody2D rb;

	// Use this for initialization
	void Start () {
        oldturnSpeed = turnSpeed;
        oldDriftFactor = driftFactor;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        
            /*speed = 0f;*/
        
    }

    void FixedUpdate()
    {
        speed = speed - 0.01f;

        

        if (speed < -1f)
        {
            speed = -1f;
        }

        if (Input.GetKey(gas))
        {
            speed = speed + accelaration;                    
        }
        if (speed > maxSpeed)
        {
            speed = maxSpeed;
        }

        rb.velocity = (transform.up * -speed);

        if (Input.GetKey(reverse))
        {
            rb.velocity = (transform.up * speed * 0.5f);
        }

        if (Input.GetKey(breaks))
        {
            speed = speed - breakSpeed;
        }


        /*
        rb.AddTorque(Input.GetAxis("Horizontal") * turnSpeed);
        if (Input.GetAxis("Horizontal") == 0)
        {
            rb.angularDrag = 30f;
        }
        else
        {
            rb.angularDrag = 1f;
        }
        
        else
        {
            driftFactor = 0.90f;
        }*/
        if (Input.GetKey(extremeStaier))
        { 
            turnSpeed = -3f;
            driftFactor = 0f;
        }
        else
        {
            turnSpeed = oldturnSpeed;
            driftFactor = oldDriftFactor;

        }
        if ((Input.GetKey(turnLeft)) && (Input.GetKey(turnRight)))
        {
            
        }
        else if (Input.GetKey(turnLeft))
        {
            rotation = -1f * turnSpeed;
        }
        else if (Input.GetKey(turnRight))
        {
            rotation = 1f * turnSpeed;
        }
        else
        {
            rotation = 0f;
        }

        /*float rotation =Input.GetAxis("Horizontal") * turnSpeed /** (Mathf.Abs(ForwardVelocity().x)+ Mathf.Abs(ForwardVelocity().y))*/
            ;
            transform.Rotate(0,0, rotation);

        rb.velocity = ForwardVelocity() + RightVelocity() * driftFactor;
    }
    Vector2 ForwardVelocity()
    {
        return transform.up * Vector2.Dot( rb.velocity, transform.up );
    }
    Vector2 RightVelocity()
    {
        return transform.right * Vector2.Dot(rb.velocity, transform.right);
    }
}
