using Grand.Business.Core.Interfaces.System.ScheduleTasks;
using Grand.Data;
using Grand.Domain.Tasks;

namespace Grand.Module.ScheduledTasks.BackgroundServices;

/// <summary>
///     Task service
/// </summary>
public class ScheduleTaskService : IScheduleTaskService
{
    #region Fields

    private readonly IRepository<ScheduleTask> _taskRepository;

    #endregion

    #region Ctor

    public ScheduleTaskService(IRepository<ScheduleTask> taskRepository)
    {
        _taskRepository = taskRepository;
    }

    #endregion

    /// <summary>
    ///     Gets a task
    /// </summary>
    /// <param name="taskId">Task identifier</param>
    /// <returns>Task</returns>
    public virtual Task<ScheduleTask> GetTaskById(string taskId)
    {
        return _taskRepository.GetByIdAsync(taskId);
    }

    /// <summary>
    ///     Gets a task by its name
    /// </summary>
    /// <returns>Task</returns>
    public virtual async Task<ScheduleTask> GetTaskByName(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
            return null;

        var task = _taskRepository.Table.FirstOrDefault(x => x.ScheduleTaskName == name);
        return await Task.FromResult(task);
    }

    /// <summary>
    ///     Gets all tasks
    /// </summary>
    /// <returns>Tasks</returns>
    public virtual async Task<IList<ScheduleTask>> GetAllTasks()
    {
        return await Task.FromResult(_taskRepository.Table.ToList());
    }

    /// <summary>
    ///     Insert the task
    /// </summary>
    /// <param name="task">Task</param>
    public virtual async Task<ScheduleTask> InsertTask(ScheduleTask task)
    {
        ArgumentNullException.ThrowIfNull(task);

        return await _taskRepository.InsertAsync(task);
    }

    /// <summary>
    ///     Updates the task
    /// </summary>
    /// <param name="task">Task</param>
    public virtual async Task UpdateTask(ScheduleTask task)
    {
        ArgumentNullException.ThrowIfNull(task);

        await _taskRepository.UpdateAsync(task);
    }

    /// <summary>
    ///     Delete the task
    /// </summary>
    /// <param name="task">Task</param>
    public virtual async Task DeleteTask(ScheduleTask task)
    {
        ArgumentNullException.ThrowIfNull(task);

        await _taskRepository.DeleteAsync(task);
    }
}