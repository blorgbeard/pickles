﻿//  --------------------------------------------------------------------------------------------------------------------
//  <copyright file="NUnitExampleSignatureBuilder.cs" company="PicklesDoc">
//  Copyright 2011 Jeffrey Cameron
//  Copyright 2012-present PicklesDoc team and community contributors
//
//
//  Licensed under the Apache License, Version 2.0 (the "License");
//  you may not use this file except in compliance with the License.
//  You may obtain a copy of the License at
//
//      http://www.apache.org/licenses/LICENSE-2.0
//
//  Unless required by applicable law or agreed to in writing, software
//  distributed under the License is distributed on an "AS IS" BASIS,
//  WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//  See the License for the specific language governing permissions and
//  limitations under the License.
//  </copyright>
//  --------------------------------------------------------------------------------------------------------------------

using System;
using System.Text;
using System.Text.RegularExpressions;

using PicklesDoc.Pickles.ObjectModel;

namespace PicklesDoc.Pickles.TestFrameworks
{
    public class NUnitExampleSignatureBuilder
    {
        public Regex Build(ScenarioOutline scenarioOutline, string[] row)
        {
            var stringBuilder = new StringBuilder();
            stringBuilder.Append(scenarioOutline.Name.ToLowerInvariant().Replace(" ", string.Empty) + "\\(");

            foreach (string value in row)
            {
                stringBuilder.AppendFormat("\"{0}\",", value.ToLowerInvariant().Replace(@"\", string.Empty).Replace(@"$", @"\$"));
            }

            stringBuilder.Remove(stringBuilder.Length - 1, 1);

            return new Regex(stringBuilder.ToString());
        }
    }
}
