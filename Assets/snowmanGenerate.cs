using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class snowmanGenerate : MonoBehaviour
{
    /*
     * 控制风筝的生成
     */
    public GameObject rock;
    public GameObject[] rocks;
    public const int num = 6;//最大风筝数量
    public float genTime = 5.5f;//生成相隔时间
    private const float right = 17.47f;
    private int rockIndex = 0;
    private float lastGenTime = 0f;
    private float lastRankUpTime = 0f;//上次生成时间缩短的时间
    void Start()
    {
        rocks = new GameObject[num];
        for (int i = 0; i < num; i++)
        {
            rocks[i] = (GameObject)Instantiate(rock, new Vector2(18f, 0), Quaternion.identity);
            rocks[i].SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.timeSinceLevelLoad - lastGenTime >= genTime && !GameControl.isDead && (rocks[rockIndex].transform.position.x <= -11 || !rocks[rockIndex].activeSelf))
        {
            lastGenTime = Time.timeSinceLevelLoad;
            float rate = Random.Range(2f, 3f);
            rocks[rockIndex].transform.position = new Vector2(right, (float)(-4.43+rate*0.59));
            
            rocks[rockIndex].transform.localScale = new Vector2(rate,rate);
            rocks[rockIndex].SetActive(true);
            rockIndex++;
            if (rockIndex > num - 1)
                rockIndex = 0;
            if (Time.timeSinceLevelLoad - lastRankUpTime > 15 && genTime >= 3.5f)
            {
                lastRankUpTime = Time.timeSinceLevelLoad;
                genTime -= 0.5f;
            }
        }



    }
}
