using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerEvent : MonoBehaviour {

    [SerializeField] CarControl player;
    [SerializeField] CarControl player2;


    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            player.maxSpeed = 7f;
            player.speed = player.speed - 0.1f;
            
        }
        if(collision.tag == "PLayer2")
        {
            player2.maxSpeed = 7f;
            player2.speed = player2.speed - 0.1f;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            player.maxSpeed = 16f;
        }
        if (collision.tag == "PLayer2")
        {
            player2.maxSpeed = 16f;
        }
            
    }

}
