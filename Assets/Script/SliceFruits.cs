using EzySlice;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SliceFruits : MonoBehaviour {

    public Transform cutPlane;
    public LayerMask layerMask;
    public Material crossSectionMaterial;
    public GameObject particleExplosion;


    public GameObject yellowPanel;

    private bool canSlice = true;

    private bool isPanelActive =false;
    public GameObject camera;

    void Start()
    {
        // cutPlane = GameObject.FindGameObjectWithTag("Plane").gameObject.transform;
        //layerMask = LayerMask.GetMask("Cuttable");
        print(cutPlane.transform);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        /*if (canSlice)
        {
            //StartCoroutine(SliceFunction());
           
        }*/
        SliceFunction();
    }

    public void SliceFunction()
    {
        Collider[] hits = Physics.OverlapBox(cutPlane.position, cutPlane.localScale /*new Vector3(0.4f, 1f, 10f)*/, cutPlane.rotation, layerMask);
        if (hits.Length <= 0)
            return;
        // canSlice = false;
        for (int i = 0; i < hits.Length; i++)
        {
            SlicedHull hull = SliceObject(hits[i].gameObject);
            if (hull != null)
            {
                GameObject bottom = hull.CreateLowerHull(hits[i].gameObject, crossSectionMaterial);
                GameObject top = hull.CreateUpperHull(hits[i].gameObject, crossSectionMaterial);
                AddHullComponents(bottom);
                AddHullComponents(top);
                // Debug.Log(hits[i].gameObject.GetComponent<Renderer>().isVisible);
                if(hits[i].gameObject.GetComponent<Renderer>().isVisible && !isPanelActive && hits[i].gameObject.name.Contains("lemon"))
                {
                    StartCoroutine(blurryVision());
                }
                Destroy(hits[i].gameObject);
            }
            if(hits[i].gameObject.tag == "Start")
            {

                GameObject.FindGameObjectWithTag("GameController").SetActive(true);
            }
        }


        canSlice = true;
    }

    public IEnumerator blurryVision()
    {
        isPanelActive = true;
        yellowPanel.SetActive(true);
        yield return new WaitForSeconds(2f);
        yellowPanel.SetActive(false);
        isPanelActive = false;
    }
    public void AddHullComponents(GameObject go)
    {
        go.layer = 9;
        Rigidbody rb = go.AddComponent<Rigidbody>();
        rb.interpolation = RigidbodyInterpolation.Interpolate;
        BoxCollider collider = go.AddComponent<BoxCollider>();
        //  collider.convex = true;
        var gps =Instantiate(particleExplosion, go.transform.position, go.transform.rotation,go.transform);
        gps.SetActive(true);
        rb.AddExplosionForce(100, go.transform.position, 20);
    }

    public SlicedHull SliceObject(GameObject obj, Material crossSectionMaterial = null)
    {
        // slice the provided object using the transforms of this object
        if (obj.GetComponent<MeshFilter>() == null)
            return null;
        return obj.Slice(cutPlane.position, cutPlane.up, crossSectionMaterial);
    }
}
