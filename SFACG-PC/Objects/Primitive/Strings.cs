using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace SFACGPC.Objects.Primitive {
    public static class Strings {
        public static byte[] GetBytes(this string str, Encoding encoding = null) {
            return encoding == null ? Encoding.UTF8.GetBytes(str) : encoding.GetBytes(str);
        }

        public static string GetString(this byte[] data, Encoding encoding = null) {
            return encoding == null ? Encoding.UTF8.GetString(data) : encoding.GetString(data);
        }

        public static string ToJson<T>(this T obj) {
            return JsonConvert.SerializeObject(obj, new JsonSerializerSettings {
                Formatting = Formatting.Indented
            });
        }

        public static T FromJson<T>(this string src) {
            return JsonConvert.DeserializeObject<T>(src);
        }

        public static string Join<T>(this IEnumerable<T> enumerable, Func<T, string> transformer, char delimiter) {
            return string.Join(delimiter, enumerable.Select(transformer));
        }

        public static string Join(this IEnumerable<string> enumerable, char delimiter) {
            return string.Join(delimiter, enumerable);
        }

        public static bool IsNullOrEmpty(this string src) {
            return string.IsNullOrEmpty(src);
        }

        public static bool EqualsIgnoreCase(this string str1, string str2) {
            return string.Equals(str1, str2, StringComparison.OrdinalIgnoreCase);
        }

        public static bool IsNumber(this string str) {
            return int.TryParse(str, out _);
        }

        // see https://stackoverflow.com/questions/146134/how-to-remove-illegal-characters-from-path-and-filenames
        public static string FormatPath(string original) {
            return string.Concat(original.Split(Path.GetInvalidFileNameChars()));
        }

        public static string AssumeImageContentType(string fileName) {
            return fileName[^3..] switch
            {
                "png" => "image/png",
                "jpg" => "image/jpeg",
                "jpeg" => "image/jpeg",
                "gif" => "image/gif",
                _ => "image/jpeg"
            };
        }

        public static string Hash<T>(this string str) where T : HashAlgorithm, new() {
            using var crypt = new T();
            var hashBytes = crypt.ComputeHash(str.GetBytes());
            return hashBytes.Select(b => b.ToString("x2")).Aggregate((s1, s2) => s1 + s2);
        }
    }
}
