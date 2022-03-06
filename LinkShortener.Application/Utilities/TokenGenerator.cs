﻿using System;
using System.Linq;

namespace LinkShortener.Application.Utilities
{
    public class TokenGenerator
    {
        public static string Generate()
        {
            string random = string.Empty;
            Enumerable.Range(48, 75)
                .Where(i => i < 58 || i > 64 && i < 91 || i > 96)
                .OrderBy(o => new Random().Next())
                .ToList()
                .ForEach(i => random += Convert.ToChar(i));

            return random.Substring(new Random().Next(0, random.Length - 8), 8);
        }
    }
}