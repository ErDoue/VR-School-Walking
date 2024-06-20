using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoginGame : MonoBehaviour
{
    public GameObject LoginPanel;
    public GameObject RegisterPanel;
    public GameObject SettingPanel;

    public InputField r_userName;
    public InputField r_password;
    public InputField cr_password;
    public InputField userName;
    public InputField password;

    string name = "";   //临时存储账号
    string pass = "";   //临时存储密码

    string str = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz12345678900123456789";
    string showText = "";//展示的验证码的字符串
    public Text textShow;//文本展示在UI界面上
    public InputField setText;
    int index = 0;

    // Start is called before the first frame update
    void Start()
    {
        r_userName = r_userName.GetComponent<InputField>();
        r_password = r_password.GetComponent<InputField>();
        cr_password = cr_password.GetComponent<InputField>();
        userName = userName.GetComponent<InputField>();
        password = password.GetComponent<InputField>();

        textShow = textShow.GetComponent<Text>();
        setText = setText.GetComponent<InputField>();
    }

    public void SelectString()
    {
        showText = "";
        for (int i = 0; i < 4; i++)
        {
            index = Random.Range(0, str.Length);//最大值取不到
            showText += str[index];
        }

        textShow.text = showText;
        setText.text = "";
        //showText = showText.ToLower();  //比较时不区分大小写，小
    }

    public void ConfirmRegister()
    {
        if (string.IsNullOrEmpty(r_userName.text) || string.IsNullOrEmpty(r_password.text) || r_password.text != cr_password.text)
        {
            print("注册失败,再来一次叭");
            r_userName.text = "";
            r_password.text = "";
            cr_password.text = "";
            return;
        }

        name = r_userName.text;
        pass = r_password.text;
        r_userName.text = "";
        r_password.text = "";
        cr_password.text = "";
        print("注册成功" + name + "  " + pass);
        SelectString();
        RegisterPanel.SetActive(false);
    }

    public void Login()
    {
        if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(pass))
        {
            userName.text = "";
            password.text = "";
            return;
        }
        if (name == userName.text && pass == password.text)
        {
            //if(setText.text.ToLower()==textShow.text)
            if (setText.text == textShow.text)
            {
                print("登录成功");
                //PlayerPrefs.SetString
                UnityEngine.SceneManagement.SceneManager.LoadScene(1);
                UserData.UserName = userName.text;
            }
            else
            {
                print("验证码错误");
                SelectString();
            }
        }
        else
        {
            print("登录失败");
            SelectString();
        }
        userName.text = "";
        password.text = "";
    }

    public void OpenLoginPanel()
    {
        SelectString();
        LoginPanel.SetActive(true);
    }

    public void OpenRegisterPanel()
    {
        LoginPanel.SetActive(false);
        RegisterPanel.SetActive(true);
    }

    public void CloseRegisterPanel()
    {
        SelectString();
        r_userName.text = "";
        r_password.text = "";
        cr_password.text = "";
        RegisterPanel.SetActive(false);
        LoginPanel.SetActive(true);
    }

    public void OpenSettingPanel()
    {

        SettingPanel.SetActive(true);
    }

    public void CloseSettingPanel()
    {
        SettingPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
