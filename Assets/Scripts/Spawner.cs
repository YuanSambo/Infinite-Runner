using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject coins;
    public Transform position;


    private void Start()
    {
        StartCoroutine(SpawnCoroutine());
    }


    private IEnumerator SpawnCoroutine()
    {
        while (true)
        {
            Instantiate(coins, position.position, quaternion.identity);
            yield return new WaitForSeconds(3f);
        }
       
    }



}
