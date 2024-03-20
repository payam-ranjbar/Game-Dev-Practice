using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class FlockManager : MonoBehaviour {

    public static FlockManager Instance;
    public GameObject[] fishPrefabs;
    public int numFish = 20;
    public GameObject[] allFish;
    public Vector3 swimLimits = new(5.0f, 5.0f, 5.0f);
    public Vector3 goalPos = Vector3.zero;
    public float avoidanceThreshold = 1.0f;

    [Header("Fish Settings")]
    [Range(0.0f, 5.0f)] public float minSpeed;
    [Range(0.0f, 5.0f)] public float maxSpeed;
    [Range(1.0f, 10.0f)] public float neighbourDistance;
    [Range(1.0f, 5.0f)] public float rotationSpeed;

    void Start() {

        allFish = new GameObject[numFish];

        for (int i = 0; i < numFish; ++i) {

            Vector3 pos = this.transform.position + new Vector3(
                Random.Range(-swimLimits.x, swimLimits.x),
                Random.Range(-swimLimits.y, swimLimits.y),
                Random.Range(-swimLimits.z, swimLimits.z));

            allFish[i] = Instantiate(fishPrefabs.GetRandom(), pos, Quaternion.identity);
        }

        Instance = this;
        goalPos = transform.position;
    }


    void Update() {

        if (Random.Range(0, 100) < 10) {

            goalPos = this.transform.position + new Vector3(
                Random.Range(-swimLimits.x, swimLimits.x),
                Random.Range(-swimLimits.y, swimLimits.y),
                Random.Range(-swimLimits.z, swimLimits.z));
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        
        Gizmos.DrawWireCube(transform.position, swimLimits * 2);
    }
}