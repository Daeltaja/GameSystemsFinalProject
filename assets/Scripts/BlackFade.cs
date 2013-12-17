using UnityEngine;
using System.Collections;

public class BlackFade : MonoBehaviour {

	Color color;
	public static bool fadeIn = true;

	void Awake()
	{
		fadeIn = true;
	}

	void Update()
	{
		if(fadeIn)
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
}
