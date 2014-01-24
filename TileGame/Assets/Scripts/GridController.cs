using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GridController : MonoBehaviour
{
    public GameObject tilePrefab;
    public GameObject tile2Prefab;
    public int gridSizeX;
    public int gridSizeZ;
    private List<List<GameObject>> tiles;

    // Use this for initialization
    void Start ()
    {

    }

    public void StartGame ()
    {
        CreateGrid ();
    }

    void CreateGrid ()
    {
        tiles = new List<List<GameObject>> ();
        
        // Pick a random tile to not fall
        int randX = Random.Range (0, gridSizeX - 1);
        int randZ = Random.Range (0, gridSizeZ - 1);

        for (int i = 0; i < gridSizeX; i++) {
            List<GameObject> tileRow = new List<GameObject> ();

            for (int j = 0; j < gridSizeZ; j++) {
                GameObject tile;
                if (i == randX && j == randZ) {
                    tile = (GameObject)Instantiate (tile2Prefab);
                } else {
                    tile = (GameObject)Instantiate (tilePrefab);
                }

                tile.transform.parent = transform;
                tile.transform.localPosition = new Vector3 (i, 0, j);
                tileRow.Add (tile);
            }

            tiles.Add (tileRow);
        }
    }

    // Update is called once per frame
    void Update ()
    {

    }

    public bool HasTileFallen (int xIndex, int zIndex)
    {
        if (xIndex < 0 || xIndex >= tiles.Count) {
            return true;
        }
        if (zIndex < 0 || zIndex >= tiles [xIndex].Count) {
            return true;
        }

        GameObject tile = tiles [xIndex] [zIndex];
        FallAfterTime fallScript = tile.GetComponent<FallAfterTime> ();
        return fallScript.hasFallen;
    }
}
