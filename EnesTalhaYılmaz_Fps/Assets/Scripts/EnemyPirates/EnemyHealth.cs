using TMPro;
using UnityEngine;
using EnesTalhaYılmaz_Fps.Projectile;

public class EnemyHealth : MonoBehaviour,IDamageable
{
    [SerializeField] private float maxHealth=100f;
     [SerializeField] Transform healthBar;
    [SerializeField] AudioSource audioSource;
    SpriteRenderer healthBarSpriteRenderer;
    AIStateDeciding aIStateDeciding;
    Animator animator;
    Controllers.PcControllers input;
    float currentHealth=100f;
    void Awake(){
        input=new Controllers.PcControllers();
        healthBarSpriteRenderer=healthBar.GetComponentInChildren<SpriteRenderer>();
        aIStateDeciding=GetComponent<AIStateDeciding>();
        animator=GetComponentInChildren<Animator>();

    }
    void Start(){
        currentHealth=maxHealth;
    }
    void Update(){
        UpdateHealthText();

        if(input.renewTargetHealthsInput){
            currentHealth=maxHealth;
        }
    }
    void UpdateHealthText()
    {
        if(currentHealth>=0){
            float scaleRatio = 1 / maxHealth * currentHealth;
            healthBar.localScale = new Vector3(scaleRatio, 1f);

        }
        else{
            healthBar.localScale = new Vector3(0, 1f);
        }
        
        UpdateHealthBarColor();

    }

    private void UpdateHealthBarColor()
    {
        if (currentHealth > 70)
        {
            healthBarSpriteRenderer.color = Color.green;
            Debug.Log("Green");
        }
        else if (currentHealth < 70 && currentHealth > 40)
        {
            healthBarSpriteRenderer.color = Color.yellow;
            Debug.Log("yellow");
        }
        else if (currentHealth < 40)
        {
            healthBarSpriteRenderer.color = Color.red;
            Debug.Log("Red");
        }
    }

    public void Damage(int amount){
        currentHealth-=amount;
        SoundManager.Instance.PlaySound(SoundType.EnemyHit,audioSource);
        if(currentHealth<=0f){
            Die();
        }
    }
    void Die(){
        aIStateDeciding.IsEnemyDeath=true;
        //animator.SetBool("IsWalking",false);
        animator.SetTrigger("Dead");
        Destroy(gameObject,2f);
    }
}
