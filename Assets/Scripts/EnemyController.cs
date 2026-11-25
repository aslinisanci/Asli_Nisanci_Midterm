using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EnemyController : MonoBehaviour
{
    public float Health;
    public float MaxHealth; 
    public Animator anim;
    public Image HealthBar;
    public bool isDead = false;
    public TMP_Text healthText;

    public GameObject GameOverPanel;
    public GameObject ButtonPanel;
    public GameObject BloodVFX;
    public Transform BloodVFXPosition;

    void Start()
    {
        Health = MaxHealth;
    }
    private void Update()
    {
        UpdateHealthBar();
    }
    public void hurt(float damage) 
    {
        Health -= damage;
        GameObject SpawnedVFX = Instantiate(BloodVFX, BloodVFXPosition.position, Quaternion.identity);
        Destroy(SpawnedVFX, 0.2f);
        if (Health <= 0)
        {
            Health = 0;

            Death();
        }
        else
        {
            anim.Play("Hurt");
        }
    }
    public void Death()
    {
        anim.Play("Death");
        isDead = true;
        Destroy(gameObject, 1.1f);
    }

    public void ReturnToIdle()
    {
        anim.Play("Idle");
    }
    public void UpdateHealthBar()
    {
        HealthBar.fillAmount = Health / MaxHealth;
        healthText.text = Health.ToString();
    }
    public void SetGameOverPanel()
    {
        ButtonPanel.SetActive(false);
        GameOverPanel.SetActive(true);
    }
}
