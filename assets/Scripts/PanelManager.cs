using UnityEngine;
using System.Collections;

public class PanelManager : MonoBehaviour {
	
	public GameObject[] panels; //array for 4 panels
	int cnt = 1; //counter for assigning panels into array

	void Start()
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

				PanelScript thisPanel = whatIHit.collider.gameObject.GetComponent<PanelScript>();
				thisPanel.onActive = true;
			}
		}
	}
}
