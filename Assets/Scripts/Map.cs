using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour
{
    [SerializeField] private SpawnerNPC _spawnerNPC;
    [SerializeField] private List<Start> _startPositions;

    private float _repeatRate = 2.0f;
    private float _startTime = 0.0f;

    private void Start()
    {
        InvokeRepeating(nameof(SpawnNPC), _startTime, _repeatRate);
    }

    public Vector3 DefinePosition()
    {
        int randomPoint = Random.Range(0, _startPositions.Count);

        return _startPositions[randomPoint].transform.position;
    }

    private void SpawnNPC()
    {
        _spawnerNPC.GetNPC();
    }
}
