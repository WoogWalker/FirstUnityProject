using UnityEngine;
public class Bullet : MonoBehaviour, IFireble // : - extends | MonoBehaviour - базовый класс всех компонентов | через запятую implements
{

    public float damage = 100;
    public Vector3 direction = Vector3.one; //  Vector3.one  means  x=1 y=1 z=1

    public void Fire(Vector3 direction)
    {
        Rigidbody rigidbody =  GetComponent<Rigidbody>(); // берем компонент с текущего объекта (GameObject, его не видно)
        rigidbody.AddForce(direction);
    
    }

    public float GetDamage()
    {
        return damage;
    }

    public void Fire(){
        Fire(direction);
    }


    void OnCollisionEnter(Collision other) // other - любой объект с которым столкнулся
    {
       IDamageble damageble = other.gameObject.GetComponent<IDamageble>(); // gameObject - объект (куб, стена)
       if(damageble != null){
           damageble.Damage(GetDamage());
       }
    }
}