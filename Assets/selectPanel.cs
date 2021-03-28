using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class selectPanel : MonoBehaviour
{
    RectTransform trans;
    float startPos = -7;
    public static int characterPtr = 0;
    private int lastPtr=0;
    public GameObject[] characters;
    public Text title;
    public Text describe;
    public Text advantage;
    public GameObject buy_btn;
    public Text starsText;
    public AudioSource aud;
    public Animator anim;
    private void Start()
    {
        trans = GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (trans.position.x > startPos-2)
        {
            characterPtr = 0;
        }
        else
        {
            if (trans.position.x > startPos -6)
            {
                characterPtr = 1;
            }
            else
            {
                characterPtr = 2;
            }
        }
        if (characterPtr != lastPtr)
        {
            changeScale(characterPtr);
            changeText(characterPtr);
            changeBtn(characterPtr);
            if(DataControl.Instance.character[characterPtr])
                changeBtnImage(characterPtr);
            lastPtr = characterPtr;
        }
    }
    private void changeScale(int index)
    {
        for(int i = 0; i < 3; i++)
        {
            if (i == index)
                characters[i].transform.localScale = new Vector3(2.13f,2.13f,2.13f);
            else
                characters[i].transform.localScale = new Vector3(1.5f,1.5f, 1.5f);
        }
    }
    private void changeText(int index)
    {
        switch (index)
        {
            case 0:
                title.text = "男孩的飞机";
                describe.text = "男孩靠着稻草人 吹着风 唱着歌 睡着了";
                advantage.text = "";
                break;
            case 1:
                title.text="妈妈的飞机";
                describe.text = "睡吧 睡吧 我亲爱的宝贝";
                advantage.text = "特点:更小的体积";
                break;
            case 2:
                title.text = "爸爸的飞机";
                describe.text = "小小的你 把我大大的烦恼都吹进风里";
                advantage.text = "特点：更敏捷的飞行"
;                break;
        }
        
    }
    private void changeBtn(int index)
    {
        if (DataControl.Instance.character[index])
            buy_btn.SetActive(false);
        else
            buy_btn.SetActive(true);
    }
    public void buy()
    {
        if (DataControl.Instance.stars >= 80)
        {
            DataControl.Instance.stars -= 80;
            DataControl.Instance.write(DataControl.Instance.stars, "record");
            starsText.text = DataControl.Instance.stars.ToString();
            DataControl.Instance.buyCharacter(characterPtr);
            buy_btn.SetActive(false);
            changeBtnImage(characterPtr);
        }
        else
            aud.Play();
    }
    private void changeBtnImage(int index)
    {
        anim.SetInteger("character", index);
    }
}
