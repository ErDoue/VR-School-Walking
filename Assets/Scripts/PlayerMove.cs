using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMove : MonoBehaviour
{
    Animator animator;

    public AudioSource runningAudio; // 引用Audio Source组件

    // public int jumpCount = 1;
    public float jumpForce = 5;

    public bool isGround = false;
    public bool canJump = true;

    // 角色速度
    private float speed = 0f;

    // 用于Animator的速度参数名称
    private string speedParam = "Speed";

    // 跑步速度阈值
    private float runThreshold = 5f;

    void Start()
    {
        animator = GetComponent<Animator>();
        runningAudio = GetComponent<AudioSource>(); // 获取Audio Source组件

    }

   
    void UpdateAnim()
    {
        animator.SetBool("isWalking",false);
        animator.SetBool("canJump", false);
        animator.SetBool("isBacking", false);
    }
    void Jump()
    {
        animator.SetBool("canJump", true);
        var component = transform.GetComponent<Rigidbody>();
        component.AddForce(Vector3.up*jumpForce, ForceMode.Impulse); 
        canJump = false;
    }

    void Update()
    {
        UpdateAnim();

        CalculateSpeed();   //计算速度
        // 根据速度设置Animator的速度参数
        // 这里我们使用float参数，值可以是0（静止/待机）到某个最大值（跑步）

        animator.SetFloat(speedParam, Mathf.Abs(speed));
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }


        //获取人物前后走动--动画animator
        if (Input.GetAxis("Vertical") > 0)
        {
            animator.SetBool("isWalking", true);
        }
        else if(Input.GetAxis("Vertical")<0)
        {
            animator.SetBool("isBacking",true);
        }
        else
        {
            animator.SetBool("isWalking", false);
            animator.SetBool("isBacking", false);
        }

        //人物移动
        transform.Translate(0, 0, Input.GetAxis("Vertical") * 0.08f);
        transform.Rotate(0, Input.GetAxis("Horizontal"), 0);
        if (Input.GetMouseButton(0))
        {
            transform.GetChild(0).Rotate(-Input.GetAxis("Mouse Y") * 1.2f, Input.GetAxis("Mouse X") * 1.2f, 0);
            transform.GetChild(0).eulerAngles = new Vector3(transform.GetChild(0).eulerAngles.x, transform.GetChild(0).eulerAngles.y, 0);
        }
        if (Input.GetMouseButtonUp(0))
        {
            transform.GetChild(0).localEulerAngles = Vector3.zero;
        }

        //if (Input.GetKeyDown(KeyCode.Space)) 
        //{
        //    var component = transform.GetComponent<Rigidbody>();
        //    component.AddForce(new Vector2(0, 10), ForceMode.Impulse);          
        //}
       
        //if (Input.GetMouseButton(1))  //点击右键
        //{
        //    transform.GetChild(0).Rotate(-Input.GetAxis("Mouse Y"), Input.GetAxis("Mouse X"), 0);
        //    transform.GetChild(0).eulerAngles = new Vector3(transform.GetChild(0).eulerAngles.x, transform.GetChild(0).eulerAngles.y, 0);
        //}
       

    }

    void onCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Terrain"))
        {
            isGround = true;
            canJump = true;
        }
    }

    void onCollisionExit(Collision collision)
    {
        if (collision.collider.CompareTag("Terrain"))
        {
            isGround = false;
        }
    }
    private void CalculateSpeed()
    {
        // 这里只是简单地使用垂直输入轴作为速度
        speed = Input.GetAxis("Vertical") ; // 乘以是为了让速度变化更明显

        // 如果速度超过阈值，则角色应该进入跑步状态
        // 这里不需要直接设置状态，因为Animator Controller中的过渡会基于speedParam的值自动触发
        //if (Mathf.Abs(speed) > runThreshold)
        //{
        //    if (!runningAudio.isPlaying) // 确保音效没有正在播放
        //    {
        //        Debug.Log("等等等");
        //        runningAudio.Play(); // 播放跑步音效
        //    }
        //}
        //else
        //{
        //    runningAudio.Stop(); // 如果速度低于阈值，停止音效
        //}
    }
}


