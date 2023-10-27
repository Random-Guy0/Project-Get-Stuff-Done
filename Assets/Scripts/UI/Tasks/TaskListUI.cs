using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TaskListUI : MonoBehaviour
{
    private List<TaskItem> _taskUI;

    [SerializeField] private GameObject tasksContainer;
    [SerializeField] private TaskItem taskItemPrefab;

    private void Start()
    {
        _taskUI = new List<TaskItem>();
        List<Task> tasks = GameManager.Instance.Tasks;
        foreach (Task task in tasks)
        {
            CreateNewTaskItem(task);
        }
    }

    public void CreateNewTaskItem()
    {
        Task newTask = string.Empty;
        GameManager.Instance.Tasks.Add(newTask);
        CreateNewTaskItem(newTask);
        _taskUI[^1].SetSelected();
    }

    private void CreateNewTaskItem(Task task)
    {
        TaskItem newTaskItem = Instantiate(taskItemPrefab, tasksContainer.transform);
        newTaskItem.transform.SetSiblingIndex(tasksContainer.transform.childCount - 2);
        newTaskItem.Task = task;
        newTaskItem.Index = _taskUI.Count;
        newTaskItem.Parent = this;
        _taskUI.Add(newTaskItem);
    }

    public void DeleteTaskItem(int index)
    {
        GameManager.Instance.Tasks.RemoveAt(index);
        _taskUI.RemoveAt(index);
        for (int i = index; i < _taskUI.Count; i++)
        {
            _taskUI[i].Index--;
        }
    }
}
