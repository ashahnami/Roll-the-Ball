using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{


    public DebugMode debugMode = DebugMode.Normal;
    private LineRenderer lineRenderer;
    public Transform player;
    public float detectionRadius = 20f; 


    void Start(){
        lineRenderer = gameObject.AddComponent<LineRenderer>();
        GameObject[] pickups = GameObject.FindGameObjectsWithTag("PickUp");
    }

    void FixedUpdate(){
        GameObject closestPickup = FindClosestActivePickup();

        GameObject[] pickups = GameObject.FindGameObjectsWithTag("PickUp");
        for(int i=0; i<pickups.Length; i++)
        {
            pickups[i].GetComponent<Renderer>().material.color = Color.white;
        }
        closestPickup.GetComponent<Renderer>().material.color = Color.blue;


        if (closestPickup != null){
            lineRenderer.SetPosition(0, player.position);
            lineRenderer.SetPosition(1, closestPickup.transform.position);
        }
        else{
            lineRenderer.enabled = false;
        }
    }

    void SwitchDebugMode(){
        switch (debugMode){
            case DebugMode.Normal:
                debugMode = DebugMode.Distance;
                break;
            case DebugMode.Distance:
                debugMode = DebugMode.Vision;
                break;
            case DebugMode.Vision:
                debugMode = DebugMode.Normal;
                break;
        }
    }

    GameObject FindClosestActivePickup(){
        GameObject[] pickups = GameObject.FindGameObjectsWithTag("PickUp");
        GameObject closest = null;
        float minDistance = Mathf.Infinity;

        foreach (GameObject pickup in pickups){
            if (!pickup.activeInHierarchy) continue;
            float distance = Vector3.Distance(player.position, pickup.transform.position);
            if (distance < minDistance && distance <= detectionRadius){
                closest = pickup;
                minDistance = distance;
            }
        }

        return closest;
    }
}
