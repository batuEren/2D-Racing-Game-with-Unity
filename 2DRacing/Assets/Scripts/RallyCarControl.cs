using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RallyCarControl : MonoBehaviour
{

    [SerializeField] public float maxSpeed2 = 30f;
    [SerializeField] private float accelaration2 = 0.5f;
    public float speed2;
    private float oldturnSpeed2;
    private float oldDriftFactor2;
    private float rotation2;
    [SerializeField] private float turnSpeed2 = -5f;
    [SerializeField] private float driftFactor2 = 0.50f;
    [SerializeField] private float breakSpeed2;
    [SerializeField] private KeyCode turnLeft2;
    [SerializeField] private KeyCode turnRight2;
    [SerializeField] private KeyCode extremeStaier2;
    [SerializeField] private KeyCode breaks2;
    [SerializeField] private KeyCode gas2;
    [SerializeField] private KeyCode reverse2;
    [SerializeField] Rigidbody2D rb2;

    // Use this for initialization
    void Start()
    {
        oldturnSpeed2 = turnSpeed2;
        oldDriftFactor2 = driftFactor2;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {


        /*speed = 0f;*/

    }

    void FixedUpdate()
    {
        speed2 = speed2 - 0.5f;



        if (speed2 < 0f)
        {
            speed2 = 0f;
        }

        if (Input.GetKey(gas2))
        {
            speed2 = speed2 + accelaration2;
        }
        if (speed2 > maxSpeed2)
        {
            speed2 = maxSpeed2;
        }

        rb2.AddForce(transform.up * -speed2);

        if (Input.GetKey(reverse2))
        {
            rb2.velocity = (transform.up * speed2 * 0.5f);
        }

        if (Input.GetKey(breaks2))
        {
            rb2.AddForce(transform.up * breakSpeed2);
            driftFactor2 = 0.9f;
        }
        else
        {
            driftFactor2 = oldDriftFactor2;
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
        if (Input.GetKey(extremeStaier2))
        {
            turnSpeed2 = -3f;
            driftFactor2 = 0f;
        }
        else
        {
            turnSpeed2 = oldturnSpeed2;
            driftFactor2 = oldDriftFactor2;

        }
        if ((Input.GetKey(turnLeft2)) && (Input.GetKey(turnRight2)))
        {

        }
        else if (Input.GetKey(turnLeft2))
        {
            rotation2 = -1f * turnSpeed2;
        }
        else if (Input.GetKey(turnRight2))
        {
            rotation2 = 1f * turnSpeed2;
        }
        else
        {
            rotation2 = 0f;
        }

        /*float rotation =Input.GetAxis("Horizontal") * turnSpeed /** (Mathf.Abs(ForwardVelocity().x)+ Mathf.Abs(ForwardVelocity().y))*/
            ;
        transform.Rotate(0, 0, rotation2);

        rb2.velocity = ForwardVelocity2() + RightVelocity2() * driftFactor2;
    }
    Vector2 ForwardVelocity2()
    {
        return transform.up * Vector2.Dot(rb2.velocity, transform.up);
    }
    Vector2 RightVelocity2()
    {
        return transform.right * Vector2.Dot(rb2.velocity, transform.right);
    }
}
