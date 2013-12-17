using UnityEngine;
using System.Collections;

public class TutTrigger : MonoBehaviour {

	public GameObject target, target2, target3;
	public string messageToSend;

	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.collider2D.name == "PlayerMeko")
		{
			target.GetComponent<BlackPanelHide>().fadeMeIn = true;
			if(target2 != null)
			{
				target2.GetComponent<BlackPanelHide>().fadeMeIn = false;
			}
			if(target3 != null)
			{
				target3.BroadcastMessage(messageToSend);
			}
			Destroy(gameObject);
		}
	}
}
