using System;
using System.Collections.Generic;
using System.Linq;
using Events;
using FSM;
using GlobalConstants;
using Models;
using Player;
using SimpleEventBus.Disposables;
using UI.ViewControllers;
using UnityEngine;

namespace States
{
    public class StateManager : MonoBehaviour, IDisposable
    {
        [SerializeField] private GameOverViewController _gameOverViewController;
        [SerializeField] private PlayerViewController _playerViewController;
        
        private StateMachine _stateMachine;
        private CompositeDisposable _subscriptions;
        private Dictionary<PlayerController, PlayerModel> _playerControllers;

        private bool _isGameState = true;

        public void Dispose()
        {
            _subscriptions?.Dispose();
        }
        
        private void Awake()
        {
            _playerControllers = new Dictionary<PlayerController, PlayerModel>();
            
            _subscriptions = new CompositeDisposable
            {
                EventStreams.Game.Subscribe<GameOverEvent>(ChangeGameState),
                EventStreams.Game.Subscribe<PlayerControllerActivatedEvent>(AddGameController)
            };
            
            _stateMachine = new StateMachine();
            
            _stateMachine.AddState(StateMachineStates.GAME,
                _ =>
                {
                    _playerViewController.gameObject.SetActive(true);
                },
                onExit: _ =>
                {
                    _playerViewController.gameObject.SetActive(false);
                });
            _stateMachine.AddState(StateMachineStates.GAME_OVER_STATE,
                _ =>
                {
                    _gameOverViewController.gameObject.SetActive(true);
                    _gameOverViewController.Initialize(_playerControllers.First().Value);
                },
                onExit: _ =>
                {
                    _gameOverViewController.gameObject.SetActive(false);
                });
            _stateMachine.SetStartState(StateMachineStates.GAME);
            
            _stateMachine.AddTransition(StateMachineStates.GAME, StateMachineStates.GAME_OVER_STATE, _ => !_isGameState);
            
            _stateMachine.Init();
        }
        
        private void Update()
        {
            _stateMachine.OnLogic();
        }

        private void ChangeGameState(GameOverEvent eventData)
        {
            var playerController = eventData.PlayerController;
            
            if (_playerControllers.ContainsKey(playerController))
            {
                Debug.Log("123");
                playerController.gameObject.SetActive(false);
                _playerControllers.Remove(playerController);
            }

            if (_playerControllers.Count == 1)
            {
                _playerControllers.First().Key.gameObject.SetActive(false);
                _isGameState = !_isGameState;
            }
        }

        private void AddGameController(PlayerControllerActivatedEvent eventData)
        {
            _playerControllers.Add(eventData.PlayerController, eventData.PlayerModel);
        }
    }
}