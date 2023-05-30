using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FloatingBar : MonoBehaviour {
  [SerializeField] private Slider slider;
  [SerializeField] private Camera cam;
  [SerializeField] private Transform target;
  [SerializeField] private Vector3 offset;

  public void Awake() {
    slider = GetComponent<Slider>();
    cam = GameObject.Find("Main Camera").GetComponent<Camera>();
    target = gameObject.transform.parent.gameObject.transform.parent.gameObject.transform;
  }

  public void UpdateBar(float currentValue, float maxValue) {
    slider.value = currentValue / maxValue;
  }

  public void Update() {
    transform.rotation = cam.transform.rotation;
    transform.position = target.position + offset;
  }
}
