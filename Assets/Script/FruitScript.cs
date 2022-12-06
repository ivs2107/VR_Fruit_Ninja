using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		StartCoroutine("RemoveObject");
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	IEnumerator RemoveObject()
	{
		yield return new WaitForSeconds(4);
		GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>().RemoveLife();
		Destroy(this.gameObject);
	}
}
