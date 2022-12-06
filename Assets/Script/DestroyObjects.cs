using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObjects : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

	}

    //Detect collisions between the GameObjects with Colliders attached
    void OnCollisionEnter(Collision collision)
    {
        //Check for a match with the specified name on any GameObject that collides with your GameObject
        if (collision.gameObject.tag == "Fruit")
        {
            //If the GameObject's name matches the one you suggest, remov eone life
            GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>().RemoveLife();
        }
        Destroy(collision.gameObject);
    }
}
