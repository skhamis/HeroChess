using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    public GameObject SelectedUnit;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                var x = (int) hit.collider.transform.position.x;
                var z = (int) hit.collider.transform.position.z;

                if (hit.collider.CompareTag("PlayerUnit"))
                {
                    SelectedUnit = hit.collider.gameObject;
                    UnitManager.Instance.SelectUnit(x,z, SelectedUnit);
                    Debug.Log("Player Unit was selected");
                }
                else
                {
                    if (SelectedUnit == null)
                        return;
                    //Keep the Y as is but move the x/z accordingly
                    //switch (hit.collider.CompareTag("Floor"))
                    switch (hit.collider.tag)
                    {
                        case "EnemyUnit":
                            Debug.Log("Hit enemy");
                            break;
                        default:
                            UnitManager.Instance.MoveUnit(x, z);
                            break;

                    }
                }
            }
        }
	
	}
}
