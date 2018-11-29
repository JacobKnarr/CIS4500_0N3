using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGScroller : MonoBehaviour {

    public Transform tf;
    public float scrollSpeed;
    public float tileSizeZ;

    private Vector3 startPosition;

	void Start ()
    {
        tf = GetComponent<Transform>();
        startPosition = tf.position;
	}
	
	
	void Update ()
    {
        float newPosition = Mathf.Repeat(Time.time * scrollSpeed, tileSizeZ);
        tf.position = startPosition + Vector3.forward * newPosition;
	}
}
