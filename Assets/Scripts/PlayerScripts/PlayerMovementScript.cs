using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;
using System.Collections;
using Unity.Behavior;

public class PlayerMovementScript : MonoBehaviour
{
    CharacterController _cCR;

    public int _speed;
    private Vector2 _moveInput;
    public bool canMove = true;

    [SerializeField] private HealthScript enemyHealth;
    [SerializeField] private float attackDist = 2;
    [SerializeField] private TextMeshProUGUI victoryText;
    [SerializeField] private BehaviorGraphAgent enemyBehaviour;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _cCR = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!canMove)
            return;

        Vector3 movement = new Vector3(_moveInput.x, 0, _moveInput.y).normalized;

        _cCR.Move(movement * _speed * Time.deltaTime);
    }

    private void AttackEnemy()
    {
        float dist = Vector3.Distance(enemyHealth.gameObject.transform.position, transform.position);
        if(dist <= attackDist && enemyHealth.health > 0)
        {
            enemyHealth.TakeDamage();
        }
        else if(dist <= attackDist && enemyHealth.health <= 0)
        {
            canMove = false;
            enemyBehaviour.enabled = false;
            victoryText.text = "You Win!";
            Invoke("EndGame", 3);
        }
    }

    public void OnMove(InputAction.CallbackContext ctx)
    {
        _moveInput = ctx.ReadValue<Vector2>();
    }

    public void OnAttack(InputAction.CallbackContext ctx)
    {
        if (ctx.performed && canMove)
        {
            AttackEnemy();
        }
    }

    private void EndGame()
    {
        SceneManagerScript.Instance.BackToMenu();
    }
}
