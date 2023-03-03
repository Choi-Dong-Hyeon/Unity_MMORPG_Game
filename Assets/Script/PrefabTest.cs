using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefabTest : MonoBehaviour
{

    GameObject tank;
    void Start()
    {

        tank = Managers.resource.Instantiate("Tank");
        //Managers.resource.Destroy(tank);
        Destroy(tank,2f);
        
    }


}
