using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class CharacterStats : MonoBehaviour {
  public int level;

  [Space]
  public int currHealth, maxHealth;

  [Space]
  public int currMana, maxMana;

  [Space]
  public int currXp, maxXp;

  [Space]
  public int strength, intelligence, speed, dexterity;

  public Slider healthBar;
  public Slider manaBar;
  public Slider xpBar;

  public TextMeshProUGUI HpSliderValue;
  public TextMeshProUGUI MpSliderValue;
  public TextMeshProUGUI XpSliderValue;
  // Start is called before the first frame update
  void Start() {

  }

  // Update is called once per frame
  void Update() {
    ChangeSliderUI();
  }

  public void ChangeSliderUI() {
    healthBar.value = currHealth;
    manaBar.value = currMana;
    xpBar.value = currXp;

    healthBar.maxValue = maxHealth;
    manaBar.maxValue = maxMana;
    xpBar.maxValue = maxXp;

    HpSliderValue.text = currHealth + " / " + maxHealth;
    MpSliderValue.text = currMana + " / " + maxMana;
    XpSliderValue.text = currXp + " / " + maxXp;
  }
}
