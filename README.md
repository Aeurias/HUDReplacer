# HUDReplacer

This is a framework for Kerbal Space Program that allows you to replace HUD/UI textures at runtime.

## Installation & Load Order
To ensure HUDReplacer functions correctly and is able to skin all UI elements (including DLC and late-loading mod windows), the following folder structure in `GameData` is strictly required:

* `GameData/zz_HUDReplacer/` - The core engine.
* `GameData/zzz_ZTheme/` - The asset pack (e.g., ZTheme).

Naming the folders with these prefixes ensures that HUDReplacer and its assets are loaded after most other mods, preventing initialization race conditions.

## Download
[GitHub][gh-download] | CKAN

[gh-download]: https://github.com/KSPModStewards/HUDReplacer/releases/latest

## Dependencies
These are not included in the download and must be installed separately
(or you can just use CKAN).

* [Module Manager](https://forum.kerbalspaceprogram.com/index.php?/topic/50533-*)
* [HarmonyKSP](https://github.com/KSPModdingLibs/HarmonyKSP)

## How to Create Texture Packs
Documentation on how to create texture packs, as well as how to recolor other
UI elements, can be found in the [repository wiki][wiki].

[wiki]: https://github.com/KSPModStewards/HUDReplacer/wiki/Creating-Texture-Packs

## License
HUDReplacer is available under the GPLv3 license.
