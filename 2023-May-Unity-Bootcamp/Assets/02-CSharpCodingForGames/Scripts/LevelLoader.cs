using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelLoader : MonoBehaviour
{
    public static int score = 0;
    void Start()
    {
        // create a player
        Player player = new Player();

        // create some enemies
        Enemy enemy1 = new Enemy();
        Enemy enemy2 = new Enemy();

        // create some weapons
        Weapon gun1 = new Weapon("gun1", 5);
        Weapon gun2 = new Weapon("gun2", 5);
        Weapon bazooka = new Weapon("bazooka", 10);

        player.weapon = gun1;
        enemy1.weapon = gun2;
        enemy2.weapon = bazooka;


        Debug.Log($"the product of {5} and {6} is {Utilities.MultiplyTwoNumbers(5, 6)}");

    }

    
}
