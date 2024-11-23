using UnityEngine;

public class Util
{
    public static bool Dice(int value) {
        return Random.Range(0, 101) >= 100 - value;
    }    
}
