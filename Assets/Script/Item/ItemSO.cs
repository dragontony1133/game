using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "ItemSO", menuName = "ItemSO", order = 0)]
public class ItemSO : ScriptableObject {
    public string itemName;
    public StatToChange stateToChange = new StatToChange();
    public int amountToChangeStat;

    public void UseItem(){
        Debug.Log("useItem");
        if (stateToChange == StatToChange.health)
        {
            GameObject.Find("Player").GetComponent<PlayerHealth>().Heal(5);
        }
    }
    public enum StatToChange
    {
        none,
        health
    }
}
