using UnityEngine;
using System.Collections;

public class Door : MonoBehaviour {

	public GameObject[] lasers;
	int cnt = 1;
	bool doorActivated;
	public AudioClip button;

	void Awake () 
	{
		for(int p = 0; p < 4; p++)
		{
			lasers[p] = GameObject.Find ("DoorLaser"+cnt);
			cnt++;
		}
	}

	public void OpenDoor()
	{
		StartCoroutine("delayOpen");
		audio.PlayOneShot(button);
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.collider2D.name == "PlayerMeko")
		{
			if(doorActivated)
			{
				PanelManager.isMovable = true;
				Debug.Log ("EXIT");
				BlackFade.fadeIn = false;
				StartCoroutine("delayLoad");
			}
		}
	}

	void Update()
	{
		if(doorActivated)
		{
			foreach(GameObject go in lasers)
			{
				Vector2 newScale = go.transform.localScale;
				newScale.x -= .6f * Time.deltaTime;
				
				if(newScale.x <= 0f)
				{
					newScale.x = 0f;
				}
				go.transform.localScale = newScale;
			}
		}
	}

	IEnumerator delayLoad()
	{
		yield return new WaitForSeconds(2.4f);
		Application.LoadLevel(Application.loadedLevel+1);
	}

	
	IEnumerator delayOpen()
	{
		yield return new WaitForSeconds(.2f);
		doorActivated = true;
	}
}
