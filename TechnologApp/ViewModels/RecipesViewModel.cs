using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Plants.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechnologApp.ViewModels
{
    public partial class RecipesViewModel : BaseListViewModel<Recipe>
    {
        protected override string Endpoint => "Recipe";

        // Дополнительное свойство для фильтрации по статусу
        [ObservableProperty]
        private string? _selectedStatus;

        // Дополнительное свойство для фильтрации по продукту
        [ObservableProperty]
        private int? _selectedProductId;

        // Список доступных статусов
        public List<string> Statuses { get; } = new() { "Черновик", "Активен", "Архив" };

        [RelayCommand]
        private async Task FilterByStatusAsync(string? status)
        {
            SelectedStatus = status;
            await LoadAsync();
        }

        protected override async Task LoadAsync()
        {
            IsLoading = true;
            StatusMessage = "Загрузка...";

            try
            {
                var items = await _service.GetAllAsync();

                // Применяем фильтрацию
                if (!string.IsNullOrEmpty(SelectedStatus))
                {
                    items = items.Where(r => r.Status == SelectedStatus).ToList();
                }

                Items = new System.Collections.ObjectModel.ObservableCollection<Recipe>(items);
                StatusMessage = $"Загружено: {Items.Count}";
            }
            catch (Exception ex)
            {
                StatusMessage = $"Ошибка: {ex.Message}";
            }
            finally
            {
                IsLoading = false;
            }
        }
    }
}
