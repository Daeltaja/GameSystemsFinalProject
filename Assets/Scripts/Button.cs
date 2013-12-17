using UnityEngine;
using System.Collections;

public class Button : MonoBehaviour {

	public GameObject door, lasers;
	public bool laserButton;
	public string laserName;
	
	void Awake () 
	{
		door = GameObject.Find ("TheDoor");
	}
	
	void OnTriggerEnter2D(Collider2D other)
	{
		if(!laserButton)
		{
			if(other.collider2D.name == "PlayerMeko")
			{
				transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().sortingOrder = 2;
				transform.GetChild(1).gameObject.GetComponent<SpriteRenderer>().sortingOrder = 1;
				door.BroadcastMessage("OpenDoor");
				GetComponent<BoxCollider2D>().enabled = false;
				GetComponent<BoxCollider2D>().isTrigger = false;
			}
		}
		else
		{
			if(other.collider2D.name == "PlayerMeko")
			{
				transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().sortingOrder = 2;
				transform.GetChild(1).gameObject.GetComponent<SpriteRenderer>().sortingOrder = 1;
				lasers.BroadcastMessage("LasersKilled");
				GetComponent<BoxCollider2D>().enabled = false;
				GetComponent<BoxCollider2D>().isTrigger = false;
			}
		}
	}
}
