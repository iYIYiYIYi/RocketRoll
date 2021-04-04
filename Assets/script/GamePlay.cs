using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePlay : MonoBehaviour
{
    private Object rocket;
    private GameObject btn;
    
    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 30;
        rocket = Resources.Load("Rocket");
        btn = GameObject.Find("Button");
        btn.transform.localScale = new Vector3(0,0,0);
    }
    
    

    public void respawnRocket()
    {
        btn.transform.localScale = new Vector3(0,0,0);
        GameObject tmp = GameObject.FindGameObjectWithTag("Player");
        var trans = tmp.transform;
        DestroyImmediate(tmp);
        Instantiate(rocket, trans);
    }

}
