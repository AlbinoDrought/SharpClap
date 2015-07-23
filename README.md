## SharpClap

SharpClap is a program that can send keys (with delays) when noises within a threshold are heard. It uses SendInput for I/O and NAudio's implementation of WASAPI for listening through both input and output.

## Why?

I wanted to rank up my fishing in the game Trove, but I did not have the audacity to sit at my keyboard for hours just to repeatedly press a single button (F) after hearing the "caught-fish" sound. Other solutions to this problem used memory reading and writing, which is too invasive for me (and more likely to be caught by an anti-cheat). 

## Features

* Ability to listen to both input and output devices
* Minimum and maximum noise thresholds
* User-defined keys
* Support for static and random delays
* Saving and loading settings to .xml
* Customizable cooldown inbetween detection instances

## Examples

See the folder called "Examples" for example xml files you can load through the program.

Currently contains:
* **trove.xml** - Sound-based auto-fisher for the F2P Trove MMO

## License

Licensed under GPL-3 - https://tldrlegal.com/license/gnu-general-public-license-v3-(gpl-3)

Uses **NAudio**: NAudio is an open source .NET audio library written by Mark Heath (mark.heath@gmail.com) licensed under Ms-PL