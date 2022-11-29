using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> prefabs;
    [SerializeField] private Transform spawnArea;
    private List<GameObject> pool;

    private Player player;

    public static SpawnManager Instance;

    public void SpawnObject()
    {
        Vector3 position = Vector3.zero;
        var selectedPrefab = prefabs[Random.Range(0, prefabs.Count)];
        GetRandomSpawnPosition(ref position, selectedPrefab.transform.lossyScale.y / 2);
        while (Vector3.Distance(position, player.transform.position) < 1)
            GetRandomSpawnPosition(ref position, selectedPrefab.transform.lossyScale.y / 2);
        Instantiate(selectedPrefab, position, Quaternion.identity);
    }

    void GetRandomSpawnPosition(ref Vector3 position, float y)
    {
        position = new Vector3(Random.Range(-spawnArea.lossyScale.x / 2, spawnArea.lossyScale.x / 2), y,
            Random.Range(-spawnArea.lossyScale.z / 2, spawnArea.lossyScale.z / 2));
    }

    private void Awake()
    {
        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<Player>();
    }
}