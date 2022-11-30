using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class SpawnManager : MonoBehaviour
{
    [Range(0, 50)]
    [SerializeField] private int initialSpawn;
    [SerializeField] private Vector2 cubeSpawnTimeRange;
    [SerializeField] private List<GameObject> collectablePrefabs;
    [SerializeField] private List<GameObject> nonCollectablePrefabs;
    [SerializeField] private Transform spawnArea;
    private List<GameObject> pool;

    private Player player;

    public static SpawnManager Instance;

    public void SpawnCollectable()
    {
        Vector3 position = Vector3.zero;
        var selectedPrefab = collectablePrefabs[Random.Range(0, collectablePrefabs.Count)];
        GetRandomSpawnPosition(ref position, selectedPrefab.transform.lossyScale.y / 2);
        while (Vector3.Distance(position, player.transform.position) < 1.5f)
            GetRandomSpawnPosition(ref position, selectedPrefab.transform.lossyScale.y / 2);
        Instantiate(selectedPrefab, position, Quaternion.identity);
    }
    
    public void SpawnNonCollectable()
    {
        Vector3 position = Vector3.zero;
        var selectedPrefab = nonCollectablePrefabs[Random.Range(0, nonCollectablePrefabs.Count)];
        GetRandomSpawnPosition(ref position, selectedPrefab.transform.lossyScale.y / 2);
        while (Vector3.Distance(position, player.transform.position) < 1.5f)
            GetRandomSpawnPosition(ref position, selectedPrefab.transform.lossyScale.y / 2);
        Instantiate(selectedPrefab, position, Quaternion.identity);
    }

    private void GetRandomSpawnPosition(ref Vector3 position, float y)
    {
        position = new Vector3(Random.Range(-spawnArea.lossyScale.x / 2, spawnArea.lossyScale.x / 2), y,
            Random.Range(-spawnArea.lossyScale.z / 2, spawnArea.lossyScale.z / 2));
    }

    private void Awake()
    {
        Instance = this;
    }

    private IEnumerator SpawnCubes()
    {
        yield return new WaitForSeconds(Random.Range(cubeSpawnTimeRange.x, cubeSpawnTimeRange.y));
        SpawnNonCollectable();
        StartCoroutine(SpawnCubes());
    }

    // Start is called before the first frame update
    private void Start()
    {
        player = FindObjectOfType<Player>();
        for (int i = 0; i < initialSpawn; i++)
            SpawnCollectable();
        StartCoroutine(SpawnCubes());
    }
}