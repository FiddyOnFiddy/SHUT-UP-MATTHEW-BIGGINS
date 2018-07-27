using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRewindScript : MonoBehaviour
{
    public List<Transform> prevPos = new List<Transform>();


	// Use this for initialization
	void Start ()
    {
        defaultRewindTime = maxRewindTime;
	}
	
	// Update is called once per frame
	void Update ()
    {
        TrackPlayerPos();
        RewindPlayer();
	}

    public void RewindPlayer()
    {
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {

        }
    }

    public void TrackPlayerPos()
    {
        
       for (int i = 0; i < prevPos.Count - 1; i++)
       {
         prevPos.Add(gameObject.transform);
       }
  
    }
}
