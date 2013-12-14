using UnityEngine;
using System.Collections;

public class PanelScript : MonoBehaviour {

	private Vector3 newPosition; //stores new position
	private Vector3 newPositionSibling; //stores new position for game panel
	private Vector3 pos1, pos2, pos3, pos4; //positions for panels
	private Vector3 spos1, spos2, spos3, spos4; //handle the positions for game panels
	private int cnt = 1; //counter for assigning panels into array
	public bool onActive = false;
	public GameObject sibling; //matching game panel 

	void Awake()
	{
		newPosition = transform.position;
		newPositionSibling = sibling.transform.position;

		pos1 = new Vector2(-3.7f, 2.35f);
		pos2 = new Vector2(3.76f, 2.35f);
		pos3 = new Vector2(-3.7f, -2.4f);
		pos4 = new Vector2(3.76f, -2.4f);

		spos1 = new Vector3(30f, 0f, -10f);
		spos2 = new Vector3(49.9f, 0f, -10f);
		spos3 = new Vector3(30f, -9.951f, -10f);
		spos4 = new Vector3(49.9f, -9.951f, -10f);
	}

	void Update () 
	{
		if(PanelManager.isMovable)
		{
			if(onActive)
			{
				PanelMovement();
			}
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
					newPositionSibling = spos2;
				}
				else
				{
					newPosition = pos4;
					newPositionSibling = spos4;
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
					newPositionSibling = spos1;
				}
				else
				{
					newPosition = pos3;
					newPositionSibling = spos3;
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
					newPositionSibling = spos1;
				}
				else
				{
					newPosition = pos2;
					newPositionSibling = spos2;
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
					newPositionSibling = spos3;
				}
				else
				{
					newPosition = pos4;
					newPositionSibling = spos4;

				}
			}
		}
		
		transform.position = Vector3.Lerp(transform.position, newPosition, 6f * Time.deltaTime);
		sibling.transform.position = newPositionSibling;
	}

}
