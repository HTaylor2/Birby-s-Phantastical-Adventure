using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
//using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{   
    [SerializeField] private GameObject[] hearts;
    private int heartHealth;
    [SerializeField] private int _maxHealth =4;
    
    public int _currentHealth;

    //public properties as getters taht we can use in other scripts

    // Start is called before the first frame update
    void Start()
    {
        _currentHealth = _maxHealth;
    }


    public void Damage(int damageAmount){
        _currentHealth -= damageAmount;
        if (_currentHealth <= 0){
            hearts[0].gameObject.SetActive(false);
            StartCoroutine(Death(0.1f));
        }
        else{
            for(int i = _maxHealth-1; i >=_currentHealth; i--){
                hearts[i].gameObject.SetActive(false);
            }
        }
    }

    IEnumerator Death(float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(2);
    }

    public void Heal(int health){
        _currentHealth += health;
        if (_currentHealth >= _maxHealth){
            _currentHealth=_maxHealth;
        }
        for(int i = 0; i<_currentHealth; i++){
                hearts[i].gameObject.SetActive(true);
            }
    }
}
