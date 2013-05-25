using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {
	
	public GameObject clone;
	
	Vector3 start = new Vector3(400.0f, 0.0f, 0.0f);
	
	float spawnTime = 3;
	float timer = 0;
	
	void Update () {
		timer += Time.deltaTime;
		if (timer > spawnTime)
		{
			start.y = Random.Range(-140, 140);
			Instantiate(clone, start, transform.rotation);
			timer = 0;
		}
	
	}
}