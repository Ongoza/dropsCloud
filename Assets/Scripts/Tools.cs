using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Tools 
{
    public static GameObject CreateDrop(string name, Transform parent, Vector3 pos){
        // Debug.Log("cube_"+ name);
        GameObject obj = GameObject.CreatePrimitive(PrimitiveType.Cube);
        obj.name = name;
        if(pos != null){obj.transform.position = pos;}
        if(parent != null){obj.transform.parent = parent;}
        // cube.transform.position = new Vector3(0, 0.5f, 0);
        return obj;
    }
}
