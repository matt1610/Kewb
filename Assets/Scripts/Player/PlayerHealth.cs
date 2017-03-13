using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using Kewb;

public class PlayerHealth : MonoBehaviour
{
    public int startingHealth = 100;
    public int currentHealth;
    public Slider healthSlider;
    public Image damageImage;
    public AudioClip deathClip;
    public float flashSpeed = 5f;
    public Color flashColour = new Color(1f, 0f, 0f, 0.1f);

    public UpdateUI uiManager {get;set;}


    Animator anim;
    AudioSource playerAudio;
    PlayerMovement playerMovement;
    bool isDead;
    bool damaged;


    void Awake ()
    {
        uiManager = GameObject.Find ("HUDCanvas").GetComponent<UpdateUI> ();
        anim = GetComponent <Animator> ();
        // playerAudio = GetComponent <AudioSource> ();
        playerMovement = GameObject.Find ("Player").GetComponent <PlayerMovement> ();
        currentHealth = startingHealth;
    }


    void Update ()
    {
        if(damaged)
        {
            damageImage.color = flashColour;
        }
        else
        {
            damageImage.color = Color.Lerp (damageImage.color, Color.clear, flashSpeed * Time.deltaTime);
        }
        damaged = false;
    }


    public void TakeDamage (int amount)
    {
        damaged = true;

        currentHealth -= amount;

        healthSlider.value = currentHealth;

        // playerAudio.Play ();

        if(currentHealth < 0 && !isDead)
        {
            Death ();
        }
    }


    void Death ()
    {
        Debug.Log("DEAD.");
        isDead = true;

        //playerShooting.DisableEffects ();

        // anim.SetTrigger ("Die");

        // playerAudio.clip = deathClip;
        // playerAudio.Play ();

        // playerMovement.enabled = false;
        uiManager.EndGameWithText(Color.red, StringContainer.GetString(1,2));
        //playerShooting.enabled = false;
    }


    public void RestartLevel ()
    {
        Application.LoadLevel (Application.loadedLevel);
    }
}
