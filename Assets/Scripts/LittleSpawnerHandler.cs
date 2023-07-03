using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LittleSpawnerHandler : MonoBehaviour
{
    int maxSpawnerCount = 5;
    public int spawnerCount = 5;
    public Animator spawnerAnim;


    void Start()
    {
        maxSpawnerCount = spawnerCount;
        spawnerAnim.Play("full");
    }

    public void EmptySpawner()
    {
        spawnerCount = 0;
        spawnerAnim.Play("empty");
    }

    public void RefillSpawner()
    {
        spawnerCount = maxSpawnerCount;
        spawnerAnim.Play("full");
    }
}
