using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum ColorKinds
{
    RED,
    BLUE,
    GREEN,
    YELLOW,
    NONE
}

public class ItamInfo : MonoBehaviour
{
    public ColorKinds _colorKinds;
    //public ColorKinds _colorKinds
    //{
    //    get
    //    {
    //        return colorKinds;
    //    }
    //    set
    //    {
    //        colorKinds = value;
    //    }
    //}


    // Start is called before the first frame update

    void Start()
    {
        //ChangeColor(_colorKinds);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void HideOBJ()
    {
        gameObject.SetActive(false);
    }
    public void ShowOBJ()
    {
        gameObject.SetActive(true);
    }
    public void ChangeColor(ColorKinds colorKinds)
    {
        if(colorKinds==ColorKinds.BLUE)
            gameObject.GetComponent<SpriteRenderer>().color = Color.blue;
        if (colorKinds == ColorKinds.GREEN)
            gameObject.GetComponent<SpriteRenderer>().color = Color.green;
        if (colorKinds == ColorKinds.RED)
            gameObject.GetComponent<SpriteRenderer>().color = Color.red;
        if (colorKinds == ColorKinds.YELLOW)
            gameObject.GetComponent<SpriteRenderer>().color = Color.yellow;
    }
}
