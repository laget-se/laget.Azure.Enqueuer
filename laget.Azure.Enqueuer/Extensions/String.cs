﻿using System;
using System.Text;

namespace laget.azure_enqueueuer.Extensions
{
    public static class StringExtensions
    {
        public static string ToBase64(this string @string)
        {
            return Convert.ToBase64String(Encoding.UTF8.GetBytes(@string));
        }
    }
}
