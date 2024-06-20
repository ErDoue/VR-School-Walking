using System.Collections;
using UnityEngine;
using UnityEngine.UI; // 引入UI命名空间

public class TextController : MonoBehaviour
{
    public GameObject textbackground;

    public Text hintText; // 拖拽分配UI中的Text组件
    public string hintMessage = "哈哈<size=55>欢迎</size><color=orange>你</color>呀"; // 要显示的提示信息
    public float delayTime = 3f; // 延迟时间（秒）
    public float typingSpeed = 0.1f; // 打字速度（秒/字符）

    private bool isHintVisible = false;
    private bool isTyping = false;
    private int currentCharIndex = 0;

    void OnTriggerEnter(Collider other) // 对于3D触发器
    {
        if (other.CompareTag("Player") && !isHintVisible)
        {
            StartTyping();
        }
    }

    void StartTyping()
    {
        isHintVisible = true;
        hintText.gameObject.SetActive(true);
        hintText.text = string.Empty; // 清空之前的文本
        isTyping = true;
        StartCoroutine(TypeHint());
        textbackground.SetActive(true);

    }

    IEnumerator TypeHint()
    {
        while (currentCharIndex < hintMessage.Length)
        {
            hintText.text = hintMessage.Substring(0, currentCharIndex);
            currentCharIndex++;
            yield return new WaitForSeconds(typingSpeed);
        }

        // 显示完毕后等待一段时间再隐藏
        yield return new WaitForSeconds(delayTime);
        HideHint();
    }

    void HideHint()
    {
        hintText.gameObject.SetActive(false);
        isHintVisible = false;
        isTyping = false;
        currentCharIndex = 0; // 重置索引以便下次使用
        textbackground.SetActive(false);
    }

    // OnTriggerExit 可以保持不变，或者根据你的需要来修改
    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player") && isHintVisible)
        {
            // 如果需要，可以在这里提前结束显示或隐藏提示
            //可以调用 StopCoroutine 和 HideHint
            //让提示自然结束
        }
    }

}

