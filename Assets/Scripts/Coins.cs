using UnityEngine;

public class Coins : MonoBehaviour
{
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.CompareTag("Player")) 
        {
            MoneyText.Coin += 1;
            Destroy(gameObject);
        }
    }
}
