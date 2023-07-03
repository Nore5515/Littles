using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System;

public class PlayerHandler : MonoBehaviour
{
    public GameObject littleInstance;
    public GameObject respawnPoint;
    public List<GameObject> currentFollowingLittles = new List<GameObject>();
    public List<GameObject> emptiedSpawners = new List<GameObject>();

    public TarodevController.PlayerController playerController;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.J))
        {
            Debug.Log("J");
            // CreateLittle();
            // Knockback();
        }
    }

    void Knockback()
    {
        playerController.Velocity += new Vector3(0.0f, 50000.0f, 0.0f);
    }

    void CreateLittle()
    {
        GameObject littleFollower = GameObject.Instantiate(littleInstance, this.transform.position, this.transform.rotation);
        if (currentFollowingLittles.Count == 0)
        {
            littleFollower.GetComponent<LittleFollower>().followTarget = this.gameObject;
        }
        else
        {
            littleFollower.GetComponent<LittleFollower>().followTarget = currentFollowingLittles[currentFollowingLittles.Count - 1];
        }
        currentFollowingLittles.Add(littleFollower);
    }

    void DestroyAllLittles()
    {
        foreach (var little in currentFollowingLittles)
        {
            little.GetComponent<LittleFollower>().SelfDestruct();
        }
    }

    public void HitHazard()
    {
        Respawn();
    }

    void Respawn()
    {
        this.transform.position = respawnPoint.transform.position;
        DestroyAllLittles();
        currentFollowingLittles = new List<GameObject>();
        foreach (var spawner in emptiedSpawners)
        {
            spawner.GetComponent<LittleSpawnerHandler>().RefillSpawner();
        }
        emptiedSpawners = new List<GameObject>();
    }

    public void HitSpawner(GameObject spawner)
    {
        while (spawner.GetComponent<LittleSpawnerHandler>().spawnerCount > 0)
        {
            spawner.GetComponent<LittleSpawnerHandler>().spawnerCount -= 1;
            CreateLittle();
        }
        spawner.GetComponent<LittleSpawnerHandler>().EmptySpawner();
        emptiedSpawners.Add(spawner);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("HELP");
        if (other.gameObject.tag == "Hazard")
        {
            HitHazard();
        }
        if (other.gameObject.tag == "Spawner")
        {
            Debug.Log("HELP");
            HitSpawner(other.gameObject);
        }
    }
}
