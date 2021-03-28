using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class about : MonoBehaviour
{
    public Animator anim;
    public GameObject btn_ok;
    public GameObject btn_buy;
    public GameObject btn_back;
    public Text text;
    public void onAboutCilck()
    {
        anim.SetTrigger("buy");
        btn_ok.SetActive(true);
        btn_buy.SetActive(false);
        btn_back.SetActive(false);
        text.text = "探索不同关卡内不同的障碍物\n高难度关卡有更多星星掉落\n收集星星解锁有不同能力的新角色";
    }
    public void OnOkClick()
    {
        anim.SetTrigger("back");
        btn_ok.SetActive(false);
    }
}
