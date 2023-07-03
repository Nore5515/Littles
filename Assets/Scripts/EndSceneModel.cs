using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndSceneModel : MonoBehaviour
{
    public string nextScene;

    public Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.H))
        {

        }
    }

}
