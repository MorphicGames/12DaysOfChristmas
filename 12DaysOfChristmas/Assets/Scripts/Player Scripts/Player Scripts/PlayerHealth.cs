﻿using UnityEngine;
using System.Collections;

[RequireComponent(typeof(SphereCollider))]
public class PlayerHealth : MonoBehaviour {

    public const int maxHealth = 100;
    public int health = 0;

	// Use this for initialization
	void Start () {
        health = maxHealth;
	}

    // Snowmen enemies entering the sphere trigger collider
    void OnTriggerEnter(Collider c) {
        if (c.gameObject.tag == "Enemy") {
            TakeDamage(10);
        }
    }

    // Take damage from trigger entrances or stays
    public void TakeDamage(int _d) {
        health -= _d;
        Debug.Log(health);
        if (health <= 0) {
            health = 0;
            Debug.Log("Dead");
        }
    }

    // Call this to heal the player from an external script
    // i.e. Health Power Ups
    public void Heal(int _h) {
        health += _h;

        if (health >= maxHealth) {
            health = maxHealth;
        }
    }
}
