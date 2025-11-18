using System;
using RoR2.UI;
using UnityEngine.SceneManagement;

namespace Archimedia 
{
    public static class UI
    {
        public static void Initialize()
        {
            SceneManager.activeSceneChanged += OnSceneChanged;
            "ARCHIMEDIA_MENU_NAME".Add("Elite Void Archimedia");
            "BOSSRUSH_HOVERDESC".Add("Fight through a harder run with a randomized loadout.");

            SceneManager.activeSceneChanged += OnSceneChanged;
            On.RoR2.ConsoleFunctions.SubmitCmd += (orig, self, str) =>
            {
                if(self.GetComponent<HGButton>() && self.GetComponent<HGButton>().hoverToken == "BOSSRUSH_HOVERDESC")
                {
                    if(str == "transition_command \"gamemode ArchimediaRun; host 0;\"")
                    {
                        orig(self,str);
                    }
                }
            else
                {
                    orig(self, str);
                }
            };
        }

        


    }
}