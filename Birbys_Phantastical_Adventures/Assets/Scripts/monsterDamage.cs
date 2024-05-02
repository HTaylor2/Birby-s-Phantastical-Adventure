using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class monsterDamage : MonoBehaviour
{
    public int damage;
    public Health playerHealth;
    private int _currentHealth;
    [SerializeField]
    private int _maxHealth;
    private float delay = 2f;

    // Start is called before the first frame update

    void Start()
    {
        _currentHealth = _maxHealth;
    }
    private void OnCollisionEnter2D(Collision2D collision){
        if(collision.gameObject.tag == "Player"){
            playerHealth.Damage(damage);
        }
        if(collision.gameObject.tag == "Bullet"){
            Damage(1);
        }
    }

    public void Damage(int damageAmount){
        _currentHealth -= damageAmount;
        if (_currentHealth <= 0){
            if(gameObject.CompareTag("Boss")){
                StartCoroutine(Win());
                }
                else{Destroy(gameObject);}
    }
}

    private IEnumerator Win()
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(3);
        Destroy(gameObject);
    }
}
