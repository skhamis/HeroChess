using UnityEngine;
using System.Collections.Generic;

public class BoardManager : MonoBehaviour {

    private const float TILE_OFFSET = 0.5f;
    private const float TILE_SIZE = 1f;

    private int selectionX, selectionZ = -1;

    public List<GameObject> heroPrefabs;
    private List<GameObject> activeHeroes = new List<GameObject>();


    void Start()
    {
        SpawnHero(0, GetTileCenter(4, 0));
    }
	// Update is called once per frame
	void Update () {

        UpdateSelection();
        DrawChessboard();
	}

    private void UpdateSelection()
    {
        if (!Camera.main)
        {
            return;
        }

        RaycastHit hit;
        if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 25.0f, LayerMask.GetMask("ChessPlane")))
        {
            selectionX = (int) hit.point.x;
            selectionZ = (int) hit.point.z;
        }
        else
        {
            selectionX = -1;
            selectionZ = -1;
        }
    }

    private void SpawnHero(int index, Vector3 position)
    {
        //something went wrong
        if (heroPrefabs.Count < index || index < 0) return;

        var hero = Instantiate(heroPrefabs[index], position, Quaternion.identity) as GameObject;
        hero.transform.SetParent(transform);

        activeHeroes.Add(hero);
        
    }

    private void DrawChessboard()
    {
        Vector3 widthLine = Vector3.right * 9;
        Vector3 heightLine = Vector3.forward * 5;

        //Draw the grid height
        for (int i = 0; i <= 5; i++)
        {
            Vector3 start = Vector3.forward * i;
            Debug.DrawLine(start, start + widthLine);

            //Draw the grid width
            for (int j = 0; j <= 9; j++)
            {
                start = Vector3.right * j;
                Debug.DrawLine(start, start + heightLine);
            }
        }

        //Draw the selection
        if(selectionX >= 0 && selectionZ >= 0)
        {
            Debug.DrawLine(
                Vector3.forward * selectionZ + Vector3.right * selectionX,
                Vector3.forward * (selectionZ + 1) + Vector3.right * (selectionX + 1)
                );
            Debug.DrawLine(
                Vector3.forward * (selectionZ + 1) + Vector3.right * selectionX,
                Vector3.forward * selectionZ + Vector3.right * (selectionX + 1)
                );
        }

    }

    private Vector3 GetTileCenter(int x, int y)
    {
        Vector3 origin = Vector3.zero;
        origin.x += (TILE_SIZE * x) + TILE_OFFSET;
        origin.z += (TILE_SIZE * y) + TILE_OFFSET;

        return origin;
    }
}
