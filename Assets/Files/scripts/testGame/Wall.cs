using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Wall : MonoBehaviour, IDamageble
{
	public float HP = 1000;

	public float animationDuration = 0.2f;

	// глобальные переиенные
	Color originalColor;
    new MeshRenderer renderer; // компонент, который рисует 3D модель

	void Awake()
	{
		renderer = GetComponent<MeshRenderer>(); // достаем компонент из текущего объекта 
		originalColor = renderer.material.color; // у вызванного компонента берем цвет материала
	}
    public void Damage(float damage)
    {
        HP -= damage;
		
		renderer.material.DOColor(Color.red, animationDuration)
			.OnComplete(() => renderer.material.DOColor(originalColor, animationDuration)); // в лямбде красится обратно в оригинал
    }
}
