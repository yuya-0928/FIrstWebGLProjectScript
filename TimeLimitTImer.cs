using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimeLimitTImer : MonoBehaviour
{
    public float totalTime = 10.5f;
    public GameObject gameOverUI;
    private TextMeshProUGUI text_mesh_pro;

    // Start is called before the first frame update
    void Start()
    {
        text_mesh_pro = this.GetComponent<TextMeshProUGUI>();
        gameOverUI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

        // ゲームが開始してからの秒数をtotalTimeから引く
        totalTime -= Time.deltaTime;

        // 少数2桁にして表示
        text_mesh_pro.text = "TimeLimit:" + totalTime.ToString("F0") + "sec";
        
        if (totalTime <= 0)
        {
            text_mesh_pro.text = "Time up!";
            gameOverUI.SetActive(true);
            
        }
    }
}