using UnityEngine;
using System.Collections;

public class TriggerBounds : MonoBehaviour {

	public bool delayLaser;
	GameObject meko;

	void Awake()
	{
		meko = GameObject.Find("PlayerMeko");
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.collider2D.name == "PlayerMeko")
		{
			if(!delayLaser)
			{
				Application.LoadLevel(Application.loadedLevelName);
			}
			else
			{
				meko.GetComponent<Animator>().SetTrigger("Electro");
				PanelManager.isMovable = true;
				StartCoroutine("delayDeath");
			}

		}
	}

	IEnumerator delayDeath()
	{
		yield return new WaitForSeconds(2f);
		Application.LoadLevel(Application.loadedLevelName);
	}
}

