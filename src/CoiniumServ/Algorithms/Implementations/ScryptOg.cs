﻿#region License
// 
//     CoiniumServ - Crypto Currency Mining Pool Server Software
//     Copyright (C) 2013 - 2014, CoiniumServ Project - http://www.coinium.org
//     http://www.coiniumserv.com - https://github.com/CoiniumServ/CoiniumServ
// 
//     This software is dual-licensed: you can redistribute it and/or modify
//     it under the terms of the GNU General Public License as published by
//     the Free Software Foundation, either version 3 of the License, or
//     (at your option) any later version.
// 
//     This program is distributed in the hope that it will be useful,
//     but WITHOUT ANY WARRANTY; without even the implied warranty of
//     MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//     GNU General Public License for more details.
//    
//     For the terms of this license, see licenses/gpl_v3.txt.
// 
//     Alternatively, you can license this software under a commercial
//     license or white-label it as set out in licenses/commercial.txt.
// 
#endregion

using System;
using CryptSharp.Utility;

namespace CoiniumServ.Algorithms.Implementations
{
    public sealed class ScryptOg : HashAlgorithmBase
    {
        /// <summary>
        /// N parameter - CPU/memory cost parameter.
        /// </summary>
        private readonly int _n;

        /// <summary>
        /// R parameter - block size.
        /// </summary>
        private readonly int _r;

        /// <summary>
        /// P - parallelization parameter -  a large value of p can increase computational 
        /// cost of scrypt without increasing the memory usage.
        /// </summary>
        private readonly int _p;

        public ScryptOg()
        {
            _n = 64;
            _r = 1;
            _p = 1;

            Multiplier = (UInt32)Math.Pow(2, 16);
        }

        public override byte[] Hash(byte[] input)
        {
            return SCrypt.ComputeDerivedKey(input, input, _n, _r, _p, null, 32);
        }
    }
}
