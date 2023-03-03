using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceManager 
{
    public T Load<T>(string path) where T : Object
    {
        return Resources.Load<T>(path);
    }
    public GameObject Instantiate(string path,Transform parent = null)
    {
        GameObject TankPrefab = Load<GameObject>($"Prefabs/{path}");
        if(TankPrefab == null)
        {
            Debug.Log("��ũ�� ã���������ϴ�");
            return null;
        }

        return Object.Instantiate(TankPrefab, parent);
    }
    public void Destroy(GameObject go)
    {
        if(go == null)
        {
            return;
        }
        Object.Destroy(go);

    }
}
