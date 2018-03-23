using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IFireble
{
    void Fire(Vector3 direction);
    float GetDamage();
}

public interface IDamageble
{
	void Damage(float damage);
}