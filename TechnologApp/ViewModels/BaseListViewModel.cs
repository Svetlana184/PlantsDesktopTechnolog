using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using TechnologApp.Services;

namespace TechnologApp.ViewModels
{
    public abstract partial class BaseListViewModel<T> : ObservableObject where T : class, new()
    {
        [ObservableProperty]
        private ObservableCollection<T> _items = new();

        [ObservableProperty]
        private T? _selectedItem;

        [ObservableProperty]
        private bool _isLoading;

        [ObservableProperty]
        private string _searchText = string.Empty;

        [ObservableProperty]
        private string _statusMessage = string.Empty;

        protected readonly GenericApiService<T> _service;

        // Абстрактное свойство для endpoint (например, "/api/Product")
        protected abstract string Endpoint { get; }

        protected BaseListViewModel()
        {
            _service = new GenericApiService<T>(ApiClient.Instance, Endpoint);
        }

        // Общая реализация LoadAsync
        [RelayCommand]
        protected virtual async Task LoadAsync()
        {
            IsLoading = true;
            StatusMessage = "Загрузка...";

            try
            {
                var items = await _service.GetAllAsync();
                Items = new ObservableCollection<T>(items);
                StatusMessage = $"Загружено: {Items.Count}";
                foreach (var item in items)
                {
                    Console.WriteLine(item.ToString());
                }
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

        // Общая реализация AddAsync
        [RelayCommand]
        protected virtual async Task AddAsync()
        {
            if (SelectedItem == null)
            {
                SelectedItem = new T();
                return;
            }

            IsLoading = true;
            StatusMessage = "Сохранение...";

            try
            {
                if (await _service.CreateAsync(SelectedItem))
                {
                    StatusMessage = "Успешно добавлено";
                    await LoadAsync();
                }
                else
                {
                    StatusMessage = "Ошибка сохранения";
                }
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

        // Общая реализация UpdateAsync
        [RelayCommand]
        protected virtual async Task UpdateAsync()
        {
            if (SelectedItem == null) return;

            IsLoading = true;
            StatusMessage = "Обновление...";

            try
            {
                var id = GetId(SelectedItem);
                if (await _service.UpdateAsync(id, SelectedItem))
                {
                    StatusMessage = "Успешно обновлено";
                    await LoadAsync();
                }
                else
                {
                    StatusMessage = "Ошибка обновления";
                }
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

        // Общая реализация DeleteAsync
        [RelayCommand]
        protected virtual async Task DeleteAsync()
        {
            if (SelectedItem == null) return;

            IsLoading = true;
            StatusMessage = "Удаление...";

            try
            {
                var id = GetId(SelectedItem);
                if (await _service.DeleteAsync(id))
                {
                    StatusMessage = "Успешно удалено";
                    SelectedItem = default;
                    await LoadAsync();
                }
                else
                {
                    StatusMessage = "Ошибка удаления";
                }
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

        // Экспорт в Excel
        [RelayCommand]
        protected virtual async Task ExportAsync()
        {
            // var dialog = new SaveFileDialog();
            // dialog.Filters.Add(new FileDialogFilter { Name = "Excel", Extensions = { "xlsx" } });
            // var path = await dialog.ShowAsync(App.MainWindow);

            // if (path == null) return;

            // StatusMessage = "Экспорт...";

            // try
            // {
            //     ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            //     using var package = new ExcelPackage();
            //     var sheet = package.Workbook.Worksheets.Add(typeof(T).Name);

            //     var props = typeof(T).GetProperties()
            //         .Where(p => p.CanRead && p.GetMethod?.IsPublic == true)
            //         .ToArray();

            //     // Заголовки
            //     for (int i = 0; i < props.Length; i++)
            //         sheet.Cells[1, i + 1].Value = props[i].Name;

            //     // Данные
            //     for (int i = 0; i < Items.Count; i++)
            //         for (int j = 0; j < props.Length; j++)
            //             sheet.Cells[i + 2, j + 1].Value = props[j].GetValue(Items[i]);

            //     sheet.Cells.AutoFitColumns();
            //     await package.SaveAsAsync(path);
            //     StatusMessage = "Экспорт завершён";
            // }
            // catch (Exception ex)
            // {
            //     StatusMessage = $"Ошибка экспорта: {ex.Message}";
            // }
        }

        // Вспомогательный метод для получения ID
        protected virtual int GetId(T entity)
        {
            var idProperty = typeof(T).GetProperty("Id")
                ?? typeof(T).GetProperty($"{typeof(T).Name}Id")
                ?? typeof(T).GetProperty($"Id{typeof(T).Name}");

            if (idProperty == null)
                throw new InvalidOperationException($"Не найдено свойство Id для типа {typeof(T).Name}");

            return Convert.ToInt32(idProperty.GetValue(entity));
        }

        // Очистка формы
        [RelayCommand]
        protected virtual void ClearSelected()
        {
            SelectedItem = new T();
        }

        // Фильтрация (можно переопределить)
        protected virtual bool FilterItem(T item, string searchText)
        {
            if (string.IsNullOrEmpty(searchText)) return true;

            var stringProps = typeof(T).GetProperties()
                .Where(p => p.PropertyType == typeof(string));

            foreach (var prop in stringProps)
            {
                var value = prop.GetValue(item)?.ToString() ?? "";
                if (value.Contains(searchText, StringComparison.OrdinalIgnoreCase))
                    return true;
            }
            return false;
        }
    }
}