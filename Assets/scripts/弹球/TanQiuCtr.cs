using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TanQiuCtr : MonoBehaviour
{
    public ColorKinds _colorPlayer;
    public int UID;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Update()
    {
        transform.Translate(transform.up * 2 * Time.deltaTime, Space.World);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && other.GetComponent<TanQiuCtr>()._colorPlayer!=_colorPlayer)
        {
            if (GameManager._instance.playerDirs.ContainsKey(gameObject.GetComponentInParent<TanQiuCtr>().UID))
            GameManager._instance.playerDirs.Remove(gameObject.GetComponentInParent<TanQiuCtr>().UID);
            ObjectPool.GetInstance().RecycleObj(gameObject);
            return;
        }
        if (other.CompareTag("Wall")&& other.GetComponentInParent<ItamInfo>()._colorKinds!= _colorPlayer)//撞墙反弹
        {

            float fFlag = -1.0f;
            if (other.name == "Up")
            {
                float lAngle = Vector3.Angle(transform.up, Vector3.right);
               // Debug.Log(lAngle);
                transform.Rotate(Vector3.forward * 2.0f * lAngle * fFlag);
                if (other.transform.parent.name == "界面") return;
                other.GetComponentInParent<ItamInfo>()._colorKinds = _colorPlayer;
                other.GetComponentInParent<ItamInfo>().ChangeColor(_colorPlayer);
            }
            else if (other.name == "Down")
            {
                float lAngle = Vector3.Angle(transform.up, Vector3.right);
                //Debug.Log(lAngle+"down");
                transform.Rotate(Vector3.forward * 2.0f * lAngle);
                if (other.transform.parent.name == "界面") return;
                other.GetComponentInParent<ItamInfo>()._colorKinds = _colorPlayer;
                other.GetComponentInParent<ItamInfo>().ChangeColor(_colorPlayer);
            }
            else if (other.name == "Left")
            {
                float lAngle = Vector3.Angle(transform.up, Vector3.up);
                transform.Rotate(Vector3.forward * 2.0f * lAngle * fFlag);
                if (other.transform.parent.name == "界面") return;
                other.GetComponentInParent<ItamInfo>()._colorKinds = _colorPlayer;
                other.GetComponentInParent<ItamInfo>().ChangeColor(_colorPlayer);

            }
            else if (other.name == "Right")
            {
                float lAngle = Vector3.Angle(transform.up, Vector3.up);
                transform.Rotate(Vector3.forward * 2.0f * lAngle);
                if (other.transform.parent.name == "界面") return;
                other.GetComponentInParent<ItamInfo>()._colorKinds = _colorPlayer;
                other.GetComponentInParent<ItamInfo>().ChangeColor(_colorPlayer);
            }
        }
    }


}
