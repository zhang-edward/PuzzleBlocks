﻿using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	public static GameManager instance;

	TetrisGameManager GM_tetris;
	ColorMatchGameManager GM_colorMatch;

	public int score;

	// DEBUG
	public bool DEBUG_MODE = false;
	// DEBUG

	void Awake()
	{
		// Make this a singleton
		if (instance == null)
			instance = this;
		else if (instance != this)
			Destroy (gameObject);
		
		DontDestroyOnLoad(gameObject);
	}

	void Start()
	{
		GM_tetris = GetComponentInChildren<TetrisGameManager>();
		GM_colorMatch = GetComponentInChildren<ColorMatchGameManager>();

		GM_tetris.InitBoard();
		GM_colorMatch.InitGrid();
	}

	public void sendTetrisData(int[,] tetrisPieceData, int tileColor)
	{
		GM_tetris.InitPiece (tetrisPieceData, tileColor);
	}

	public bool haveTetrisPiece()
	{return GM_tetris.HavePiece;}

	public void GameOver()
	{
		Debug.Log ("Game Over");
	}

	public void Restart()
	{
		score = 0;
		GM_colorMatch.ResetGrid();
		GM_tetris.ResetBoard();
	}
}