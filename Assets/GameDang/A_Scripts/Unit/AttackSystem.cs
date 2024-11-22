using UnityEngine;

public class AttackSystem : MonoBehaviour
{
    private Unit _unit;
    private Rigidbody2D _rigid;
    private BoxCollider2D _collider;
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
        if (collider.tag == "Unit")
        {
            Debug.Log("Detecting "+ collider.name +"");
        }
    }
}
