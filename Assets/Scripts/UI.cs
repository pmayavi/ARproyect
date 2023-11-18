using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;


public class UI : MonoBehaviour
{
    public Text itemsText;
    public int items;
    public int maxItems;

    private void Awake() 
    {
        itemsText.text = items.ToString() + "/" + maxItems.ToString();  
    }

    public void PickItem() 
    {
        items ++;
        itemsText.text = items.ToString() + "/" + maxItems.ToString();
        
        if (items == maxItems) {
            //SceneManager.LoadScene(2);
            Debug.LogWarning("GANAMOS!");
        }
    }
}
