using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainSceneLoader : MonoBehaviour
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
