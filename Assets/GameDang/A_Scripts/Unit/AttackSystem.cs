using UnityEngine;

public class AttackSystem : MonoBehaviour
{
    private Unit _unit;
    public void SetUnit(Unit unit)
    {
        _unit = unit;

        Debug.Log("공격 시스템 뿌슝빠슝");
    }

    private void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        Debug.Log("Trigger");
    }
}
