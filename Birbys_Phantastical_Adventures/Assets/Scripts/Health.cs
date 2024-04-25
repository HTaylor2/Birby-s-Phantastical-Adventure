using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Health : MonoBehaviour
{   
    [SerializeField] private int _maxHealth =100;
    private int _minHealth;
    private int _currentHealth;

    //public properties as getters taht we can use in other scripts
    public int MaxHealth => _maxHealth;
    public int CurrentHealth => _currentHealth;
    // Start is called before the first frame update
    void Start()
    {
        _currentHealth = _maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Damage(int damageAmount){
        _currentHealth -= damageAmount;
        if (_currentHealth < 1){
            Destroy(gameObject);
        }
    }
}
