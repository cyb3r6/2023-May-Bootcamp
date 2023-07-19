using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Class containing useful methods
/// </summary>
public static class Utilities
{
    public static string Device_ID;

    /// <summary>
    /// Returns the product of two numbers
    /// </summary>
    /// <param name="number1"></param>
    /// <param name="number2"></param>
    /// <returns></returns>
    public static float MultiplyTwoNumbers(float number1, float number2)
    {
        return number1 * number2;
    }

    public static Vector3 RandomPositionBetweenThings(float number1, float number2, float number3)
    {
        return new Vector3(Random.Range(-number1, number1), Random.Range(-number2, number2), Random.Range(-number3, number3));
    }

}
