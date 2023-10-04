public struct Task
{
    private string _task;

    public Task(string task)
    {
        _task = task;
    }

    public static implicit operator Task(string task)
    {
        return new Task(task);
    }
    
    //planned for possible future expansion of this class
    public static Task operator |(Task t, string s)
    {
        t._task = s;
        return t;
    }

    public static Task operator |(Task t, Task other)
    {
        t._task = other._task;
        return t;
    }

    public static implicit operator string(Task t)
    {
        return t._task;
    }

    public override string ToString()
    {
        return _task;
    }
}