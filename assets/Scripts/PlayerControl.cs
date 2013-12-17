using UnityEngine;
using System.Collections;

public class PlayerControl : MonoBehaviour
{
	private float speed = 6f;
	private bool grounded, interact;
	private Transform jumpStart, jumpEnd1, interactCheck, panelCheck, jumpEnd2, myTrans;
	private Vector2 newScale;
	private float xScale;
	RaycastHit2D interacted, whichPanel; 

	Animator anim;
	
	void Awake()
	{
		newScale = transform.localScale;
		xScale = newScale.x; //store x scale of Meko
		interactCheck = transform.Find("InteractCheck");
		jumpEnd1 = transform.Find ("JumpEnd1");
		jumpEnd2 = transform.Find("JumpEnd2");
		jumpStart = transform.Find("JumpStart");
		panelCheck = transform.Find("PanelCheck");
		myTrans = transform.Find("Transform");
		anim = GetComponent<Animator>();
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
		Debug.DrawLine(jumpStart.position, jumpEnd1.position, Color.magenta);
		Debug.DrawLine(jumpStart.position, jumpEnd2.position, Color.magenta);
		Debug.DrawLine(myTrans.position, interactCheck.position, Color.magenta);
		Debug.DrawLine(myTrans.position, panelCheck.position, Color.magenta);

		grounded = Physics2D.Linecast(jumpStart.position, jumpEnd1.position, 1 << LayerMask.NameToLayer("Ground")) 
			||Physics2D.Linecast(jumpStart.position, jumpEnd2.position, 1 << LayerMask.NameToLayer("Ground"));  

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
		anim.SetFloat("Speed", Mathf.Abs(Input.GetAxisRaw("Horizontal")));

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
			anim.SetTrigger("Jump");
			audio.Play ();
		}
	}

	public void SitDownUp()
	{
		if(PanelManager.isMovable)
		{
		 anim.SetTrigger("Sit");
		}
		else
		{
			anim.SetTrigger("UnSit");
		}
	}
}
