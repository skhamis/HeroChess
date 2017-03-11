using UnityEngine;
using System.Collections.Generic;

public class BoardHighlights : MonoBehaviour
{
    public static BoardHighlights Instance { get; set; }

    public GameObject HighlightPrefab;

    private List<GameObject> _highlights;

    private void Start()
    {
        Instance = this;
        _highlights = new List<GameObject>();
    }

    private GameObject GetHighlightedObject()
    {
        GameObject go = _highlights.Find(x => !x.activeSelf);

        if (go == null)
        {
            go = Instantiate(HighlightPrefab);
            _highlights.Add(go);
        }

        return go;
    }

    public void HighlightAllowedMoves(bool[,] moves)
    {
        for (int i = 0; i < 9; i++)
        {
            for (int j = 0; j < 5; j++)
            {
                if (moves[i, j])
                {
                    GameObject go = GetHighlightedObject();
                    go.SetActive(true);
                    go.transform.position = new Vector3(i,1,j);
                    go.transform.SetParent(BoardManager.Instance.Parent);
                }
            }

        }
    }

    public void HideHighlights()
    {
        foreach (var go in _highlights)
        {
            go.SetActive(false);
        }
    }
}
