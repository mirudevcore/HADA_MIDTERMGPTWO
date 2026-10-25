using UnityEngine;

public class ColoredEnemy : EnemyBase // Inherits from EnemyBase and implements IDamageable
{
    public int HP = 100; //HP for the tank enemy, can be adjusted in inspector

    private void OnEnable()
    {
        Debug.Log("Tank enemy spawned and ready."); //shows in console when enemy is spawned
    }
    
    public override void Damage() // method to reduce HP when hit
    {
        HP -= 25; 
        Debug.Log("Tank got hit! Remaining HP: " + HP);

        if (HP <= 0) // if HP is 0 or less, destroy the enemy
        {
            Debug.Log("Tank destroyed!");
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        
        if (other.CompareTag("Player")) // if the enemy collides with the player, it will trigger a game over
        {
            Debug.Log("GAME OVER");
            Time.timeScale = 0f; // Pause the game
        }
    }
}
