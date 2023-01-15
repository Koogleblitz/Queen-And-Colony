using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class FoodBar : MonoBehaviour
{
    public Image currentFoodbar;
    public TMP_Text ratioText;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(GameManager.instance.currentfood<0) {
            GameManager.instance.currentfood=0; }
        else if (GameManager.instance.currentfood>GameManager.instance.maxfood) {
            GameManager.instance.currentfood=GameManager.instance.maxfood; }

        int currentfood = GameManager.instance.currentfood;
        int maxfood = GameManager.instance.maxfood;

        float ratio=(float)currentfood/maxfood;
        currentFoodbar.rectTransform.localScale = new Vector3(ratio,1,1);
        ratioText.text = currentfood.ToString()+"/"+maxfood.ToString();
    }

}
