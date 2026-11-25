using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float Attack1Damage;
    public float Attack2Damage;
    public Animator anim;
    public bool isattacking;
    public EnemyController Enemy;
    public Transform AttackVFXTransform;
    public void onattack1buttonclicked()
    {
        isattacking = true;
        anim.Play("Attack");

    }
    public void onattack2buttonclicked()
    {
        isattacking = true;
        anim.Play("Attack2");
    }
    public void ReturnToIdle()
    {
        anim.Play("Idle");
    }
    public void DamageEnemy(float damage)
    {
        Enemy.hurt(damage);
    }
    public void SpawnVFX(GameObject VFX)
    {
        GameObject SpawnedVFX = Instantiate(VFX, AttackVFXTransform.position, Quaternion.identity);
        Destroy(SpawnedVFX, 0.5f);
    }
    public IEnumerator HitStop()
    {
        Time.timeScale = 0f;
        yield return new WaitForSecondsRealtime(0.1f);
        Time.timeScale = 1f;
    }
} 
