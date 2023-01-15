using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class FoodBar : MonoBehaviour
{
    public Image currentFoodbar;
    public TMP_Text ratioText;

    public int currentfood = 100;
    public int maxfood = 500;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(currentfood<0) {
            currentfood=0; }
        else if (currentfood>maxfood) {
            currentfood=maxfood; }

        float ratio=(float)currentfood/maxfood;
        currentFoodbar.rectTransform.localScale = new Vector3(ratio,1,1);
        ratioText.text = currentfood.ToString()+"/"+maxfood.ToString();
    }

    private void ModifyFood(int num)
    {
        currentfood += num;
    }
}
