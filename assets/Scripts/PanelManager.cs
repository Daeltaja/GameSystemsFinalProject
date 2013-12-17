using UnityEngine;
using System.Collections;

public class PanelManager : MonoBehaviour {
	
	public GameObject[] panels; //array for 4 panels
	private GameObject meko;
	private int cnt = 1; //counter for assigning panels into array
	public static bool isMovable = false;
	private bool hasHit;
	public bool isTutorial = false, finaltut;
	public Sprite panel, panelSelected;
	RaycastHit whatIHit;
	public GameObject target, target2, target3, target4;

	void Awake()
	{
		for(int p = 0; p < 3; p++)
		{
			panels[p] = GameObject.Find ("Panel"+cnt);
			cnt++;
		}
		meko = GameObject.Find ("PlayerMeko");
	}

	void Update () 
	{
		Raycast();
		ToggleStates();
	}

	void ToggleStates()
	{
		if(Input.GetKeyDown(KeyCode.Space))
		{
			isMovable = !isMovable;
			meko.BroadcastMessage("SitDownUp");
			if(!isMovable)
			{
				FlushSelection();
			}
			else
			{
				if(hasHit)
				{
					GameObject mySiblingN = whatIHit.collider.gameObject.GetComponent<PanelScript>().sibling.transform.GetChild(0).gameObject;
					mySiblingN.GetComponent<SpriteRenderer>().sprite = panelSelected;
				}
			}
		
			if(finaltut)
			{
				target3.GetComponent<TextFade>().fadeMeIn = true; //fade in
				finaltut = false;
				isTutorial = false;
			}
		}
	}

	void Raycast()
	{
		if (Input.GetButtonDown("Fire1")) 
		{
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

			if (Physics.Raycast(ray, out whatIHit))
			{
				foreach(GameObject go in panels)
				{
					PanelScript allPanels = go.GetComponent<PanelScript>();
					allPanels.onActive = false;
					go.GetComponent<PanelScript>().sibling.transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = panel;
				}
				if(isTutorial) //toggle text tutorials
				{
					if(whatIHit.collider.name == "Panel2")
					{
						target.GetComponent<TextFade>().fadeMeIn = true;
						target2.GetComponent<TextFade>().fadeMeIn = false;
					}
				}
				hasHit = true;
				isMovable = true;
				PanelScript thisPanel = whatIHit.collider.gameObject.GetComponent<PanelScript>();
				thisPanel.onActive = true;
				Debug.Log ("LOL");
				whatIHit.collider.gameObject.GetComponent<PanelScript>().sibling.transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = panelSelected;
			}
		}
	}
	
	public void FlushSelection()
	{
		foreach(GameObject go in panels)
		{
			go.transform.GetComponent<PanelScript>().sibling.transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = panel;
		}
	}

	public void TutorialCheck()
	{
		if(isTutorial)
		{
			target2.GetComponent<TextFade>().fadeMeIn = true;
			target3.GetComponent<TextFade>().fadeMeIn = false; //fade in
			target4.GetComponent<TextFade>().fadeMeIn = true; //fade out
			finaltut = true;
		}
	}
}
