## Rich HUD Font Gen
This is a font generation tool for the [Rich HUD Framework](https://github.com/ZachHembree/RichHudFramework.Client/wiki) Space Engineers modification. This tool relies on the BmFontGen and DirectXTex Texconv utilities supplied in the Space Engineers modding SDK to generate a set of texture atlases, along with the accompanying metadata, in a format compatible with the framework and the game's material system.

## Installation
Installation is simple. Download a copy of the lastest release, extract the archive, and place the "RichHudFontGen" folder in "steamapps\common\SpaceEngineers\Tools\Fonts". Font data will write to "RichHudFontGen\FontName" with the internal file structure required for use with the framework.

DirectXTex Texconv requires you to have the x86 version of [Visual C++ Redistributable Packages for Visual Studio 2013](https://www.microsoft.com/en-us/download/details.aspx?id=40784) installed. If this isn't installed, Texconv will not run and this utility will be unable to convert the atlas textures to the correct format.

## Usage
Once installed, it's pretty straightforward. Run the application, click "Select Font," select the font you want and the size to render at, then click apply, close the dialog and "Click Generate Font Data." For information on integrating the resulting font data into a mod and registering it with the framework, see the [wiki](https://github.com/ZachHembree/RichHudFramework.Client/wiki).
