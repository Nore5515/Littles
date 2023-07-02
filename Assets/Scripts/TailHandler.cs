using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TailHandler : MonoBehaviour
{
    public GameObject objectToTail;
    Vector3 targetPosition;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        targetPosition = objectToTail.transform.position;
        targetPosition += new Vector3(1.0f, 1.0f, 1.0f);
        FollowTarget();
    }


    void FollowTarget()
    {
        this.transform.position = Vector3.Lerp(this.transform.position, targetPosition, Time.deltaTime * 4);
    }
}
