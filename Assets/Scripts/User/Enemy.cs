using System.Collections.Generic;
using UnityEngine;
using VUD_Project.Data;
using VUD_Project.View;

namespace VUD_Project.User
{
    public class Enemy : MonoBehaviour
    {
        //Connections
        protected UserInterface UserInterface;
        protected Player player;
        protected Manager manager;

        //Settings
        protected int maxHealth = 50;
        public List <Transform> roadPoints = new List<Transform>();
        protected Transform enemyRoadOne, enemyRoadTwo, enemyRoadThree, enemyRoadFour;
        protected Animator animator;
        

        //Value
        protected int currentHealth;
        protected int attack_damage;
        protected int walk_speed = 7;
        protected int Index = 0;
        protected Transform targetPoint;
        protected bool dead;


        public void FindRoadsByTag()
        {
            Transform road0 = GameObject.FindGameObjectWithTag("ER1").transform;

            roadPoints.Add(road0);

            Transform road1 = GameObject.FindGameObjectWithTag("ER2").transform;

            roadPoints.Add(road1);

            Transform road2 = GameObject.FindGameObjectWithTag("ER3").transform;

            roadPoints.Add(road2);

            Transform road3 = GameObject.FindGameObjectWithTag("ER4").transform;

            roadPoints.Add(road3);
        }
        public bool GetDeadValue()
        {
            return dead;
        }
        public int GetCurrentHealth()
        {
            return currentHealth;
        }
        public void SetCurrentHealth(int value)
        {
            currentHealth = value;
        }
        public void Move()
        {
            if (Index < roadPoints.Count)
            {
                Vector3 hedefYon = roadPoints[Index].position - transform.position;
                transform.Translate(hedefYon.normalized * walk_speed * Time.deltaTime, Space.World);
                transform.LookAt(roadPoints[Index].position);
                Walk();

                if (Vector3.Distance(transform.position, roadPoints[Index].position) < 0.1f)
                {
                    Index++;
                    ReSizeTargetPoint();
                }
            }
            else
            {
                Attack();
            }
        }
        public void ReSizeTargetPoint()
        {
            if (Index < roadPoints.Count)
            {
                targetPoint = roadPoints[Index];
            }
        }
        public void Walk()
        {
            animator.SetBool("Run", true);
        }
        public void Attack()
        {
            animator.SetBool("Attack", true);
        }
        public void AttackFunc()
        {
            attack_damage = 3;
            Player player = GameObject.FindGameObjectWithTag("Player").GetComponent<BPlayer>();
            player.ChangeHealth(attack_damage);

        }
        public void Die()
        {
            if (currentHealth <= 0 && !dead)
            {
                Actions.OnEnemyDie();
            }
        }
        public void WhenEnemyDie()
        {
            dead = true;
            Effects.PlayCoinSound();    
            Effects.InsGoldPrefab(this.transform);
            UserInterface.SetGoldQuantity(player.GetGold() + 10);
            player.SetGold(player.GetGold() + 10);
            manager.SetWaveBoolValue(true);
            animator.SetBool("Die", true);
            Destroy(this.gameObject, 1f);

            
            
        }

       



    }
}
