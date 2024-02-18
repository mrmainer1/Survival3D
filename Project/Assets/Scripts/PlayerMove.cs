using UnityEngine;
public class PlayerMove : MonoBehaviour
{
    public float speed = 1.5f;
    public float RunSpeed = 3f;
    public float sensitivity;
	public Rigidbody body;
    public UIController uIController;

    private Vector3 oldPositionMouse;
    private float defaultSpeed;

    public Inventory inventory = new Inventory();
    public static Transform playerTransform;
    private void Start()
    {
        defaultSpeed = speed;
        playerTransform = GetComponentInParent<Transform>();
    }
         private void Update()
         {
        Rotate();
        Run();
        Move();
    }

    private void Rotate()
    {

        if (GlobalController.GameNotOnPause)
        {
            Vector3 delta = Input.mousePosition - oldPositionMouse;
            transform.eulerAngles += new Vector3(delta.y * -sensitivity, 0, 0);
            float rotate = transform.eulerAngles.x;
            if (rotate > 180 && rotate < 300)
                rotate = 300;
            if (rotate < 180 && rotate > 60)
                rotate = 60;

            transform.localEulerAngles = new Vector3(rotate, 0, 0);
            body.transform.eulerAngles += new Vector3(0, delta.x * sensitivity, 0);
            oldPositionMouse = Input.mousePosition;
        }
        else
        {
            oldPositionMouse = Input.mousePosition;
        }
    }
    private void Move()
    {
        if (GlobalController.GameNotOnPause)
        {
        float vertical = Input.GetAxis("Vertical");
        float horizontal = Input.GetAxis("Horizontal");


        body.velocity = body.transform.forward * vertical * speed + body.transform.right * horizontal * speed;
        }
    }

    private void Run()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            speed = RunSpeed;   
        }
        else
        {
            speed = defaultSpeed;
        }
    }
}
