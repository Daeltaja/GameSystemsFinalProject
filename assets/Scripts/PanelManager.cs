using UnityEngine;
using System.Collections;

public class PanelManager : MonoBehaviour {
	
	public GameObject[] panels; //array for 4 panels
	private int cnt = 1; //counter for assigning panels into array
	public static bool isMovable = true;

	void Awake()
	{
		for(int p = 0; p < 3; p++)
		{
			panels[p] = GameObject.Find ("Panel"+cnt);
			cnt++;
		}
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
		}
	}

	void Raycast()
	{
		if (Input.GetButtonDown("Fire1")) 
		{
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			RaycastHit whatIHit;

			if (Physics.Raycast(ray, out whatIHit))
			{
				foreach(GameObject go in panels)
				{
					PanelScript allPanels = go.GetComponent<PanelScript>();
					allPanels.onActive = false;
				}
				isMovable = true;
				PanelScript thisPanel = whatIHit.collider.gameObject.GetComponent<PanelScript>();
				thisPanel.onActive = true;
			}
		}
	}
}
