using Chop8.ViewModels;
using Chop8.Models;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using DynamicData;

namespace Chop8.ViewModels
{
    public class SecurityGuardsUserControlViewModel : ViewModelBase
    {
        private SecurityGuard _selectedSecurityGuard;
        public SecurityGuard SelectedSecurityGuard
        {
            get => _selectedSecurityGuard;
            set => this.RaiseAndSetIfChanged(ref _selectedSecurityGuard, value);
        }

        private HttpClient httpClient = new HttpClient();
        private ObservableCollection<SecurityGuard> _securityGuards;
        public ObservableCollection<SecurityGuard> SecurityGuards
        {
            get => _securityGuards;
            set => this.RaiseAndSetIfChanged(ref _securityGuards, value);
        }

        private string _message;
        public string Message
        {
            get => _message;
            set => this.RaiseAndSetIfChanged(ref _message, value);
        }

        public SecurityGuardsUserControlViewModel()
        {
            httpClient.BaseAddress = new Uri("http://localhost:5068");
            Update();
        }

        public async Task Update()
        {
            var response = await httpClient.GetAsync("/securityGuards");
            if (!response.IsSuccessStatusCode)
            {
                Message = $"Ошибка сервера {response.StatusCode}";
                return;
            }
            var content = await response.Content.ReadAsStringAsync();
            if (content == null)
            {
                Message = "Пустой ответ от сервера";
                return;
            }
            SecurityGuards = JsonSerializer.Deserialize<ObservableCollection<SecurityGuard>>(content);
            Message = "";
        }

        public async Task Delete()
        {
            if (SelectedSecurityGuard == null) return;
            var response = await httpClient.DeleteAsync($"/securityGuards/{SelectedSecurityGuard.id}");
            if (!response.IsSuccessStatusCode)
            {
                Message = "Ошибка удаления со стороны сервера";
                return;
            }
            SecurityGuards.Remove(SelectedSecurityGuard);
            SelectedSecurityGuard = null;
            Message = "";
        }

        public async Task Add()
        {
            var SecurityGuard = new SecurityGuard();
            var response = await httpClient.PostAsJsonAsync($"/securityGuards", SecurityGuard);
            if (!response.IsSuccessStatusCode)
            {
                Message = "Ошибка добавления со стороны сервера";
                return;
            }
            var content = await response.Content.ReadFromJsonAsync<SecurityGuard>();
            if (content == null)
            {
                Message = "При добавлении сервер отправил пустой ответ";
                return;
            }
            SecurityGuard = content;
            SecurityGuards.Add(SecurityGuard);
            SelectedSecurityGuard = SecurityGuard;
        }

        public async Task Edit()
        {
            var response = await httpClient.PutAsJsonAsync($"/securityGuards", SelectedSecurityGuard);
            if (!response.IsSuccessStatusCode)
            {
                Message = "Ошибка изменения со стороны сервера";
                return;
            }
            var content = await response.Content.ReadFromJsonAsync<SecurityGuard>();
            if (content == null)
            {
                Message = "При изменении сервер отправил пустой ответ";
                return;
            }
            SelectedSecurityGuard = content;
        }
    }
}