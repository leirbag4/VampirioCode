﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VampirioCode.SaveData.Builders.Cpp
{
    public class EmscriptenSaveSettings : BuilderSaveSettingsBase
    {
        public string emsdk_bat_path { get; set; } = "";
        public string nodejs_exe_path { get; set; } = "";
    }
}
