using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using static UnityEditor.Progress;

public class Shar : MonoBehaviour, IPointerExitHandler, IPointerEnterHandler
{

    [SerializeField] float velosity = 1;
    [SerializeField] float agility = 1;
    [SerializeField] Canvas canvas;
    [SerializeField] TextMeshProUGUI text, timeText;
    [SerializeField] MenuBase menu;

    private bool isEnter = false;
    private float minVelosity;
    private float time = 0;

    private float W, H;
    

    private void Awake()
    {
        minVelosity = velosity;
        text.enabled = false;
        W = (transform as RectTransform).sizeDelta.x / 2;
        H = (transform as RectTransform).sizeDelta.y / 2;
    }

    private void Update()
    {
        timeText.text = ((int)time).ToString();
        ControllVelosity();
        Dvijenie();
        Pobeda();
    }

    private void Pobeda()
    {
        if(time >= 3f)
        {
            StartCoroutine(ReturnMenu());
        }
        if (Input.GetKey(KeyCode.Escape))
        {
            menu.StartScene("Menu");
        }
    }

    private IEnumerator ReturnMenu()
    {
        text.enabled = true;
        yield return new WaitForSecondsRealtime(4);
        menu.StartScene("Menu");
    }

    private void VihodZaGranitsi(ref Vector3 vector)
    {
        if (transform.position.x <= W) { vector.x = 1f; }
        if (transform.position.y <= H) { vector.y = 1f; }
        if (transform.position.x >= canvas.renderingDisplaySize.x - W) { vector.x = -1f; }
        if (transform.position.y >= canvas.renderingDisplaySize.y - H) { vector.y = -1f; }
    }

    private void ControllVelosity()
    {
        if (isEnter)
        {
            velosity += minVelosity * Time.deltaTime * agility;
            time += Time.deltaTime;
        }
        else
        {
            velosity = minVelosity;
            time = 0;
        }
    }

    private void Dvijenie()
    {
        var vectorPoint = (transform.position - Input.mousePosition).normalized;
        VihodZaGranitsi(ref vectorPoint);
        transform.position += vectorPoint * velosity;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        isEnter = false;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        isEnter = true;
    }
}
