using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VUD_Project.Data
{
    public static class Effects
    {
        public static GameObject greenParticle;
        public static GameObject redParticle;
        public static GameObject fireParticle;
        public static GameObject turretPutParticle;
        public static List <GameObject> particles = new List <GameObject> ();
        public static GameObject goldPrefab;
        public static GameObject goldSprite;
        public static GameObject producedGold;


        public static AudioSource source;
        public static AudioClip mouseClick;
        public static AudioClip errorSound;
        public static AudioClip putSound;
        public static AudioClip shootSound;
        public static AudioClip coinSound;
        public static void InsGreenSlotParticle(Transform target)
        {
            greenParticle = Resources.Load<GameObject>("Particle/Green");
            GameObject particle=GameObject.Instantiate(greenParticle, target.position, target.rotation);
            particles.Add(particle);
        }
        public static void InsRedSlotParticle(Transform target)
        {
            redParticle = Resources.Load<GameObject>("Particle/Red");
            GameObject particle=GameObject.Instantiate(redParticle, target.position, target.rotation);  
            particles.Add(particle);
        }
        public static void KillAllParticles()
        {
            foreach (GameObject particle in particles)
            {
               GameObject.Destroy(particle);
            }
        }

        public static void FireParticleEffect(Transform target)
        {
            fireParticle = Resources.Load<GameObject>("Particle/Fire");
            GameObject particle=GameObject.Instantiate(fireParticle, target.position, target.rotation);
            GameObject.Destroy(particle, 1f);
        }

        public static void TurretPutParticle(Transform target)
        {
            turretPutParticle = Resources.Load<GameObject>("Particle/TurretPutParticle");
            GameObject particle =GameObject.Instantiate(turretPutParticle, target.position, target.rotation);
            GameObject.Destroy(particle, 1f);
        }


        public static void InsGoldPrefab(Transform target)
        {
            goldPrefab = Resources.Load<GameObject>("Gold/Coin");
            goldSprite = GameObject.FindGameObjectWithTag("goldSprite");
            producedGold =GameObject.Instantiate(goldPrefab, new Vector3(target.position.x, 10f, target.position.z), target.rotation);
            producedGold.transform.LookAt(Camera.main.transform);
            
            producedGold.transform.DOMove(new Vector3(goldSprite.transform.position.x, goldSprite.transform.position.y,0), 100f).OnComplete(() => GameObject.Destroy(producedGold));
        }

       

       
        public static void PlayMouseClick()
        {
            source = GameObject.FindGameObjectWithTag("source").GetComponent<AudioSource>();
            mouseClick = Resources.Load<AudioClip>("Sounds/mouseClick");
            source.PlayOneShot(mouseClick);
        }
        public static void PlayErrorSound()
        {
            source = GameObject.FindGameObjectWithTag("source").GetComponent<AudioSource>();
            errorSound = Resources.Load<AudioClip>("Sounds/error");
            source.PlayOneShot(errorSound);
        }
        public static void PlayPutSound()
        {
            source = GameObject.FindGameObjectWithTag("source").GetComponent<AudioSource>();
            putSound = Resources.Load<AudioClip>("Sounds/put");
            source.PlayOneShot(putSound);
        }
        public static void PlayShootSound()
        {
            source = GameObject.FindGameObjectWithTag("source").GetComponent<AudioSource>();
            shootSound = Resources.Load<AudioClip>("Sounds/shoot");
            source.PlayOneShot(shootSound);
        }
        public static void PlayCoinSound()
        {
            source = GameObject.FindGameObjectWithTag("source").GetComponent<AudioSource>();
            coinSound = Resources.Load<AudioClip>("Sounds/coin");
            source.PlayOneShot(coinSound);
        }

    }
}

