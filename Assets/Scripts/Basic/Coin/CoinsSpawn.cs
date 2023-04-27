using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinsSpawn : MonoBehaviour
{
    [SerializeField] private List<Transform> _spawnPoints;
    [SerializeField] private Coin[] _coin;

    private void Start()
    {
        _spawnPoints= new List<Transform>(_spawnPoints);
        SpawnCoins();
    }

    private void SpawnCoins()
    {
        for (int i = 0; i < _coin.Length; i++)
        {
            var spawn = Random.Range(0, _spawnPoints.Count);
            Instantiate(_coin[i], _spawnPoints[spawn].transform.position, Quaternion.identity);
            _spawnPoints.RemoveAt(spawn);
        }
    }
}