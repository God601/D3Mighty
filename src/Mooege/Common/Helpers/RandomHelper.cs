﻿/*
 * Copyright (C) 2011 mooege project
 *
 * This program is free software; you can redistribute it and/or modify
 * it under the terms of the GNU General Public License as published by
 * the Free Software Foundation; either version 2 of the License, or
 * (at your option) any later version.
 *
 * This program is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 * GNU General Public License for more details.
 *
 * You should have received a copy of the GNU General Public License
 * along with this program; if not, write to the Free Software
 * Foundation, Inc., 59 Temple Place, Suite 330, Boston, MA  02111-1307  USA
 */

using System;
using System.Linq;
using System.Collections.Generic;

namespace Mooege.Common.Helpers
{
    public class RandomHelper
    {
        private readonly static Random _random;

        static RandomHelper()
        {
            _random = new Random();
        }

        public static int Next()
        {
            return _random.Next();
        }

        public static int Next(Int32 maxValue)
        {
            return _random.Next(maxValue);
        }

        public static int Next(Int32 minValue, Int32 maxValue)
        {
            return _random.Next(minValue, maxValue);
        }

        public static void NextBytes(byte[] buffer)
        {
            _random.NextBytes(buffer);
        }

        public static double NextDouble()
        {
            return _random.NextDouble();
        }

        /*IEnumerable<TValue>*/
        public static TValue RandomValue<TKey, TValue>(IDictionary<TKey, TValue> dictionary)
        {
            List<TValue> values = Enumerable.ToList(dictionary.Values);
            int size = dictionary.Count;
            /*while (true)
            {
                yield return values[_random.Next(size)];
            }*/
            return values[_random.Next(size)];
        }
    }
}
