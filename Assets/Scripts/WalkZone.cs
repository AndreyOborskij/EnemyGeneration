using System;
using UnityEngine;

public class WalkZone : MonoBehaviour
{
    public Action<Enemy> LeftZone;

    private void OnTriggerExit(Collider other)
    {
        Enemy enemy = other.gameObject.GetComponent<Enemy>();

        LeftZone?.Invoke(enemy);
    }
}
