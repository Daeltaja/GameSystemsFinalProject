using UnityEngine;
using System.Collections;

public class PlayerControl : MonoBehaviour
{
	private float speed = 6f;
	private bool grounded, interact;
	private Transform jumpStart, jumpEnd, interactCheck, panelCheck;
	private Vector2 newScale;
	private float xScale;
	RaycastHit2D interacted, whichPanel; 
	
	void Awake()
	{
		newScale = transform.localScale;
		xScale = newScale.x; //store x scale of Meko
		interactCheck = transform.GetChild(0);
		jumpEnd = transform.GetChild(1);
		jumpStart = transform.GetChild (2);
		panelCheck = transform.GetChild (3);
	}

	void Update()
	{
		if(!PanelManager.isMovable)
		{
			Movement();
		}
		RaycastStuff(); 
	}

	void RaycastStuff()
	{
		Debug.DrawLine(transform.position, jumpEnd.position, Color.magenta);
		Debug.DrawLine(transform.position, interactCheck.position, Color.magenta);
		Debug.DrawLine(transform.position, panelCheck.position, Color.magenta);

		grounded = Physics2D.Linecast(jumpStart.position, jumpEnd.position, 1 << LayerMask.NameToLayer("Ground"));  

		if(Physics2D.Linecast(transform.position, panelCheck.position, 1 << LayerMask.NameToLayer("Panel")))
		{
			whichPanel = Physics2D.Linecast(transform.position, panelCheck.position, 1 << LayerMask.NameToLayer("Panel"));
			transform.parent = whichPanel.collider.transform.parent.transform;
		}

		if(Physics2D.Linecast(transform.position, interactCheck.position, 1 << LayerMask.NameToLayer("Guard")))
		{
			interacted = Physics2D.Linecast(transform.position, interactCheck.position, 1 << LayerMask.NameToLayer("Guard")); 
			interact = true; 
		}
		else
		{
			interact = false; 
		}
	}

	void Movement()
	{
		if(Input.GetAxisRaw("Horizontal") > 0)
		{
			transform.Translate(Vector3.right * speed * Time.deltaTime); 
			Vector2 newScale = transform.localScale;
			newScale.x = xScale;
			transform.localScale = newScale;
		}

		if(Input.GetAxisRaw("Horizontal") < 0)
		{
			transform.Translate(-Vector3.right * speed * Time.deltaTime);
			Vector2 newScale = transform.localScale;
			newScale.x = -xScale;
			transform.localScale = newScale;
		}

		if(Input.GetKeyDown (KeyCode.W) && grounded) 
		{
			rigidbody2D.AddForce(transform.up * 600f);
		}
	}
}
