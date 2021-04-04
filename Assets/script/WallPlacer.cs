using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallPlacer : MonoBehaviour
{
    //0 -> 左墙
    //1 -> 上墙
    //2 -> 右墙
    //3 -> 下墙
    //4 -> StoneTrigger
    public List<GameObject> Walls;
    public GameObject stars;
    
    void Start()
    {
        Vector3 left = Camera.main.ScreenToWorldPoint(new Vector3(0, Screen.height/2, 10));
        Vector3 up = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width/2, Screen.height, 10));
        Vector3 right = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height/2, 10));
        Vector3 down = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width/2, 0, 10));

        Walls[0].transform.position = left;
        Walls[4].transform.position = left;
        Walls[1].transform.position = up;
        Walls[2].transform.position = right;
        Walls[3].transform.position = down;

        stars.transform.position = new Vector3(right.x,right.y,0);
    }
    
 
}
