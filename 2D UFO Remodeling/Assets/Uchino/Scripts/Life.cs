using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Life : MonoBehaviour {

    [SerializeField]
    private GameObject life;       //ハート
    private GameObject[] lifes;    //ハートの数（減らす用）

    [SerializeField]
    private int maxLife = 3;       //ハートの数
    
	// Use this for initialization
	void Start () {

        //ハートの横のサイズを取得
        var rectTranseform = life.GetComponent<RectTransform>();
        float sizeX = rectTranseform.rect.width;

        //ハートの配列を生成
        lifes = new GameObject[maxLife];

        //ハートを作る
        GenerateHearts(sizeX);
	}


    /// <summary>
    /// ハートを作って並べる
    /// </summary>
    /// <param name="sizeX"></param>
    private void GenerateHearts(float sizeX)
    {
        for (int i = 0; i < maxLife; i++)
        {
            lifes[i] = Instantiate(life, 
                new Vector3(transform.position.x + sizeX * i, transform.position.y, 0), Quaternion.identity);
            lifes[i].transform.SetParent(transform);
        }
    }

    /// <summary>
    /// hpを減らす
    /// </summary>
    public void ReduceHp()
    {
        maxLife--;
        if (maxLife >= 0)
        {
            Death();
        }

    }

    public bool IsDead()
    {
        return (maxLife <= 0);
    }

    /// <summary>
    /// ハートを減らす
    /// </summary>
    private void Death()
    {
        Destroy(lifes[maxLife].gameObject);
    }
}
