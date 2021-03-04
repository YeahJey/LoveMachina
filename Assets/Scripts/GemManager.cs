using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemManager : MonoBehaviour
{
    public static GemManager instance;
    //Amount of gems player has of each kind
    public int[] gems = new int[8];
    public enum Gems
    {
        White,
        Teal,
        Green,
        Blue,
        Purple,
        Black,
        Yellow,
        Red
    }
    /// <summary>
    /// Uses gem color as key and returns gem's position in 'gems' array
    /// </summary>
    Dictionary<Gems, int> gemDict = new Dictionary<Gems, int>();

    private void Awake()
    {
        if (instance == null) instance = this;
        else Destroy(this);
        gemDict.Add(Gems.White, 0);
        gemDict.Add(Gems.Teal, 1);
        gemDict.Add(Gems.Green, 2);
        gemDict.Add(Gems.Blue, 3);
        gemDict.Add(Gems.Purple, 4);
        gemDict.Add(Gems.Black, 5);
        gemDict.Add(Gems.Yellow, 6);
        gemDict.Add(Gems.Red, 7);
    }
    /// <summary>
    /// Adds amount to certain colored gem's amount (use negative numbers to subtract)
    /// </summary>
    /// <param name="amount"></param>
    public void AddGem(Gems gem, int amount)
    {
        gems[gemDict[gem]] += amount;
    }

    /// <summary>
    /// Get an amount of a gem of certain color
    /// </summary>
    /// <param name="gems"></param>
    /// <returns></returns>
    public int GetGem(Gems gems)
    {
        return this.gems[gemDict[gems]];
    }

}
