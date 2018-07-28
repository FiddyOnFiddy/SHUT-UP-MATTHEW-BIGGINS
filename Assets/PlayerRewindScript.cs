using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRewindScript : MonoBehaviour
{
    public bool isRewinding = false;
    Rigidbody2D rb;
    PlayerMovement playerMovement;

    public float rewindTime = 2.0f;

    public List<Vector3> positions;

	// Use this for initialization
	void Start ()
    {
        positions = new List<Vector3>();
        rb = GetComponent<Rigidbody2D>();
        playerMovement = GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update ()
    {
        if(Input.GetKeyDown(KeyCode.LeftControl))
        {

            StartRewind();
        }
        if (Input.GetKeyUp(KeyCode.LeftControl))
        {
            StopRewind();
            rewindTime = 2.0f;
        }

        RewindTimer();
        

    }

    void FixedUpdate()
    {
        if(isRewinding)
        {
           //b.isKinematic = true;
            Rewind();
        }
        else
        {
           //b.isKinematic = false;
            Record();
        }
    }

    void Rewind()
    {
        if (positions.Count > 0 && rewindTime >= 0.0f)
        {
            transform.position = positions[0];
            positions.RemoveAt(0);
        }
        else
        {
            StopRewind();
        }
        
    }

    void RewindTimer()
    {
        if (isRewinding)
        {
            rewindTime -= Time.deltaTime;
        }

        if (rewindTime <= 0.0f)
        {
            positions.Clear();
        }
    }

    void Record ()
    {
        if(playerMovement.isMoving && rewindTime >= 0.0f)
        {
            positions.Insert(0, transform.position);
        }
    }

    public void StartRewind()
    {
        isRewinding = true;
    }

    public void StopRewind()
    {
        isRewinding = false;
    }
}
