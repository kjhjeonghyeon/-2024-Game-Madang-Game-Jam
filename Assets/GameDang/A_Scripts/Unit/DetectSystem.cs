using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DetectSystem : MonoBehaviour
{
    private Unit _unit;
    private Rigidbody2D _rigid;
    private BoxCollider2D _collider;
    public HashSet<IHit> targets = new HashSet<IHit>();

    private void Awake()
    {        
        _rigid = GetComponent<Rigidbody2D>();
        _collider = GetComponent<BoxCollider2D>();
    }
    public void SetUnit(Unit unit)
    {
        _unit = unit;
        _collider.size = new Vector2(unit.Range, 1);
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "Unit" || collider.tag == "Tower")
        {
            IHit target = collider.GetComponent<IHit>();
            if (target.GetTower() != _unit.Owner)
                targets.Add(target);
        }
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.tag == "Unit" || collider.tag == "Tower")
        {
            IHit target = collider.GetComponent<IHit>();
            if (targets.Contains(target))
                targets.Remove(target);
        }
    }
}
