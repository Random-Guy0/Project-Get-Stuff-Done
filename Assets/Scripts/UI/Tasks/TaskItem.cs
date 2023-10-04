using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TaskItem : MonoBehaviour
{
    private Task _task;
    public Task Task
    {
        get
        {
            _task |= _inputField.text;
            return _task;
        }
        set
        {
            _task = value;
            _inputField.text = _task;
        }
    }
    
    public int Index { get; set; }
    public TaskListUI Parent { private get; set; }
    
    [Header("Padding")]
    [SerializeField] private float paddingTop = 15f;
    [SerializeField] private float paddingBottom = 15f;

    private TMP_InputField _inputField;
    private RectTransform _rectTransform;

    private string _oldText;

    private void Awake()
    {
        _rectTransform = (RectTransform)transform;
        _inputField = GetComponentInChildren<TMP_InputField>();
        _oldText = _inputField.text;
        _inputField.onValueChanged.AddListener(delegate(string text) { StartCoroutine(UpdateTask(text)); });
        _inputField.onSubmit.AddListener(delegate(string text) { StartCoroutine(UpdateTask(text)); });
    }

    private IEnumerator UpdateTask(string text)
    {
        //resize ui
        Color caretColour = _inputField.caretColor;
        float caretAlpha = caretColour.a;
        caretColour.a = 0f;
        _inputField.caretColor = caretColour;
        bool increased = text.Length > _oldText.Length;
        _inputField.SetTextWithoutNotify(_oldText);
        yield return null;
        _inputField.SetTextWithoutNotify(text);
        _oldText = text;
        Canvas.ForceUpdateCanvases();
        RectTransform inputFieldRect = (RectTransform)_inputField.transform;
        Vector2 size = _rectTransform.sizeDelta;
        size.y = inputFieldRect.sizeDelta.y + paddingTop + paddingBottom;
        _rectTransform.sizeDelta = size;

        if (increased)
        {
            _inputField.caretPosition++;
        }

        caretColour.a = caretAlpha;
        _inputField.caretColor = caretColour;
        
        //update in GameManager
        GameManager.Instance.Tasks[Index] = Task;
    }

    public void Delete()
    {
        Parent.DeleteTaskItem(Index);
        Destroy(gameObject);
    }

    public void SetSelected()
    {
        _inputField.Select();
    }
}