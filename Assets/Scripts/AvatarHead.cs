using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AvatarHead: MonoBehaviour
{
    public Image avatarImage; // 拖拽分配UI Image组件
    public Text nameText;     // 拖拽分配UI Text组件

    // 假设头像资源存放在Resources/Avatars文件夹下
    private string[] avatarPaths =
    {
        "Avatars/01",
        "Avatars/02",
        "Avatars/03",
        "Avatars/04",
        "Avatars/05",
        "Avatars/06",
        "Avatars/07",
        "Avatars/08",
        "Avatars/09",
        "Avatars/1",
        "Avatars/2",
        "Avatars/4",
         "Avatars/6",
        "Avatars/11",
    };

    void Start()
    {
        // 在开始时可以调用一个方法来显示一个随机头像和名字
        ShowRandomAvatarAndName();
    }

    public void ShowRandomAvatarAndName()
    {
        // 随机选择头像索引
        int randomIndex = Random.Range(0, avatarPaths.Length);

        // 加载随机头像
        Sprite avatarSprite = Resources.Load<Sprite>(avatarPaths[randomIndex]);
        if (avatarSprite != null)
        {
            avatarImage.sprite = avatarSprite;
        }
        else
        {
            Debug.LogError("Failed to load avatar sprite: " + avatarPaths[randomIndex]);
        }

        // 设置一个随机或固定的名字
        //string name = "Player " + (randomIndex + 1); 
        nameText.text = UserData.UserName;
    }

    public void UpdateAvatarAndName(string newName, string newAvatarPath)
    {
        // 加载新的头像
        Sprite avatarSprite = Resources.Load<Sprite>(newAvatarPath);
        if (avatarSprite != null)
        {
            avatarImage.sprite = avatarSprite;
        }
        else
        {
            Debug.LogError("Failed to load avatar sprite: " + newAvatarPath);
        }

        // 设置新的名字
        nameText.text = "name:"+newName;
    }
}