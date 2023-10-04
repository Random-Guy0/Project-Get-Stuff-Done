using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TaskItem : MonoBehaviour
{
    [Header("Padding")]
    [SerializeField] private float paddingTop = 15f;
    [SerializeField] private float paddingBottom = 15f;

    private TMP_InputField _inputField;
    private RectTransform _rectTransform;
    private ContentSizeFitter _sizeFitter;

    private string oldText;

    private void Start()
    {
        _rectTransform = (RectTransform)transform;
        _inputField = GetComponentInChildren<TMP_InputField>();
        oldText = _inputField.text;
        _sizeFitter = _inputField.GetComponent<ContentSizeFitter>();
        _inputField.onValueChanged.AddListener(delegate(string text) { StartCoroutine(Resize(text)); });
        _inputField.onSubmit.AddListener(delegate(string text) { StartCoroutine(Resize(text)); });
    }

    private IEnumerator Resize(string text)
    {
        _inputField.SetTextWithoutNotify(oldText);
        yield return null;
        _inputField.SetTextWithoutNotify(text);
        oldText = text;
        Canvas.ForceUpdateCanvases();
        RectTransform inputFieldRect = (RectTransform)_inputField.transform;
        Vector2 size = _rectTransform.sizeDelta;
        size.y = inputFieldRect.sizeDelta.y + paddingTop + paddingBottom;
        _rectTransform.sizeDelta = size;
    }
}