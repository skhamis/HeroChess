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

        MoveableUnits = new MoveableUnit[9,5];

        SpawnHero(UnitType.Sentinel, 1, 1);
        SpawnHero(UnitType.Mage, 4, 3);
        SpawnHero(UnitType.Cleric, 5, 4);
        SpawnHero(UnitType.Trapper, 7, 4);
    }
	


    private void SpawnHero(UnitType unitType, int x, int z)
    {

        var obj = Instantiate(UnitPrefabs[(int)unitType], new Vector3(x, 1, z), Quaternion.identity) as GameObject;

        MoveableUnits[x, z] = obj.GetComponent<MoveableUnit>();
        MoveableUnits[x,z].SetPosition(x,z);
        obj.transform.SetParent(Parent);
    }

    public void SelectUnit(int x, int z, GameObject unitObj)
    {
        if (MoveableUnits[x, z] == null)
        {
            return;
        }
        //Hide any existing highlights
        BoardHighlights.Instance.HideHighlights();

        //If not the players turn

        //Get Allowed moves
        allowedMoves = MoveableUnits[x, z].PossibleMove();

        //select unit
        selectedUnit = MoveableUnits[x, z];
        _selectedUnitObj = unitObj;

        BoardHighlights.Instance.HighlightAllowedMoves(allowedMoves);
    }

    public void MoveUnit(int x, int z)
    {
        if (allowedMoves[x, z])
        {
            _selectedUnitObj.transform.position
                = new Vector3(x, _selectedUnitObj.transform.position.y, z);

           
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


