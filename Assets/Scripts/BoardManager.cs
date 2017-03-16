using UnityEngine;
using System.Collections.Generic;

public class BoardManager : MonoBehaviour {

    public static BoardManager Instance { get; set; }

    private Vector2 _gridSize = new Vector2(9,5);

    public Transform TilePrefab;

    public Transform Parent;
    public Transform UnitManager;
    
    public List<GameObject> TileObjects { get; set; }
	// Use this for initialization
	void Start ()
	{

	    Instance = this;
	    TileObjects = new List<GameObject>();
        CreateGrid();
        
	}

    private void CreateGrid()
    {

        for (int x = 0; x <= _gridSize.x; x++)
        {
            for(int z = 0; z <= _gridSize.y; z++)
            {
               Transform tile = Instantiate(TilePrefab, new Vector3(x + 0.5f, 0, z + 0.5f), Quaternion.Euler(Vector3.right*90)) as Transform;
               tile.localScale = Vector3.one*(1 - 0.1f);
               tile.transform.SetParent(Parent);
            }
        }

    }
    
}
