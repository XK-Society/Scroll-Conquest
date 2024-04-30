
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
   [SerializeField] private float attackCooldown;
   [SerializeField] private AudioClip swordSound;
   
   private Animator anim;
   private PlayerMovement playerMovement;
   private float cooldownTimer = Mathf.Infinity;

   private void Awake()
   {
    anim =  GetComponent<Animator>();
    playerMovement = GetComponent<PlayerMovement>();
   }

   private void Update()
   {
    if (Input.GetMouseButton(0) && cooldownTimer > attackCooldown && playerMovement.canAttack())
        Attack();

        cooldownTimer += Time.deltaTime;
   }

   private void Attack()
   {
     if (SoundManager.instance != null)
     {
        SoundManager.instance.PlaySound(swordSound);
     }     
        
        anim.SetTrigger("attack");
        cooldownTimer = 0;
   }
}
