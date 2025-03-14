using System.Collections;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxLifePoints = 5;
    public int currentLifePoints = 5;
    public bool isInvulnerable = false;
    public float invulnerableTime = 2.25f;
    public float invulnerableFlash = 0.2f;
    public SpriteRenderer sr;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentLifePoints = maxLifePoints;
    }
    public void Hurt(int damage = 1) {
            if (isInvulnerable) {
                return ;
            }
            
            currentLifePoints = currentLifePoints - damage;  
            if (currentLifePoints <= 0) {
            Debug.Log("You died pov naze");
            Destroy(gameObject);
        }  else {
            StartCoroutine(Invulnerable());
        }
    }

    IEnumerator Invulnerable() {
        isInvulnerable = true;
        Color startColor = sr.color;
        WaitForSeconds invulnerableFlashWait = new WaitForSeconds(invulnerableFlash);
        for (float i = 0f; i <= invulnerableTime; i+=invulnerableFlash) {
            if(sr.color.a == 1) {
                sr.color = Color.clear;
            } else {
                sr.color = startColor;
            }
            yield return invulnerableFlashWait;
        }
        
        isInvulnerable = false;
        sr.color = startColor;
        yield return null;   
    }
    // Update is called once per frame
    void Update()
    {
       
    }
}
