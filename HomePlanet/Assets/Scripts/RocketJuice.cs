﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketJuice : MonoBehaviour
{
    ParticleSystem[] particles;
    private const int DECAY_FACTOR = 1;
    private const int GROWTH_FACTOR = DECAY_FACTOR * 2;

    private int tester = 0;

    private void Start()
    {
        particles = GetComponentsInChildren<ParticleSystem>();
        Debug.Log($"AHAHRHAHH SIZE IS {particles.Length}");
    }

    private void Update()
    {
        DecreaseRocketAnimation();
        /* // Test code with this
        if(tester < 360)
            tester++;
        else
            IncreaseRocketAnimation();
        */
    }

    public void IncreaseRocketAnimation()
    {
        foreach(ParticleSystem particle in particles)
        {
            Color32 currentColor = particle.startColor;
            if (currentColor.a >= 255 - GROWTH_FACTOR)
                currentColor.a = 255;
            else
                currentColor.a += GROWTH_FACTOR;
            particle.startColor = currentColor;
        }
    }

    public void DecreaseRocketAnimation()
    {
        foreach(ParticleSystem particle in particles)
        {
            Color32 currentColor = particle.startColor;
            if (currentColor.a <= DECAY_FACTOR)
                currentColor.a = 0;
            else
                currentColor.a -= DECAY_FACTOR;
            particle.startColor = currentColor;
        }
    }

    public void DecreaseRocketAnimationALargeAmountMyGoodSir()
    {
        // I'm the for loop now
        DecreaseRocketAnimation();
        DecreaseRocketAnimation();
        DecreaseRocketAnimation();
        DecreaseRocketAnimation();
        DecreaseRocketAnimation();
    }
}