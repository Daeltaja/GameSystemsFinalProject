using UnityEngine;
using System.Collections;

public class TextTrigger : MonoBehaviour {

	public GameObject target, target2;
	public string messageToSend;

	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.collider2D.name == "PlayerMeko")
		{
			target.BroadcastMessage(messageToSend);
			if(target2 != null)
			{
				target2.BroadcastMessage(messageToSend);
			}
			Destroy(gameObject);
		}
	}
}
