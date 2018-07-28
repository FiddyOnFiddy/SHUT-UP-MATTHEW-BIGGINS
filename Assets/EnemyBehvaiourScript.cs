using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehvaiourScript : MonoBehaviour
{

    public BoxCollider2D attackTrigger;
    public Rigidbody2D rb;

    public float fallSpeed;

	// Use this for initialization
	void Start ()
    {
        rb.gravityScale = 0.0f;
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            rb.gravityScale = fallSpeed;
        }
    }
}
