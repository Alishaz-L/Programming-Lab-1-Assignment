using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Collectable : MonoBehaviour
{
    //Creating a varible that is only going to be used in this class and this varible is also the counter for the amount of items my player collects
    private static int Totalitems = 0;
    //Created this Serialized field so I could apply this script to the items
    [SerializeField] private Text _text;

    //This function tells the game what to do when the player collides with the items
    private void OnTriggerEnter(Collider other)
    {
        //If statment saying the condition
        if (other.transform.tag == "Player")
        {
            Players playerScript = other.GetComponent<Players>();

            Bullet bulletScript = playerScript.GetComponent<Bullet>();

            Players.ammoFiredCounter = 16;

            //Add 1 to the counter that tracks the collisions 
            Totalitems++;
            //This allows the game to remove the item once the player has collided with it
            Destroy(gameObject);

            if (bulletScript != null && (bulletScript.BulletType & Bullet.EProjectileType.Legendary) != 0)
            {
                // Update the projectileForce in the player's script
                playerScript.projectileForce = 100;

                //This is the text that is displayed on the top left of the screen that updates everytime the player collides with an item. 
                //_text.text = "Total Amount Of Items: " + Totalitems.ToString();
            }

            if (bulletScript != null && (bulletScript.BulletType & Bullet.EProjectileType.Rare) != 0)
            {
                // Update the projectileForce in the player's script
                playerScript.projectileForce = 80;

                //This is the text that is displayed on the top left of the screen that updates everytime the player collides with an item. 
                //_text.text = "Total Amount Of Items: " + Totalitems.ToString();
            }

            if (bulletScript != null && (bulletScript.BulletType & Bullet.EProjectileType.Common) != 0)
            {
                // Update the projectileForce in the player's script
                playerScript.projectileForce = 60;

                //This is the text that is displayed on the top left of the screen that updates everytime the player collides with an item. 
                //_text.text = "Total Amount Of Items: " + Totalitems.ToString();
            }
        }
    }
}