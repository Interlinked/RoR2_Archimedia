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
            "ARCHIMEDIA_HOVERDESC".Add("Fight through a harder run with a randomized loadout.");

            SceneManager.activeSceneChanged += OnSceneChanged;
            On.RoR2.ConsoleFunctions.SubmitCmd += (orig, self, str) =>
            {
                if(self.GetComponent<HGButton>() && self.GetComponent<HGButton>().hoverToken == "ARCHIMEDIA_HOVERDESC")
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

        


    
            private static void OnSceneChanged(Scene prev, Scene next) {
            if (next.name == "title") {
                GameObject gameObject = GameObject.Find("MainMenu");
                Transform transform = gameObject.transform.Find("MENU: Extra Game Mode/ExtraGameModeMenu/Main Panel/GenericMenuButtonPanel/JuicePanel/GenericMenuButton (Eclipse)");
                if (transform)
                {
                    GameObject button = UnityEngine.Object.Instantiate(transform.gameObject, transform.parent);
                    button.GetComponent<LanguageTextMeshController>().token = "ARCHIMEDIA_MENU_NAME";
                    ConsoleFunctions consoleFunctions = button.GetComponent<ConsoleFunctions>();
                    HGButton component = button.GetComponent<HGButton>();
                    component.hoverToken = "ARCHIMEDIA_HOVERDESC";
                    component.onClick.RemoveAllListeners();
                    component.onClick.AddListener(delegate
                    {
                        consoleFunctions.SubmitCmd("transition_command \"gamemode archimediaRun; host 0;\"");
                    });

                }
                else {
                    Debug.Log("Could not find transform.");
                }
            }
        }
    }
}
