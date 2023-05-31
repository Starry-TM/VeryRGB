using System;
using System.Collections.Generic;
using System.Text;
using BepInEx.Configuration;

public class ModConfig
{
    public ConfigEntry<float> RgbSpeed { get; set; }

    // Constructor to initialize configuration options
    public ModConfig(ConfigFile config)
    {
        RgbSpeed = config.Bind("General", "RGB Speed", 1f, "How Fast The RGB Is");
    }
}