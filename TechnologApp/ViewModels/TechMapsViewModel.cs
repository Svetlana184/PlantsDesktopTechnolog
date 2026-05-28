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
    public partial class TechMapsViewModel : BaseListViewModel<TechMap>
    {
        protected override string Endpoint => "TechMap";

        // Дополнительное свойство для фильтрации по статусу
        [ObservableProperty]
        private string? _selectedStatus;

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
                    items = items.Where(t => t.Status == SelectedStatus).ToList();
                }

                Items = new System.Collections.ObjectModel.ObservableCollection<TechMap>(items);
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

        // Активировать карту
        [RelayCommand]
        private async Task ActivateAsync()
        {
            if (SelectedItem == null) return;

            SelectedItem.Status = "Активен";
            await UpdateAsync();
        }

        // Архивировать карту
        [RelayCommand]
        private async Task ArchiveAsync()
        {
            if (SelectedItem == null) return;

            SelectedItem.Status = "Архив";
            await UpdateAsync();
        }
    }
}
