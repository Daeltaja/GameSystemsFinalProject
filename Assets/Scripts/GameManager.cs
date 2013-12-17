using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	public static bool mainMenu = true;
	GameObject blackFade;
	public GUISkin mySkin;
	public int currLevel;

	void Awake()
	{
		DontDestroyOnLoad(gameObject);
	}

	void Update()
	{

	}

	void OnGUI()
	{
		GUI.skin = mySkin;

		if(mainMenu)
		{
			if(GUI.Button (new Rect(Screen.width/2-130f, Screen.height/2-20.5f, 260f, 41f), ""))
			{
				Application.LoadLevel(1);
				audio.Play();
				mainMenu = false;
			}
		}
	}
}
