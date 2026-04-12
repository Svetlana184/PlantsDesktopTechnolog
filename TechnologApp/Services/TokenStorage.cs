using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace TechnologApp.Services
{
    public static class TokenStorage
    {
        // private static readonly string TokenPath = Path.Combine(
        //     Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
        //     "PlantsDesktop", "token.json");

        // public static void SaveToken(string token)
        // {
        //     var dir = Path.GetDirectoryName(TokenPath);
        //     if (!Directory.Exists(dir)) Directory.CreateDirectory(dir!);

        //     var data = new { Token = token, SavedAt = DateTime.UtcNow };
        //     File.WriteAllText(TokenPath, JsonSerializer.Serialize(data));
        //     ApiClient.SetToken(token);
        // }

        // public static string? LoadToken()
        // {
        //     if (!File.Exists(TokenPath)) return null;

        //     var json = File.ReadAllText(TokenPath);
        //     var data = JsonSerializer.Deserialize<TokenData>(json);
        //     if (data != null) ApiClient.SetToken(data.Token);
        //     return data?.Token;
        // }

        // public static void ClearToken()
        // {
        //     if (File.Exists(TokenPath)) File.Delete(TokenPath);
        //     ApiClient.ClearToken();
        // }

        private class TokenData
        {
            public string Token { get; set; } = string.Empty;
            public DateTime SavedAt { get; set; }
        }
    }
}