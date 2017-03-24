using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public class BoardHighlights : MonoBehaviour
{
    public static BoardHighlights Instance { get; set; }

    public GameObject HighlightPrefab;
    public GameObject AttackPrefab;

    private List<GameObject> _highlights;

    private void Start()
    {
        Instance = this;
        _highlights = new List<GameObject>();
    }

    private GameObject GetHighlightedMoveObject()
    {
        GameObject go = _highlights.Find(x => !x.activeSelf && x == HighlightPrefab);

        if (go == null)
        {
            go = Instantiate(HighlightPrefab);
            _highlights.Add(go);
        }

        return go;
    }

    private GameObject GetHighlightedAttackObject()
    {
        GameObject go = _highlights.Find(x => !x.activeSelf && x == AttackPrefab);

        if (go == null)
        {
            go = Instantiate(AttackPrefab);
            _highlights.Add(go);
        }

        return go;
    }

    public void HighlightAllowedActions(bool[,] moves)
    {
        for (int i = 0; i < Constants.GridSize.x; i++)
        {
            for (int j = 0; j < Constants.GridSize.y; j++)
            {
                if (moves[i, j])
                {
                    GameObject go;
                    if(UnitManager.Instance.MoveableUnits[i,j] != null)
                    {
                        if(UnitManager.Instance.MoveableUnits[i, j].tag == Constants.EnemyUnitTag)
                        {
                            go = GetHighlightedAttackObject();
                            go.SetActive(true);
                            go.transform.position = new Vector3(i + 0.5f, 0.001f, j + 0.5f);
                            go.transform.localScale = Vector3.one * (1 - 0.1f);
                            go.transform.SetParent(BoardManager.Instance.Parent);
                        }
                    }
                    else
                    {
                        go = GetHighlightedMoveObject();
                        go.SetActive(true);
                        go.transform.position = new Vector3(i + 0.5f, 0.001f, j + 0.5f);
                        go.transform.localScale = Vector3.one * (1 - 0.1f);
                        go.transform.SetParent(BoardManager.Instance.Parent);
                    }
                    
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
