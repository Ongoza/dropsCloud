// В центре капля. 
// Количество в круге зависит от радиуса и шага. 
// Максимальный слой состоит из 5 кругов. 
// Количество элементов в каждом круге зависит от его номера. 
// Ширина нового слоя отражается на земле в виде диска. 
// Диск расположен на расстоянии максимального радиуса.
// Все слои слегка выпуклые по центру. 
// Цвет зависит от количества кругов в слое. Чем кругов больше тем насыщенее.
// Размер объекта Размер шага Максимальный радиус Максимальная высота.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainScript : MonoBehaviour
{
    
    public DropsLayer _drops;
    private Text fpsText;
    public float timer, refresh, avgFramerate;
    public string nameScript = "MainScript";
    // Start is called before the first frame update
    void Start()
    {
        _drops = new DropsLayer("CloudDrops");
        GameObject obj = GameObject.Find("FPS");
        if(obj != null){
            fpsText = obj.GetComponent<Text>();
            fpsText.text = "";
        }else{fpsText = null;}
        // GameObject objDrop = new GameObject("RootDrops");
        // _dropsRoot = objDrop.transform;
        // GameObject obj2 = Tools.CreateDrop("d1", _dropsRoot, new Vector3(0, 1, 2));
        // _drops.Add(obj2);

        // if(obj){
        //     // Debug.Log(obj.name);
        //     // LHandFollow lHand = obj.GetComponent<LHandFollow>();
        //     // Debug.Log("Drops: "+lHand.dropStep.ToString());
        //     // Destroy(lHand);
        // }else{
        //     Debug.Log("Can not find");
        // }
    }

    // Update is called once per frame
    void Update(){
        if (fpsText != null){
            float timelapse = Time.smoothDeltaTime;
            timer = timer <= 0 ? refresh : timer -= timelapse;
            if(timer <= 0) avgFramerate = (int) (1f / timelapse);
            fpsText.text = avgFramerate.ToString();
        }
    }


}
