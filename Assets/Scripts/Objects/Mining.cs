using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mining : Interactable {

    public int caseIndex;

    public int rockHealth = 5;

    public GameObject rockBitPrefab;
    public int rockBitAmt = 5;


    public override void handleClickSuccess()
    {
        if (_player.GetComponent<FirstPersonController>().IAmMining == false)
        {
            base.handleClickSuccess();
            _player.GetComponent<FirstPersonController>().PlayMine();
            rockHealth--;
        }
    }

    void Update()
    {
        if(rockHealth < 0)
        {
            SpawnRockBits();
            Destroy(gameObject);
        }
    }

    void SpawnRockBits()
    {
        for(int i = 0; i<rockBitAmt; i++)
        {
            Vector3 xyz = Random.insideUnitSphere * 3;
            Vector3 spawnPosition = xyz + transform.position;
            Instantiate(rockBitPrefab, spawnPosition, Quaternion.Euler(0, Random.Range(0, 90f), 0));
        }
    }
}
