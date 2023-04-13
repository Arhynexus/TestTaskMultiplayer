using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawner : MonoBehaviour
{
    [SerializeField] private GameObject m_PlayerPrefab;

    [SerializeField] private float StartSpawnPositionMinX, StartSpawnPositionMinY, StartSpawnPositionMaxX, StartSpawnPositionMaxY;
    private void Start()
    {
        Vector2 startPosition = new Vector2(Random.Range(StartSpawnPositionMinX, StartSpawnPositionMaxX ), Random.Range(StartSpawnPositionMinY, StartSpawnPositionMaxY));
        PhotonNetwork.Instantiate(m_PlayerPrefab.name, startPosition, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
