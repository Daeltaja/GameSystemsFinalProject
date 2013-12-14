using UnityEngine;
using System.Collections;

public class BlackFade : MonoBehaviour {

	Color color;

	void Fade(bool fadeIn)
	{
		if(fadeIn)
		{
			color = renderer.material.color;
			color.a -= 0.5f * Time.deltaTime;
		}
		else
		{
			color = renderer.material.color;
			color.a += 0.5f * Time.deltaTime;
		}
		renderer.material.color = color;
	}
}
