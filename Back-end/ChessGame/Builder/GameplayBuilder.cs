﻿using ChessGame.Domain.Entities;
using ChessGame.Domain.Enums;
using ChessGame.Domain.Game;
using ChessGame.Domain.Shared;

namespace ChessGame.Domain.Builder
{
    public class GameplayBuilder : IBuilder<Gameplay>
    {
        private readonly Board _board = BoardBuilder.New().Build();
        private readonly Player _playerOne = PlayerBuilder.New().Build();
        private readonly Player _playerTwo = PlayerBuilder.New().WithName("Jogador dois").WithColor(EColor.Black).Build();

        public static GameplayBuilder New()
        {
            return new GameplayBuilder();
        }

        public Gameplay Build()
        {
            return new Gameplay(_board, _playerOne, _playerTwo);
        }
    }
}
