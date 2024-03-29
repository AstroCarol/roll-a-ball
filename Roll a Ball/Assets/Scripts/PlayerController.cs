﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public float speed;
	public float jump;
	public Text countText;
	public Text winText;

    private Rigidbody rb;
    private int count;

    void Start ()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        SetCountText ();
        winText.text = "";
    }

    void FixedUpdate ()
    {
        float moveHorizontal = Input.GetAxis ("Horizontal");
        float moveVertical = Input.GetAxis ("Vertical");

        Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);

        rb.AddForce (movement * speed);
    }

    void Update ()
    {
    	if (Input.GetKeyDown ("space") && GetComponent<Rigidbody>().transform.position.y <= 0.625f)
    	{
    		Vector3 jump = new Vector3 (0.0f, 400.0f, 0.0f);
    		GetComponent<Rigidbody>().AddForce (jump);
    	}
    }

    void OnTriggerEnter(Collider other)
    {
    	if (other.gameObject.CompareTag ("Pick Up"))
    	{
    		other.gameObject.SetActive (false);
			count = count + 1;
			SetCountText ();    	
    	}
    }

    void SetCountText ()
    {
    	countText.text = "Count: " + count.ToString ();
    	if (count >= 22)
    	{
    		winText.text = "You Win!";
    	}
    }
}