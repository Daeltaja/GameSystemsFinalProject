using UnityEngine;
using System.Collections;

public class TextFade : MonoBehaviour {

	Color color;
	public bool fadeMeIn = false;
	public bool destroy = false;
	
	void Update()
	{
		if(fadeMeIn)
		{
			color = GetComponent<SpriteRenderer>().color;
			color.a -= 0.7f * Time.deltaTime;
			if(color.a <= 0f)
			{
				color.a = 0f;
				if(destroy)
				{
					Destroy(gameObject);
				}
			}
		}
		else
		{
			color = GetComponent<SpriteRenderer>().color;
			color.a += 0.7f * Time.deltaTime;
			if(color.a >= 1f)
			{
				color.a = 1f;
			}
		}
		GetComponent<SpriteRenderer>().color = color;
	}
	
	public void Toggle()
	{
		fadeMeIn = !fadeMeIn;
	}
}