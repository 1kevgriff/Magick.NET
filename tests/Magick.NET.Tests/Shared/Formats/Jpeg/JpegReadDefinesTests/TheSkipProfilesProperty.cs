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
using ImageMagick.Defines;
using ImageMagick.Formats.Jpeg;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Magick.NET.Tests
{
    public partial class JpegReadDefinesTests
    {
        [TestClass]
        public class TheSkipProfilesProperty
        {
            [TestMethod]
            public void ShouldSetTheDefine()
            {
                var settings = new MagickReadSettings()
                {
                    Defines = new JpegReadDefines()
                    {
                        SkipProfiles = JpegProfileTypes.App,
                    },
                };

                using (IMagickImage image = new MagickImage())
                {
                    image.Read(Files.ImageMagickJPG, settings);

                    Assert.AreEqual("App", image.Settings.GetDefine("profile:skip"));
                }
            }

            [TestMethod]
            public void ShouldNotSetTheDefineForInvalidValues()
            {
                var settings = new MagickReadSettings()
                {
                    Defines = new JpegReadDefines()
                    {
                        SkipProfiles = (JpegProfileTypes)64,
                    },
                };

                using (IMagickImage image = new MagickImage())
                {
                    image.Read(Files.ImageMagickJPG, settings);

                    Assert.IsNull(image.Settings.GetDefine("profile:skip"));
                }
            }

            [TestMethod]
            public void ShouldSkipTheSpecifiedProfiles()
            {
                var settings = new MagickReadSettings()
                {
                    Defines = new JpegReadDefines()
                    {
                        SkipProfiles = JpegProfileTypes.Iptc | JpegProfileTypes.Icc,
                    },
                };

                using (IMagickImage image = new MagickImage())
                {
                    image.Read(Files.FujiFilmFinePixS1ProJPG);
                    Assert.IsNotNull(image.GetIptcProfile());

                    image.Read(Files.FujiFilmFinePixS1ProJPG, settings);
                    Assert.IsNull(image.GetIptcProfile());
                    Assert.AreEqual("Icc,Iptc", image.Settings.GetDefine("profile:skip"));
                }
            }
        }
    }
}
