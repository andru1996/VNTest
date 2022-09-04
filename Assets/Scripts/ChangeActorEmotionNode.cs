using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VNEngine
{
    public class ChangeActorEmotionNode : Node
    {
        [SerializeField] private string _actorName;
        [SerializeField] private string _emotionName = "emotions/normal";

        private Actor actor;
        private Skins actorSkins;

        public override void Run_Node()
        {
            if(CheckActorName())
            {
                actorSkins.EmotionSkins = new SkinName() { skinName = _emotionName };
                actorSkins.ChangeSkin();
            }
            else
            {
                Debug.LogError("Don't find actor");
            }

            Finish_Node();
        }

        public bool CheckActorName()
        {
            if(actor != null && actor.actor_name.Equals(_actorName))
            {
                return true;
            }

            Actor[] actors = UIManager.ui_manager.actor_parent.GetComponentsInChildren<Actor>();

            foreach (Actor actor in actors)
            {
                if(actor.actor_name.Equals(_actorName))
                {
                    this.actor = actor;
                    actorSkins = actor.GetComponentInChildren<Skins>();
                    return true;
                }
            }

            return false;
        }

        IEnumerator Wait(float how_long)
        {
            yield return new WaitForSeconds(how_long);
            Finish_Node();
        }

        public override void Button_Pressed()
        {
            //Finish_Node();
        }


        public override void Finish_Node()
        {
            //StopAllCoroutines();

            base.Finish_Node();
        }
    }
}