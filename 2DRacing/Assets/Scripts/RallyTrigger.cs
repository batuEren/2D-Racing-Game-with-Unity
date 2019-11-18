using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RallyTrigger : MonoBehaviour {

    [SerializeField] Transform player1;
    [SerializeField] RallyCarControl player11;
    [SerializeField] Transform player2;
    [SerializeField] RallyCarControl player22;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            player1.transform.position= new Vector3(-366,-37,0);
            player11.speed2 = 0f;
        }
        if (collision.tag == "PLayer2")
        {
            player2.transform.position = new Vector3(-366, -34, 0);
            /*player2.transform.vector = new Vector3(0, 0, 0);*/
            player22.speed2 = 0f;
        }
    }
}
