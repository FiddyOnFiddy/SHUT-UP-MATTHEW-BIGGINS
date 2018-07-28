using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRewindScript : MonoBehaviour
{
    public bool isRewinding = false;
    PlayerMovement playerMovement;

    public float rewindTime = 2.0f;

    public List<Vector3> positions;
    public List<Quaternion> rotations;

    // Use this for initialization
    void Start ()
    {
        positions = new List<Vector3>();
        rotations = new List<Quaternion>();

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

    void RewindAnimation()
    {
       
    }

    void Rewind()
    {
        if (positions.Count > 0 && rewindTime >= 0.0f && rotations.Count > 0)
        {
            transform.position = positions[0];
            positions.RemoveAt(0);

            transform.rotation = rotations[0];
            rotations.RemoveAt(0);
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
            rotations.Clear();
        }
    }

    void Record ()
    {
        if(playerMovement.isMoving && rewindTime >= 0.0f)
        {
            positions.Insert(0, transform.position);
            rotations.Insert(0, transform.rotation);
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
