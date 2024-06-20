using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Loading : MonoBehaviour
{
    public Image image;  //BG
    public Sprite[] sprites = new Sprite[4];
    public Slider slider;
    public Text text;

    float t = 0;
    float time = 0;

    int index = 0;



    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(UserData.UserName);
        image = image.GetComponent<Image>();
        image.sprite = sprites[index];

        slider = slider.GetComponent<Slider>();
        slider.maxValue = 100;
        slider.minValue = 0;
        slider.value = 0;//当前值,可变值
        text = text.GetComponent<Text>();

    }

    // Update is called once per frame
    void Update()
    {
        t += Time.deltaTime;
        if (t > 1)
        {
            t = 0;
            index++;
            if (index == sprites.Length)
            {
                index = 0;
            }
            image.sprite = sprites[index];
        }
        time += Time.deltaTime;
        if (time < 10)
        {
            slider.value = time * 10;
            text.text = (int)slider.value + "%";
        }
        else
        {
            slider.value = 100;
            text.text = "100%";
            UnityEngine.SceneManagement.SceneManager.LoadScene(0);
        }
    }
}
