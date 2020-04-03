using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemGenerator : MonoBehaviour
{

    public GameObject carPrefab;
    //coinPrefabを入れる
    public GameObject coinPrefab;
    //cornPrefabを入れる
    public GameObject conePrefab;
    //スタート地点
    private float startPos = -160f;
    //ゴール地点
    private float goalPos = 120f;
    //アイテムを出すx方向の範囲
    private float posRange = 3.4f;

    private GameObject unitychan;


    


    // Use this for initialization
    void Start()
    {
        this.unitychan = GameObject.Find("unitychan");

        startPos = unitychan.transform.position.z;

    }



    // Update is called once per frame
    void Update()
    {


        if (this.unitychan.transform.position.z >= startPos + 15f && this.unitychan.transform.position.z <= goalPos -40)
        {
            startPos = unitychan.transform.position.z;


            //どのアイテムを出すのかをランダムに設定
            int num = Random.Range(1, 11);
            if (num <= 2)
            {
                //コーンをx軸方向に一直線に生成
                for (float j = -1; j <= 1; j += 0.4f)
                {
                    GameObject cone = Instantiate(conePrefab) as GameObject;
                    cone.transform.position = new Vector3(4 * j, cone.transform.position.y, startPos + 40f);
                }
            }
        
            else
            { 

                //レーンごとにアイテムを生成
                for (int j = -1; j <= 1; j++)
                {
                    //アイテムの種類を決める
                    int item = Random.Range(1, 11);
                    //アイテムを置くZ座標のオフセットをランダムに設定
                    int offsetZ = Random.Range(-10, 10);
                    //60%コイン配置:30%車配置:10%何もなし
                    if (1 <= item && item <= 6)
                    {
                        //コインを生成
                        GameObject coin = Instantiate(coinPrefab) as GameObject;
                        coin.transform.position = new Vector3(posRange * j, coin.transform.position.y, startPos + 40f + offsetZ);
                    }
                    else if (7 <= item && item <= 9)
                    {
                        //車を生成
                        GameObject car = Instantiate(carPrefab) as GameObject;
                        car.transform.position = new Vector3(posRange * j, car.transform.position.y, startPos + 40f + offsetZ);
                    }
                }

            }


        }

        
    }
}


