WebXR Beat Em All PoC
===========

A WebXR Beat Em All game made for a school project @Hetic.

## Credit  

>[De-Panther](https://github.com/De-Panther/unity-webxr-export) for the up-to-date WebXR Boilerplate

## Requirements
>[Unity 2019.4.19f1 and up](https://unity3d.com/fr/unity/qa/lts-releases) 

## Setup
- Clone the repository
- Open the project using Unity Hub or directly within Unity
- Replace the content of the script "ControllerInteraction" with "VRInteraction"

## Preview in VR within Unity
- Go to Project Settings -> XR-Plug-in Management -> PC, Mac and Linux standalone settings
- Turn on the Plug-in Provider you need
- Start SteamVR
- Run the preview

## Deployment
- Build the application for WebGL
- Run the build on an HTTPS server

## Preview in VR in WebXR
- Start SteamVR
- Run the build
- Click on "VR"
>[If you don't have a VR headset, use the WebXR API Emulator](https://chrome.google.com/webstore/detail/webxr-api-emulator/mjddjgeghkdijejnciaefnkjmkafnnje)

## To Do
- [x] Object velocity management
- [x] Ennemy wave generation -> https://sharpcoderblog.com/blog/fps-with-enemy-ai-in-unity-3d
- [x] Ennemy AI (Movement, attack pattern, life) -> https://sharpcoderblog.com/blog/fps-with-enemy-ai-in-unity-3d
- [x] Ennemy animation
- [x] Ennemy -> Fix position on rotation
- [x] Ennemy -> Trigger animation on dying
- [x] Menu (Main menu/Pause/Victory/Game over)
- [x] UI (HP/Number of ennemies left/Number of waves)
- [x] Sound Design (Main theme/Damage received/Damage done/Game over/End of wave/New wave)
- [x] Object velocity refine
- [ ] Asset compositing
- [ ] UI Refine
- [ ] Bug fix (Objects giving damages to ennemies while being on the floor, player collision handler on hands, Restart on weebgl export is broken)
- [ ] <!> Out of time <!> Character animation
- [ ] <!> Out of time <!> Animate Post Exposure on damage taken
- [ ] <!> Out of time <!> Object placement management (Turret like)
- [ ] <!> Out of time <!> VR Teleportation or object throw position handler -> https://github.com/IJEMIN/Simple-Unity-VR-Teleporter










