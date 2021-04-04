using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoneSpawner : MonoBehaviour
{
    public float stoneSpeed = 2f;
    public float spawnInterval = 3f;
    public int stoneAmount = 5;
    public List<GameObject> stones;
    
    private float x;
    private float up;
    private float down;
    private Vector3 rightUp;
    private Vector3 rightDown;

    private Vector3 spawnLocation;
    private Vector3 spawnRotation;
    private Vector3 forceDirection;
    private float thisTime;
    private float lastTime;
    private int randomStone;
    private List<GameObject> stonePool = new List<GameObject>(5);
    
    // Start is called before the first frame update
    void Start()
    {
        rightUp = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));
        rightDown = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, 0, 0));
        x = rightUp.x;
        up = rightUp.y;
        down = rightDown.y;
        lastTime = Time.time;
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        thisTime = Time.time;
        if (thisTime - lastTime >= spawnInterval)
        {
            if (stonePool.Count < stoneAmount)
            {
                spawnStone();
            }

            lastTime = thisTime;
        }
        resetStone();
    }

    private void spawnStone()
    {
        if (stonePool.Count < stoneAmount)
        {
            randomStone = Random.Range(0,stones.Count-1);
            spawnLocation = new Vector3(x, Random.Range(down+0.5f, up-0.5f) ,0);
            spawnRotation = new Vector3(Random.Range(0, 180f), Random.Range(0, 180f) ,Random.Range(0, 180f));
            forceDirection = new Vector3(-Random.value * stoneSpeed,Random.Range(-1f,1f) * stoneSpeed/2,0);
            stonePool.Add(Instantiate(stones[randomStone],spawnLocation, Quaternion.Euler(spawnRotation)));
            stonePool[stonePool.Count -1].GetComponent<Rigidbody>().AddForce(forceDirection);
        }
    }

    private void resetStone()
    {
        foreach (var stone in stonePool)
        {
            if (stone.GetComponent<Stone>().hitOverScreen)
            {
                stone.GetComponent<Stone>().hitOverScreen = false;
                spawnLocation = new Vector3(x, Random.Range(down+2, up-2) ,0);
                stone.transform.position = spawnLocation;
            }
        }
    }
    
}
