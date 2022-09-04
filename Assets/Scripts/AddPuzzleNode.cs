using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VNEngine
{
    public class AddPuzzleNode : Node
    {
        [SerializeField] private GameLevel _gameLevel;
        [SerializeField] private int _gameLoseTime = 2000;
        [SerializeField] private string _statResultName;

        private GameObject _puzzle;

        public override void Run_Node()
        {
            _puzzle = Instantiate(Resources.Load("Puzzle/Puzzle", typeof(GameObject))) as GameObject;
            GameController gameController = _puzzle.GetComponentInChildren<GameController>();
            gameController.gameLevel = _gameLevel;
            gameController.LoseTime = _gameLoseTime;
            gameController.OnFinish += FinishGame;
        }

        public void FinishGame(bool isWin)
        {
            StatsManager.Set_Boolean_Stat(_statResultName, isWin);

            Finish_Node();
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
            Destroy(_puzzle);

            base.Finish_Node();
        }
    }
}
