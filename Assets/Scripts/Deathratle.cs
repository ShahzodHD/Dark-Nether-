using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deathratle : MonoBehaviour
{
    public AudioSource myFx;

    public AudioClip deathPlayer;
    [Header("Предсмертный хрип")]
    public AudioClip demon;
    public AudioClip spider;
    public AudioClip girl;
    public AudioClip trent;
    public AudioClip chel;
    public AudioClip dog;
    [Header("Звук Удара")]
    public AudioClip attackDemon;
    public AudioClip attackSpider;
    public AudioClip attackGirl;
    public AudioClip attackTrent;
    public AudioClip attackChel;
    public AudioClip attackDog;
    [Header("Звуки шайтана")]
    public AudioClip deathDevil;
    public AudioClip deathDevil1;
    public AudioClip attackDevil;
    public AudioClip attackLegDevil;
    public AudioClip attackHead;
    public void DeathPlayer()
    {
        myFx.PlayOneShot(deathPlayer);
    }
    public void Demon()
    {
        myFx.PlayOneShot(demon);
    }
    public void Spider()
    {
        myFx.PlayOneShot(spider);
    }
    public void Girl()
    {
        myFx.PlayOneShot(girl);
    }
    public void Trent()
    {
        myFx.PlayOneShot(trent);
    }
    public void Chel()
    {
        myFx.PlayOneShot(chel);
    }
    public void Dog()
    {
        myFx.PlayOneShot(dog);
    }
    public void AttackDemon()
    {
        myFx.PlayOneShot(attackDemon);
    }
    public void AttackSpider()
    {
        myFx.PlayOneShot(attackSpider);
    }
    public void AttackGirl()
    {
        myFx.PlayOneShot(attackGirl);
    }
    public void SoundAttackTrent()
    {
        myFx.PlayOneShot(attackTrent);
    }
    public void SoundAttackChel()
    {
        myFx.PlayOneShot(attackChel);
    }
    public void SoundAttackDog()
    {
        myFx.PlayOneShot(attackDog);
    }

    //Звуки босса

    public void SoundDeathDevil()
    {
        myFx.PlayOneShot(deathDevil);
    }
    public void SoundDeathDevil1()
    {
        myFx.PlayOneShot(deathDevil1);
    }
    public void SoundAttackDevil()
    {
        myFx.PlayOneShot(attackDevil);
    }
    public void SoundAttackLegDevil()
    {
        myFx.PlayOneShot(attackLegDevil);
    }
    public void SoundAttackHeadDevil()
    {
        myFx.PlayOneShot(attackHead);
    }
}
