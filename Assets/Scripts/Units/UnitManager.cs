using UnityEngine;
using System.Collections.Generic;

public class UnitManager : MonoBehaviour {

    public static UnitManager Instance { get; set; }
    
    
    public MoveableUnit[,] MoveableUnits { get; set; }

    public List<GameObject> UnitPrefabs;

    private MoveableUnit selectedUnit;
    private GameObject _selectedUnitObj;

    private bool[,] allowedMoves { get; set; }

    public enum UnitType
    {
        Sentinel, Mage, Cleric, Trapper
    }

    public Transform Parent;
    
    // Use this for initialization
    private void Start ()
    {
        Instance = this;

        MoveableUnits = new MoveableUnit[(int)Constants.GridSize.x,(int)Constants.GridSize.y];

        //Spawn players heroes
        SpawnHero(UnitType.Sentinel, 1,1);
        SpawnHero(UnitType.Mage, 1,2);
        SpawnHero(UnitType.Cleric, 1,4);
        SpawnHero(UnitType.Trapper, 1,5);

        //Spawn enemies heroes
        SpawnHero(UnitType.Sentinel, 9, 1, isEnemy: true);
        SpawnHero(UnitType.Mage, 9, 2, isEnemy: true);
        SpawnHero(UnitType.Cleric, 9, 4, isEnemy: true);
        SpawnHero(UnitType.Trapper, 9, 5, isEnemy: true);
    }

    private void SpawnHero(UnitType unitType, int x, int y, bool isEnemy = false)
    {

        var obj = Instantiate(UnitPrefabs[(int)unitType], new Vector3(x + 0.5f, 0, y + 0.5f), Quaternion.identity) as GameObject;

        obj.tag = isEnemy ? Constants.EnemyUnitTag : Constants.PlayerUnitTag;
        MoveableUnits[x, y] = obj.GetComponent<MoveableUnit>();
        MoveableUnits[x, y].SetPosition(x, y);
        obj.transform.SetParent(Parent);

    }

    public void SelectUnit(int x, int z, GameObject unitObj)
    {
        if (MoveableUnits[x, z] == null)
        {
            return;
        }
        

        //If not the players turn

        //Get Allowed moves
        allowedMoves = MoveableUnits[x, z].PossibleActions();

        //select unit
        selectedUnit = MoveableUnits[x, z];
        _selectedUnitObj = unitObj;

        GameManager.Instance.HighlightBoardInformation(allowedMoves);
        
    }

    public void MoveUnit(int x, int z)
    {
        if (allowedMoves[x, z])
        {
            _selectedUnitObj.transform.position
                = new Vector3(x + 0.5f, 0, z + 0.5f);

           
            //Remove the obj from the prev position
            MoveableUnits[selectedUnit.CurrentX, selectedUnit.CurrentZ] = null;

            //update the units position
            selectedUnit.SetPosition(x,z);
            
            //Add the obj to the new position
            MoveableUnits[x, z] = selectedUnit.GetComponent<MoveableUnit>();


        }
        
        _selectedUnitObj = null;
        selectedUnit = null;
        BoardHighlights.Instance.HideHighlights();
        
    }

    public void AttackEnemy(int x, int z)
    {
        if (selectedUnit.EnemyInAttackRange(x,z))
        {
            selectedUnit.Attack();
        }
    }





}


