using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DoorTrigger : MonoBehaviour
{
    public Animator doorAnimator; // 在Inspector中赋值或通过GetComponent获取

    private bool isOpen = false; // 标记门是否打开

    void OnTriggerEnter(Collider other)
    {
        // 假设人物带有"Player"标签
        if (other.CompareTag("Player"))
        {
            if (!isOpen) // 确保门不是已经打开状态
            {
                OpenDoor();
                isOpen = true; // 设置门为打开状态
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        // 假设人物带有"Player"标签
        if (other.CompareTag("Player") && isOpen)
        {
            CloseDoor();
            isOpen = false; // 设置门为关闭状态
        }
    }

    void OpenDoor()
    {
        
        Debug.Log("OpenDoor()函数被调用");
        doorAnimator.SetTrigger("Opendoor");
    }

    void CloseDoor()
    {
        Debug.Log("OpenDoor()函数被调用");        
        doorAnimator.SetTrigger("Closedoor");
    }

}
