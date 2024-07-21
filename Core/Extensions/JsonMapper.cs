using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Core.Extensions
{
    public static class JsonMapper
    {
        public static Y Map<T, Y>(T source)
        {
            var options = new JsonSerializerOptions
            {
                // Performans için özelleştirmeler yapılabilir
                //PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                WriteIndented = false
            };
            try
            {
                var json = JsonSerializer.Serialize(source, options);
                Y result = JsonSerializer.Deserialize<Y>(json, options);
                return result;
            }
            catch (JsonException ex)
            {
                // Loglama yapabilir veya özel bir hata yönetimi sağlayabilirsiniz.
                throw new InvalidOperationException("JSON dönüşüm hatası", ex);
            }
        }
    }

}