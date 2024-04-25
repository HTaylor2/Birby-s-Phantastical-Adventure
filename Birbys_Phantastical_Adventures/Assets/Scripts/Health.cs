using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Health : MonoBehaviour
{   
    public GameObject[] hearts;
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
        if (_currentHealth < 1){
            Destroy(hearts[0].gameObject);
        }else if (_currentHealth<2){    
            Destroy(hearts[1].gameObject);
        }else if (_currentHealth<3){    
            Destroy(hearts[2].gameObject);
        }else if (_currentHealth<4){    
            Destroy(hearts[3].gameObject);
        }
        if (_currentHealth <= 0){
            Destroy(gameObject);
        }
    }

    public void Heal(int health){
        _currentHealth += health;
        if (_currentHealth >= _maxHealth){
            _currentHealth=_maxHealth;
        }else{
            
        }
    }
}
