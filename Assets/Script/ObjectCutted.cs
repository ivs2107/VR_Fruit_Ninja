using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectCutted : MonoBehaviour {

	// Use this for initialization
	void Start () {
		StartCoroutine("RemoveObject");
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	IEnumerator RemoveObject()
    {
		yield return new WaitForSeconds(5);
		Destroy(this.gameObject);
    }

}
