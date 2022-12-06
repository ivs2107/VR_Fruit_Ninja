using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

	private int life = 3;
	// Use this for initialization
	public List<GameObject> lifesObjects;


	private static float timer;
	private static bool timeStarted = true;

	public Text chronometer;
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (timeStarted == true)
		{
			timer += Time.deltaTime;
			int minutes = Mathf.FloorToInt(timer / 60F);
			int seconds = Mathf.FloorToInt(timer - minutes * 60);
			string timeText = string.Format("{0:00}:{1:00}", minutes, seconds);
			chronometer.text = timeText;
		}
	}

	public void RemoveLife()
    {
		if (life == 1)
		{
			SceneManager.LoadScene(0);
		}
		else
		{
			Destroy(lifesObjects[0]);
			lifesObjects.RemoveAt(0);
			life -= 1;
		}
		
	}
}
