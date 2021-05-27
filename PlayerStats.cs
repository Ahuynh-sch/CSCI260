using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{
    public int playerLevel = 0;
    private int maxLevel = 50;
    public Text levelText;
    public int currentExp;
    private int baseExp = 50;
    public int[] expToLevelUp;

    // Start is called before the first frame update
    void Start()
    {
        levelText.text = "Kill Count: " + playerLevel;
        expToLevelUp = new int[maxLevel];
        expToLevelUp[1] = baseExp;
        for(int i = 2; i < expToLevelUp.Length; i++)
        {
            expToLevelUp[i] = Mathf.FloorToInt(expToLevelUp[i - 1] * 1.05f);
        }
    }

    // Update is called once per frame
    void Update()
    {
        levelText.text = "Kill Count: " + playerLevel;
    }
}
