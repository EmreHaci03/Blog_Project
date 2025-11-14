using System;

namespace BlogProject.Helper
{
    public static class ColorHelper
    {
        // Renk listesi (sabit, sınıf düzeyinde tanımlanmalı)
        private static readonly string[] colors = new[]
        {
            "bg-primary",
            "bg-success",
            "bg-danger",
            "bg-warning",
            "bg-info",
            "bg-dark",
            "bg-secondary"
        };

        // Ana metod: Kategori adına göre sabit bir renk döndürür
        public static string GetColorByCategoryName(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                return "bg-secondary"; // varsayılan renk
            }

            int hash = Math.Abs(GetStableHashCode(name));
            int index = hash % colors.Length;
            return colors[index];
        }

        // Aynı string her zaman aynı hash değeri verir
        private static int GetStableHashCode(string str)
        {
            unchecked
            {
                int hash = 23;
                foreach (char c in str)
                {
                    hash = hash * 31 + c;
                }
                return hash;
            }
        }
    }
}
