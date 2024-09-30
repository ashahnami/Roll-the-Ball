using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    private LineRenderer lineRenderer;
    public GameObject[] pickups;
    // Start is called before the first frame update
    void Start()
    {
        lineRenderer = gameObject.AddComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        for(int i=0; i<pickups.Length; i++) {
            pickups[i].GetComponent<Renderer>().material.color = Color.blue;
        }
    }
}
