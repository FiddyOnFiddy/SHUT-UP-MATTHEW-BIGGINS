using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathTriggerScript : MonoBehaviour
{
    public Vector3 initialPlayerPos;

    // Use this for initialization
    void Start ()
    {
        initialPlayerPos = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>().position;
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        { 
            collision.gameObject.transform.position = initialPlayerPos;

            Debug.Log("Player Died");
        }
    }
}
