using UnityEngine;
using System.Collections;

public class PanelScript : MonoBehaviour {

	private Vector3 newPosition;
	private Vector3 pos1, pos2, pos3, pos4;
	public bool onActive = false;
	public GameObject[] panelCheck; //array for 4 panels
	int cnt = 1; //counter for assigning panels into array

	void Awake()
	{
		newPosition = transform.position;
		pos1 = new Vector2(-3.7f, 2.35f);
		pos2 = new Vector2(3.76f, 2.35f);
		pos3 = new Vector2(-3.7f, -2.4f);
		pos4 = new Vector2(3.76f, -2.4f);

		for(int p = 0; p < 4; p++)
		{
			panelCheck[p] = GameObject.Find ("Panel"+cnt+"Check");
			cnt++;
		}
	}

	void Update () 
	{
		if(onActive)
		{
			PanelMovement();
		}
	}

	void PanelMovement()
	{
		if(Input.GetAxisRaw("Horizontal") > 0)
		{
			if(!Physics.Raycast(transform.position-transform.right*3.2f, -transform.right, 1.5f))
			{
				if(transform.position.y > 0)	
				{
					newPosition = pos2;
				}
				else
				{
					newPosition = pos4;
				}
			}
		}
		if(Input.GetAxisRaw("Horizontal") < 0)
		{
			if(!Physics.Raycast(transform.position+transform.right*3.2f, transform.right, 1.5f))
			{
				if(transform.position.y > 0)
				{
					newPosition = pos1;
				}
				else
				{
					newPosition = pos3;
				}
			}
		}
		if(Input.GetAxisRaw("Vertical") > 0)
		{
			if(!Physics.Raycast(transform.position-transform.forward*1.9f, -transform.forward, 1.2f))
			{
				if(transform.position.x < 0)
				{
					newPosition = pos1;
				}
				else
				{
					newPosition = pos2;
				}
			}
		}
		if(Input.GetAxisRaw("Vertical") < 0)
		{
			if(!Physics.Raycast(transform.position+transform.forward*1.9f, transform.forward, 1.2f))
			{
				if(transform.position.x < 0)
				{
					newPosition = pos3;
				}
				else
				{
					newPosition = pos4;
				}
			}
		}
		
		transform.position = Vector3.Lerp(transform.position, newPosition, 6f * Time.deltaTime);
	}

}
