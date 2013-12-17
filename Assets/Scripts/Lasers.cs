using UnityEngine;
using System.Collections;

public class Lasers : MonoBehaviour {

	bool lasersOff;
	public GameObject[] laserthings;
	public bool flick, toggle;

	public void LasersKilled()
	{
		StartCoroutine("delayOpen");
		audio.Play();
	}

	void Awake()
	{
		if(flick)
		{
			InvokeRepeating("FlickOn", 0f, 3f);
		}
	}

	void Update()
	{
		if(lasersOff)
		{
			foreach(GameObject go in laserthings)
			{
				Vector2 newScale = go.transform.localScale;
				newScale.y -= .6f * Time.deltaTime;
				
				if(newScale.y <= 0f)
				{
					newScale.y = 0f;
				}
				go.transform.localScale = newScale;
				go.GetComponent<BoxCollider2D>().enabled = false;
			}
		}
	}

	IEnumerator delayOpen()
	{
		yield return new WaitForSeconds(.2f);
		lasersOff = true;
	}

	void FlickOn()
	{
		toggle = !toggle;
		if(toggle)
		{
			transform.GetChild(0).transform.gameObject.SetActive(false);
		}
		else
		{
			transform.GetChild(0).transform.gameObject.SetActive(true);
		}
	}
}
