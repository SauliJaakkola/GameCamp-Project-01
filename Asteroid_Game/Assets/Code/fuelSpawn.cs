using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fuelSpawn : MonoBehaviour {

    public GameObject fuel;

    public Vector2 center;
    public Vector2 size;
    public float timer;

    void Start()
    {
        InvokeRepeating ("Spawn", timer, timer);
    }

    private void Spawn()
    {
        Vector2 pos = center + new Vector2(Random.Range(-size.x / 2, size.x / 2), Random.Range(-size.y / 2, size.y / 2));
        Instantiate(fuel, pos, Quaternion.identity);
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = new Color(1, 0, 0, 0.5f);
        Gizmos.DrawCube(center, size);
    }
}
