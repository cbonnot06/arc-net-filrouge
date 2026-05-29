using CommunityToolkit.Mvvm.Input;
using TechProShop.TechProQuote.MAUIApp.Models;

namespace TechProShop.TechProQuote.MAUIApp.PageModels
{
    public interface IProjectTaskPageModel
    {
        IAsyncRelayCommand<ProjectTask> NavigateToTaskCommand { get; }
        bool IsBusy { get; }
    }
}