using UnityEngine;
using System.Collections;

public class BoardManager : MonoBehaviour {

    public static BoardManager Instance { get; set; }

    private const int GRID_DEPTH = 5;
    private const int GRID_WIDTH = 9;

    public GameObject TilePrefab;

    public Transform Parent;
    public Transform UnitManager;
    

	// Use this for initialization
	void Start ()
	{

	    Instance = this;
        CreateGrid();
        
	}
	
	// Update is called once per frame
	void Update () {
	
	}


    private void CreateGrid()
    {

        for (int x = 0; x <= GRID_WIDTH; x++)
        {
            for(int z = 0; z <= GRID_DEPTH; z++)
            {
               var obj = Instantiate(TilePrefab, new Vector3(x,0,z), Quaternion.identity) as GameObject;
                if (obj != null) obj.transform.SetParent(Parent);
            }
        }

    }
    
}
