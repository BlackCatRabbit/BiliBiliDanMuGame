using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager _instance;
    
    private GameObject _cubePrefab;

    public GameObject[] _Pos;

    public Dictionary<int, GameObject> playerDirs = new Dictionary<int, GameObject>();
    private void Awake()
    {
     
        _instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        _cubePrefab = Resources.Load<GameObject>("Prefabs/" + "Map");
        CreatePrefab(10,10);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CreatePrefab(int hight,int weight)
    {

        for (float i=0;i<weight;i+=0.5f)
        {
            for (float j = 0; j < hight; j+=0.5f)
            {
                GameObject go = Instantiate(_cubePrefab, new Vector3(i-4.75f, j-4.75f, 0), Quaternion.identity);
                go.transform.SetParent(transform);
            }

        }
    }
    public void CreatePlayer(int UID,Sprite sprite)
    {
        int index = Random.Range(0, 4);
        if(index==0)
        {
            if(!playerDirs.ContainsKey(UID))
            {
                GameObject go = ObjectPool.GetInstance().GetObj("PlayerBlue");
                go.transform.position = _Pos[index].transform.position;
                go.transform.rotation = Quaternion.Euler(0, 0, 37);
                go.GetComponent<TanQiuCtr>().UID = UID;
                go.GetComponent<SpriteRenderer>().sprite = sprite;
                playerDirs.Add(UID,go);
            }
        }
       else if (index == 1)
        {
            if (!playerDirs.ContainsKey(UID))
            {
                GameObject go = ObjectPool.GetInstance().GetObj("PlayerRed");
                go.transform.position = _Pos[index].transform.position;
                go.transform.rotation = Quaternion.Euler(0, 0, -215);
                go.GetComponent<TanQiuCtr>().UID = UID;
                go.GetComponent<SpriteRenderer>().sprite = sprite;
                playerDirs.Add(UID, go);
            }
        }
       else if (index == 2)
        {
            if (!playerDirs.ContainsKey(UID))
            {
                GameObject go = ObjectPool.GetInstance().GetObj("PlayerGreen");
                go.transform.position = _Pos[index].transform.position;
                go.transform.rotation = Quaternion.Euler(0, 0, -45);
                go.GetComponent<TanQiuCtr>().UID = UID;
                go.GetComponent<SpriteRenderer>().sprite = sprite;
                playerDirs.Add(UID, go);
            }

        }
       else if (index == 3)
        {
            if (!playerDirs.ContainsKey(UID))
            {
                GameObject go = ObjectPool.GetInstance().GetObj("PlayerYellow");
                go.transform.position = _Pos[index].transform.position;
                go.transform.rotation = Quaternion.Euler(0, 0, -145);
                go.GetComponent<TanQiuCtr>().UID = UID;
                go.GetComponent<SpriteRenderer>().sprite = sprite;
                playerDirs.Add(UID, go);
            }
        }
    }
}
