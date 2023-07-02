using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class PlayerHandler : MonoBehaviour
{
    public GameObject littleInstance;
    public List<GameObject> currentFollowingLittles = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.J))
        {
            CreateLittle();
        }
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
}
