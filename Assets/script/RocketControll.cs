using UnityEngine;

public class RocketControll : MonoBehaviour
{
    
    // Start is called before the first frame update
    private Vector3 dis;
    private Vector3 lastPosition;
    private bool isHit = false;
    private float mousePositionXPercent;
    private float mousePositionYPercent;
    private GameObject deadBody;

    public GameObject explodedPieces;
    public float speed = 1f;
    public float returnSpeed = 1f;
    public float returnRange = 9f;
    public float mouseRange = 1.5f;
    public float durability = 5f;

    private void Start()
    {
        lastPosition = this.transform.position;
    }

    void Update()
    {
        if (!isHit)
        {
            followMouse();
        }
        else
        {
            returnToLastPosition();
        }
    }


    void followMouse()
    {
        // 此时的摄像机必须转换 2D摄像机 来实现效果（即：摄像机属性Projection --> Orthographic）
        dis = Camera.main.ScreenToWorldPoint(Input.mousePosition); //获取鼠标位置并转换成世界坐标
        dis.z = 0; //固定z轴
        
        if ((transform.position - dis).sqrMagnitude > mouseRange)
        {
            this.transform.position = Vector3.Lerp(this.transform.position,dis,speed * Time.deltaTime);
        }
        this.transform.LookAt(Vector3.Lerp(this.transform.position,dis,speed * Time.deltaTime));

    }

    void returnToLastPosition()
    {
        this.transform.LookAt(lastPosition);
        this.transform.position = Vector3.Lerp(this.transform.position,lastPosition,returnSpeed * Time.deltaTime);

        mousePositionYPercent = Input.mousePosition.y / Screen.height;
        mousePositionXPercent = Input.mousePosition.x / Screen.height;
        if ((transform.position - lastPosition).sqrMagnitude < returnRange && 
            ((mousePositionYPercent > 0.05 &&
              mousePositionYPercent < 0.95)&&
             (mousePositionXPercent > 0.05 &&
              mousePositionXPercent < 0.95 ))
            )
        {
            isHit = false;
        }
    }

    void die()
    {
        GameObject.Find("Button").transform.localScale = new Vector3(1,1,1);
        this.transform.localScale = new Vector3(1,1,1);
        Destroy(this);
        deadBody = Instantiate(explodedPieces,this.transform);
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag=="Wall")
        {
            isHit = true;
        }
        else if (other.gameObject.tag=="Stone")
        {
            durability--;
            if (durability <= 0)
            {
                die();
            }
            print(durability);
        }
        
    }

}
