using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GridController : MonoBehaviour {

	public GameObject tilePrefab;
	public int gridSizeX;
	public int gridSizeZ;

	private List<GameObject> tiles;

	// Use this for initialization
	void Start () {
		tiles = new List<GameObject>();

		for (int i = 0; i < gridSizeX; i++) {
			for (int j = 0; j < gridSizeZ; j++) {
				GameObject tile = (GameObject) Instantiate(tilePrefab);
				tile.transform.parent = transform;
				tile.transform.localPosition = new Vector3(i, 0, j);

				FallAfterTime fallScript = tile.GetComponent<FallAfterTime>();
				fallScript.timeToFallAfter = Random.Range(2.0f,10.0f);

				tiles.Add(tile);
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
