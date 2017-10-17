using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

    public GameObject[] enemies;
    public Vector3 spawnValues;
    public float spawnWait;
    public float spawnMostWait;
    public float spawnLeastWait;
    public int startWait;
    public bool stop;
	public float killTime;
	private GameObject clones;
	public float speed;

    int randEnemy;

	void Start () {
        StartCoroutine(waitSpawner());

	}
	

	void Update () {
        spawnWait = Random.RandomRange(spawnLeastWait, spawnMostWait);
	}

    IEnumerator waitSpawner()
    {
        yield return new WaitForSeconds(startWait);

        while (!stop)
        {
            randEnemy = Random.Range(0, 7);

			Vector3 spawnPosition = new Vector3(Random.Range (-spawnValues.x, spawnValues.x), Random.Range(-spawnValues.y, spawnValues.y), Random.Range(-spawnValues.z, spawnValues.z));

			clones = Instantiate(enemies[randEnemy], spawnPosition + transform.TransformPoint(0, 0, 0), gameObject.transform.rotation);

            yield return new WaitForSeconds(spawnWait);

			Destroy (clones, killTime);

        }

	

    }
}
