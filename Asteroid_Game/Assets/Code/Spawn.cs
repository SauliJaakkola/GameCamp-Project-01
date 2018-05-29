using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour {


    public GameObject asteroid;

    public Vector2 center;
    public Vector2 size;

	void Start () {
        int enemyCount = Random.Range(5,10);

        for (int i = 0; i <= enemyCount; i++)
        {
            Vector2 pos = center + new Vector2(Random.Range(-size.x / 2, size.x / 2),Random.Range(-size.y / 2, size.y / 2));
            Instantiate(asteroid, pos, Quaternion.identity);
        }
	}
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = new Color(1, 0, 0, 0.5f);
        Gizmos.DrawCube(center, size);
    }
}
