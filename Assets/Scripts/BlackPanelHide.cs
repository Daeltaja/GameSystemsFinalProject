using UnityEngine;
using System.Collections;

public class BlackPanelHide : MonoBehaviour {

	Color color;
	public bool fadeMeIn = false;
	
	void Awake()
	{
		fadeMeIn = false;
	}
	
	void Update()
	{
		if(fadeMeIn)
		{
			color = renderer.material.color;
			color.a -= 0.7f * Time.deltaTime;
			if(color.a <= 0f)
			{
				color.a = 0f;
			}
		}
		else
		{
			color = renderer.material.color;
			color.a += 0.7f * Time.deltaTime;
			if(color.a >= 1f)
			{
				color.a = 1f;
			}
		}
		renderer.material.color = color;
	}

	public void Toggle()
	{
		fadeMeIn = true;
	}
}

