using UnityEngine;
using System.Collections;

public class BoardGenerator : MonoBehaviour {


    public int gridDepth = 5;
    public int gridWidth = 9;
    public GameObject TilePrefab;
    public GameObject HeroPrefab;
    public Transform BoardManager;

	// Use this for initialization
	void Start () {

        CreateGrid();
        SpawnHero(new Vector2(1, 1));
	}
	
	// Update is called once per frame
	void Update () {
	
	}


    void CreateGrid()
    {

        for (int x = 0; x <= gridWidth; x++)
        {
            for(int z = 0; z <= gridDepth; z++)
            {
                var obj = Instantiate(TilePrefab, new Vector3(x,0,z), Quaternion.AngleAxis(90,Vector3.right)) as GameObject;
                obj.transform.SetParent(BoardManager);
                
            }
        }

    }
    void SpawnHero(Vector2 position)
    {
        Instantiate(HeroPrefab, new Vector3(position.x, 0, position.y), Quaternion.AngleAxis(90, Vector3.right));
    }
}
