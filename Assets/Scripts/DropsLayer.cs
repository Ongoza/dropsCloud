using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropsLayer {
    public GameObject _root;
    // public float _stepWidth = 1.5f;
    // public float _stepDeep = 1.5f;
    public List<List<GameObject>> _dropsLayers = new List<List<GameObject>>();
    public int _densitityFirstLayer = 3;
    public int _densitityNextLayerMulty = 2;
    public float _densitityStep = 1.5f;
    public float _densitityDropNoise = 0.4f;
    public Transform _startTransform ;

    // public int _densitityMax = 3;
    // public string name;
    public DropsLayer(string nameStr){
        this._root = new GameObject(nameStr);
        // Debug.Log("Start Cloud");
        // if(pos != null){ _startTransform = pos;}
    }

    public void AddLayer(float width){
        int layers = _dropsLayers.Count;
        List<GameObject> _drops = new List<GameObject>();
        int numLayers = Mathf.FloorToInt(width / _densitityStep);
        if(numLayers > 0){
            // Debug.Log("nums: " + numLayers);
            for (int i = 1; i <= numLayers; i++){
                int dropsNum = _densitityFirstLayer * _densitityNextLayerMulty * i;
                float angle = 2 * Mathf.PI / dropsNum;
                float curRadius = i * _densitityStep;
                for(int j = 0; j < dropsNum; j++){
                    float x = curRadius * Mathf.Cos(angle * j) + Random.Range(0f, _densitityDropNoise);
                    float y = curRadius * Mathf.Sin(angle * j) + Random.Range(0f, _densitityDropNoise);
                    float z =  Random.Range(0f, _densitityDropNoise);
                    _drops.Add(Tools.CreateDrop("d_"+layers.ToString()+"_"+i.ToString()+"_"+j.ToString(), _root.transform, new Vector3(x, z, y)));
                }
            }
        }else{
            _drops.Add(Tools.CreateDrop("d_"+layers.ToString()+"_0", _root.transform, new Vector3(0, 0, 0)));
        }
        _dropsLayers.Add(_drops);
    }

 }
