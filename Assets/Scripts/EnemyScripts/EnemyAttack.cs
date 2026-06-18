using UnityEngine;
using TMPro;

public class EnemyAttack : MonoBehaviour
{

    private float attackCoolDown;
    [SerializeField] private HealthScript playerHealthScript;
    [SerializeField] private TextMeshProUGUI loseMessage;
    [SerializeField] private PlayerMovementScript capPlayer;

    void Start()
    {
        attackCoolDown = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (attackCoolDown >= 0)
        {
            attackCoolDown -= Time.deltaTime;
        }
    }

    public void AttackPlayer()
    {
        if(playerHealthScript.health > 0 && attackCoolDown <= 0)
        {
            playerHealthScript.TakeDamage();
            attackCoolDown = 1.5f;
        }
        else if(playerHealthScript.health <= 0)
        {
            loseMessage.text = "You Lose!";
            capPlayer.canMove = false;
            Invoke("EndGame", 3);
        }
    }

    private void EndGame()
    {
        SceneManagerScript.Instance.BackToMenu();
    }
}
