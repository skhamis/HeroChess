using UnityEngine;

public class GameManager : MonoBehaviour {

    public static GameManager Instance { get; set; }

    private BoardManager BoardManager;
    private UnitManager UnitManager;
    private PlayerManager PlayerManager;

    private void Start()
    {
        Instance = this;
    }

    public void SavePlayerData()
    {
        GameSparksManager.Instance.SavePlayerData(100, new Vector3(2, 0, 4).ToString(), 500);
    }

    public void LoadPlayerData()
    {
        GameSparksManager.Instance.LoadPlayerData();
    }

    public void HighlightBoardInformation(bool[,] allowedMoves)
    {
        //Hide any existing highlights
        BoardHighlights.Instance.HideHighlights();

        //Show where the unit can move
        BoardHighlights.Instance.HighlightAllowedActions(allowedMoves);
    }
}
