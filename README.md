# Reactor-Sheriff Mod
Reactor-Sheriff Mod is an Among Us modification for Windows, which adds a new Crewmate class to the game. This is an adaptation of **[Woodi's Sheriff Mod](https://github.com/Woodi-dev/Among-Us-Sheriff-Mod)** that can run along with Mods created with **[Reactor Framework](https://github.com/NuclearPowered/Reactor)**.

<img src ="Pics/SheriffMod.png" width="1000"></img>

<h3>What does the Sheriff do?</h3>
The Sheriff is able to kill Impostors. If they shoot a Crewmate, they will lose their life instead.
<h3>Additional Features</h3>
<ul>
<li> Visibility of the Sheriff can be set in the lobby game options menu</li>
<li> Playable on public Among Us Servers</li>
<li> Custom server regions to join private servers</li>
</ul>

## Installation
Every player in your lobby need to install Reactor-Sheriff Mod. There are two ways to install the mod :
- **All-in-one pack _(Easiest)_:** The easiest way to install the mod.
- **Custom install _(Advanced/Recommended)_:** Download and install everything by yourself.

### All-in-one pack
1. Download the pack for your game version in the **[Releases section](#releases)** below.
2. Extract the content of the zip file into your game folder (**`Steam/steamapps/common/Among Us`**).
3. Run the game from Steam.

### Custom install
1. Install Reactor BepInEx by following **[these instructions](https://docs.reactor.gg/docs/basic/install_bepinex/)**.
2. Install Reactor by following **[these instructions](https://docs.reactor.gg/docs/basic/install_reactor)**.
3. Download the **dll file** for your game version in the **[Releases section](#releases)** below.
4. Copy the dll file into **`Among Us/BepInEx/plugins`**.
5. (Optional) If you want to play on official servers, you must do the following (**doesn't work anymore since v2021.3.31s**) :
    - Open **`Among us/BepInEx/config/gg.reactor.api.cfg`** with a text editor.
    - Find the line `Modded handshake = true` and change it to `Modded handshake = false`.
    - Save and close your editor.
 
<h2>Releases</h2>

 | Among Us Version | Mod Version | All-in-one pack | DLL file |
 | :--------------: | :---------: | :-------------: | :------: |
 | v2021.3.31.3s    | Ver. 1.2.3-R |[**Download**](https://github.com/Brybry16/Reactor-Sheriff/releases/download/v1.2.3/ReactorSheriff-v1.2.3.zip) | [**Download**](https://github.com/Brybry16/Reactor-Sheriff/releases/download/v1.2.3/ReactorSheriff-2021.3.31.3s.dll) |
 | v2021.3.5s       | Ver. 1.2.2-R |[**Download**](https://github.com/Brybry16/Reactor-Sheriff/releases/download/v1.2.2/ReactorSheriff-v1.2.2.zip) | [**Download**](https://github.com/Brybry16/Reactor-Sheriff/releases/download/v1.2.2/ReactorSheriff-2021.3.5s.dll) |
 | v2021.3.5s       | Ver. 1.2.1-R |[**Download**](https://github.com/Brybry16/Reactor-Sheriff/releases/download/v1.2.1/ReactorSheriff-v1.2.1.zip) | [**Download**](https://github.com/Brybry16/Reactor-Sheriff/releases/download/v1.2.1/ReactorSheriff-2021.3.5s.dll) |
 | v2020.12.9s      | Ver. 1.2-R   |[**Download**](https://github.com/Brybry16/Reactor-Sheriff/releases/download/v1.2/ReactorSheriff-v1.2.zip) | [**Download**](https://github.com/Brybry16/Reactor-Sheriff/releases/download/v1.2/ReactorSheriff-2020.12.9s.dll) |
 | v2020.12.9s      | Ver. 1.1-R   |[**Download**](https://github.com/Brybry16/Reactor-Sheriff/releases/download/v1.1/ReactorSheriff-v1.1.zip) | [**Download**](https://github.com/Brybry16/Reactor-Sheriff/releases/download/v1.1/ReactorSheriff-2020.12.9s.dll) |

<details>
  <summary><b>Changelog</b></summary>
   <h3>v1.2.3-R</h3>
   <ul>
    <li>Updated the mod for Among Us v2021.3.31.3</li>
    <li>Fixed Version Shower</li>
   </ul>
   
   <h3>v1.2.2-R</h3>
   <ul>
    <li>Fixed KillButton being enabled when the Sheriff is dead</li>
   </ul>

   <h3>v1.2.1-R</h3>
   <ul>
    <li>The mod is now compatible with Among Us v2021.3.5</li>
    <li>Fixed Sheriff being able use the Kill Button while in meeting</li>
    <li>Stability improvements</li>
   </ul>

   <h3>v1.2-R</h3>
   <ul>
    <li>Fixed Sheriff being able to kill impostors in vent</li>
    <li>Fixed Sheriff being able to kill while in a task</li>
    <li>Fixed Sheriff being able to kill while in Vitals/Admin</li>
   </ul>
  
   <h3>v1.1-R</h3>
   <ul>
    <li>Added Sheriff kill cooldown option to the game lobby</li>
    <li>Added q shortcut to kill as Sheriff</li>
    <li>Kill distance of Impostor and Sheriff are now the same</li>
    <li>Fixed a bug where the outline of the target disappears (Impostor)</li>
    <li>Several nullpointer bugfixes</li>
    <li>Adapted the mod to be compatible with Reactor Framework</li>
   </ul>
</details>   
 
 ## Uninstall
 ### Uninstall Reactor-Sheriff
 To uninstall Reactor-Sheriff, simply delete the ReactorSheriff dll file from **`Among Us/BepInEx/plugins`**.
 
 ### Uninstall Reactor/BepInEx
 To completely uninstall everything, either uninstall/reinstall the game from steam or remove the following files and directories :
 ```
-- BepInEx/
-- mono/
-- changelog.txt
-- doorstop_config.ini
-- steam_appid.txt
-- winhttp.dll
```

<h2>Q&A</h2>
 
<p><b>Can you play Proximity Chat (Crewlink) with it?</b></br>
Yes Crewlink does support Among Us Modifications.</p>
<p><b>Can you get banned for playing on public Servers?</b></br>
At the current state of the game there is no perma ban system for the game. The mod is designed in a way, that it does not send prohibited server requests.
You are also able to join your own custom server to be safe <a href="https://github.com/Impostor/Impostor">(Impostor)</a></p>
<p><b>How can I join a custom server?</b></br>
Go to your game directory and open BepInEx/config/org.bepinex.plugins.SheriffMod.txt. There you can set the hostname or IP of the server. Then set the server region to CUSTOM.</p>
<p><b>Do my friends need to install the mod to play it together?</b></br>
Yes. Every player in the game lobby has to install it.</p>
<h2 id="troubleshooting">Troubleshooting</h2>

<p><b>I can't see <em>loaded</em> message on my game screen</b></p></br>
<ol>
  <li>Make sure you have followed all the <a href="#installation">installation steps</a>, especially launching the game via the Among Us.exe file</li>
  <li>You might be missing some cpp libs (software libraries used by the mod); please install 
    <a href="https://aka.ms/vs/16/release/vc_redist.x86.exe">visual studio c++</a>
  </li>
</ol>

<p><b>I can't find my issue.</b></br>
You can <a href="https://github.com/Brybry16/Reactor-Sheriff/issues/new">raise an issue within GitHub</a> documenting your issue. You will need to be logged into GitHub to do this.
</p>

<h2>License</h2>
<p>This software is distributed under the <b>GNU GPLv3</b> License.
<a href="https://github.com/BepInEx/BepInEx">BepinEx</a> is distributed under <b>LGPL-2.1</b> License.</p>
