﻿// Copyright 2013-2020 Dirk Lemstra <https://github.com/dlemstra/Magick.NET/>
//
// Licensed under the ImageMagick License (the "License"); you may not use this file except in
// compliance with the License. You may obtain a copy of the License at
//
//   https://www.imagemagick.org/script/license.php
//
// Unless required by applicable law or agreed to in writing, software distributed under the
// License is distributed on an "AS IS" BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND,
// either express or implied. See the License for the specific language governing permissions
// and limitations under the License.

using ImageMagick;
using ImageMagick.Formats.Png;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Magick.NET.Tests
{
    public partial class PngReadDefinesTests
    {
        [TestClass]
        public class TheSwapBytesProperty
        {
            [TestMethod]
            public void ShouldSetTheDefineWhenSetToTrue()
            {
                var defines = new PngReadDefines()
                {
                    SwapBytes = true,
                };

                using (IMagickImage image = new MagickImage())
                {
                    image.Settings.SetDefines(defines);

                    Assert.AreEqual("True", image.Settings.GetDefine(MagickFormat.Png, "swap-bytes"));
                }
            }

            [TestMethod]
            public void ShouldNotSetTheDefineWhenSetToFalse()
            {
                var defines = new PngReadDefines()
                {
                    SwapBytes = false,
                };

                using (IMagickImage image = new MagickImage())
                {
                    image.Settings.SetDefines(defines);

                    Assert.AreEqual(null, image.Settings.GetDefine(MagickFormat.Png, "swap-bytes"));
                }
            }
        }
    }
}
