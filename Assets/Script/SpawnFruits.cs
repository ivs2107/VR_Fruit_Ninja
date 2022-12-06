using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnFruits : MonoBehaviour
{
    public GameObject prefabFruit;
    public GameObject[] prefabFruits;
    // Start is called before the first frame update
    void Start()
    {
        //Start the coroutine we define below named ExampleCoroutine.
        StartCoroutine(SpawnRandom());

        //InvokeRepeating("SpawnRandom", 2, 5);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator SpawnRandom()
    {
        //Print the time of when the function is first called.
        Debug.Log("Started Coroutine at timestamp : " + Time.time);

        float waiting = 5;
        bool first = true;
        while(true)
        {
            int fruitChoice = Random.Range(0, prefabFruits.Length);
            //yield on a new YieldInstruction that waits for 5 seconds.
            yield return new WaitForSeconds(waiting);
            if (waiting > 1.5f)
            {
                waiting = waiting / Random.Range(1f, 1.5f);
            }
            else if(first && waiting < 1.5f)
            {
                first = false;
                StartCoroutine(SpawnRandom());
            }

            Vector3 position = new Vector3(Random.Range(-0.7f, 0.7f), -4, Random.Range(2.0f, 2.4f));
           
            GameObject fruit = Instantiate(prefabFruits[fruitChoice], position, Quaternion.identity);
            Vector3 f = new Vector3(Random.Range(-10, 10)*10, Random.Range(50, 70)*10, Random.Range(0, 5)*-5);
            fruit.GetComponent<Rigidbody>().AddForce(f, ForceMode.Force);
            //After we have waited 5 seconds print the time again.

        }
        Debug.Log("Finished Coroutine at timestamp : " + Time.time);
    }
}
