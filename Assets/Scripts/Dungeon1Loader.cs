using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dungeon1Loader : MonoBehaviour
{
    public GameObject SpawnPoint;
    private GameObject Player;

    // Use this for initialization
    void Start()
    {
        Player = GameObject.Find("#Player");
        Player.transform.position = SpawnPoint.transform.position;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
