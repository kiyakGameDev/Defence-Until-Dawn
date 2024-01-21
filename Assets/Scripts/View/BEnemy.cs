using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VUD_Project.Data;
using VUD_Project.User;

namespace VUD_Project.View
{
    public class BEnemy : Enemy
    {

        private void Awake()
        {
           
            UserInterface = GameObject.FindGameObjectWithTag("UserInterface").GetComponent<UserInterface>();
            player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
            manager = GameObject.FindGameObjectWithTag("manager").GetComponent<Manager>();  
            
        }

        private void Start()
        {
            animator = GetComponent<Animator>();


            FindRoadsByTag();
            ReSizeTargetPoint();

            currentHealth = maxHealth;
            dead = false;

           

        }
        private void OnEnable()
        {
            Actions.OnEnemyDie += WhenEnemyDie;
        }
        private void OnDisable()
        {
            Actions.OnEnemyDie -= WhenEnemyDie;
        }
        private void Update()
        {
            if (!dead)
            {
                Move();
                Die();
            }
           

        }


        

    }



}


