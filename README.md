# sts2_piercing_fahhh

A mod for Slay the Spire 2 that plays a custom "FAHHH" sound effect when Piercing Wail is played in combat.

## Requirements
- [BaseLib](https://github.com/Alchyr/BaseLib-StS2/releases) — must be installed before this mod will work

## Installation

### Step 1 — Find your Slay the Spire 2 mods folder
The mods folder is located at:

**Windows:** C:\Program Files (x86)\Steam\steamapps\common\Slay the Spire 2\mods\

If the `mods` folder doesn't exist, create it yourself.

### Step 2 — Install BaseLib
Download the latest release of BaseLib from [here](https://github.com/Alchyr/BaseLib-StS2/releases).
Place the downloaded files into: mods\BaseLib\

### Step 3 — Install this mod
Download this mod and place the folder into: mods\sts2_piercing_fahhh\

Your mods folder should look like this:
mods
├── BaseLib
│   ├── BaseLib.dll
│   ├── BaseLib.pck
│   └── BaseLib.json
└── sts2_piercing_fahhh
   ├── PiercingWailSound.dll
   ├── mod_manifest.json
   ├── Code
   └── assets
      └── audio
         └── piercing_wail_sfx.ogg

### Step 4 — Launch with mods
In Steam, click **Play → Load with Mods**, make sure the mod is enabled, and start a run with the Silent.

## Building from source
Requirements: .NET 9.0 SDK, the game installed

1. Clone the repo into your mods folder
2. Run `dotnet publish` in the repo folder
3. Launch the game with mods enabled