using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VUD_Project.Data;
using VUD_Project.View;

namespace VUD_Project.User
{
    public enum WeaponType {pistol,rifle,uzi}  
    public class Turret : MonoBehaviour
    {
        //Settings
        public List<Transform> enemyList = new List<Transform>(); 
        public WeaponType type;   
        public float menzil = 200f;
        public float cooldownPiastol = 5f;
        public float cooldownRifle = 3f;
        public float cooldownUzi = 2f;

        public int damagePistol = 10;
        public int damageRifle = 20;
        public int damageUzi = 30;




        //value
        public Transform closestEnemy;
        public float timer;
        public void ReArrangeEnemyList()
        {
            enemyList.Clear();

            GameObject[] enemies = GameObject.FindGameObjectsWithTag("enemy");

            foreach (GameObject enemy in enemies)
            {
                enemyList.Add(enemy.transform);
            }


        }


        public void ReDirectClosestEnemy()  
        {
            closestEnemy = null;

            float closestDistance = Mathf.Infinity;

            Vector3 towerPosition = transform.position;

            foreach (Transform target in enemyList)
            {
                float distance = Vector3.Distance(towerPosition, target.position);

                if (distance < closestDistance)
                {
                    closestDistance = distance;
                    closestEnemy = target;
                }
            }

            if (closestEnemy != null)
            {
                Vector3 hedefYon = closestEnemy.position - towerPosition;
                Quaternion yeniRotasyon = Quaternion.LookRotation(hedefYon);
                transform.rotation = Quaternion.Lerp(transform.rotation, yeniRotasyon, Time.deltaTime * 20f);
            }
        }
        public void Shoot()
        {
            if (this.type == WeaponType.pistol)
            {
                if (!closestEnemy.GetComponent<BEnemy>().GetDeadValue())
                {
                    Effects.FireParticleEffect(closestEnemy.GetComponent<BEnemy>().transform);
                    Effects.PlayShootSound();
                    int CH = closestEnemy.GetComponent<BEnemy>().GetCurrentHealth();
                    CH  -= damagePistol;
                    closestEnemy.GetComponent<BEnemy>().SetCurrentHealth(CH);
                    
                }
            }
            if (this.type == WeaponType.rifle)
            {
                if (!closestEnemy.GetComponent<BEnemy>().GetDeadValue())
                {
                    Effects.FireParticleEffect(closestEnemy.GetComponent<BEnemy>().transform);
                    Effects.PlayShootSound();

                    int CH = closestEnemy.GetComponent<BEnemy>().GetCurrentHealth();
                    CH -= damageRifle;
                    closestEnemy.GetComponent<BEnemy>().SetCurrentHealth(CH);

                }
            }
            if (this.type == WeaponType.uzi)
            {
                if (!closestEnemy.GetComponent<BEnemy>().GetDeadValue())
                {
                    Effects.FireParticleEffect(closestEnemy.GetComponent<BEnemy>().transform);
                    Effects.PlayShootSound();
                    int CH = closestEnemy.GetComponent<BEnemy>().GetCurrentHealth();
                    CH -= damageUzi;
                    closestEnemy.GetComponent<BEnemy>().SetCurrentHealth(CH);

                }
            }
        }
        public void ControlShootConditions()
        {
            if (closestEnemy != null)
            {
                if (Vector3.Distance(transform.position, closestEnemy.position) < menzil)
                {
                    timer += Time.deltaTime;
                    if (this.type == WeaponType.pistol)
                    {
                        if (timer > cooldownPiastol)
                        {
                            Shoot();
                            timer = 0;
                        }
                    }
                    if (this.type == WeaponType.rifle)
                    {
                        if (timer > cooldownRifle)
                        {
                            Shoot();
                            timer = 0f;
                        }
                    }
                    if (this.type == WeaponType.uzi)
                    {
                        if (timer > cooldownUzi)
                        {
                            Shoot();
                            timer = 0f;
                        }
                    }
                }
            }
        }
        public void ArrangeEnumValues()
        {
            if (this.tag == "pistol")
                type = WeaponType.pistol;
            if (this.tag == "rifle")
                type = WeaponType.rifle;
            if (this.tag == "uzi")
                type = WeaponType.uzi;
        }

    }

}
