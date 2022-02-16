using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[ExecuteAlways]
[RequireComponent(typeof(TextMeshPro))]
public class EnemyHealthText : MonoBehaviour
{
    [SerializeField] GameObject placeholder;
    TMP_Text enemyHealthText;
    private void Awake()
    {
        enemyHealthText = GetComponent<TMP_Text>();
    }
    void Update()
    {
        transform.position = Camera.main.WorldToScreenPoint(placeholder.transform.position);
    }
    public void UpdateHealthText(float currentHP)
    {
        string newHP = currentHP.ToString();
        enemyHealthText.text = newHP + " HP";
    }
}
