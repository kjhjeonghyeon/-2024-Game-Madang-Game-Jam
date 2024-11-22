using UnityEngine;

public interface IHit
{
    public void Hit(int damage);    
    public Tower GetTower();
}