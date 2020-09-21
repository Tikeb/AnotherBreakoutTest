using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class BrickController : MonoBehaviour
{
    public Tilemap BricksTileMap;

    void Start()
    {
        GenerateRandomLevel();
    }

    void Update()
    {

    }

    internal void ResetLevel()
    {
    }

    internal void NextLevel()
    {
    }

    private void GenerateRandomLevel()
    {
        //var colourWall = new Color(46, 48, 61, 255); //2E303D
        //var colourOffWhite = new Color(247, 243, 241); //F7F3F1
        //var colourBackground = new Color(33, 37, 36); //212524
        //var colourBlueGrey = new Color(145, 153, 190); //9199BE
        //var colourBlue = new Color(84, 103, 143); //54678F
        //var colourGreen = new Color(103, 143, 84); //678F54
        //var colourGrey = new Color(128, 128, 128); //808080
        //var colourWashedRed = new Color(190, 160, 145); //BEA091
        //var colourTan = new Color(190, 182, 145); //BEB691

        var prefabs = new List<Tile>();

        foreach (Tile prefab in Resources.LoadAll("Prefabs/Tiles/BrickTiles", typeof(Tile)))
        {
            prefabs.Add(prefab);
        }


        ColorUtility.TryParseHtmlString("#2E303D", out Color colourWall);
        ColorUtility.TryParseHtmlString("#F7F3F1", out Color colourOffWhite);
        ColorUtility.TryParseHtmlString("#212524", out Color colourBackground);
        ColorUtility.TryParseHtmlString("#9199BE", out Color colourBlueGrey);
        ColorUtility.TryParseHtmlString("#54678F", out Color colourBlue);
        ColorUtility.TryParseHtmlString("#678F54", out Color colourGreen);
        ColorUtility.TryParseHtmlString("#808080", out Color colourGrey);
        ColorUtility.TryParseHtmlString("#BEA091", out Color colourWashedRed);
        ColorUtility.TryParseHtmlString("#BEB691", out Color colourTan);

        var colours = new[] { colourWall, colourOffWhite, colourBackground, colourBlueGrey, colourBlue, colourGreen, colourGrey, colourWashedRed, colourTan };

        //var bricks = new[] { Tile1, Tile2, Tile3 };

        const int minRowNum = -9;
        const int maxRowNum = 9;

        const int minColNum = 8;
        const int maxColNum = -2;

        //Tile2.color = new Color(33, 37, 36);

        for (int row = minRowNum; row <= maxRowNum; row++)
        {
            for (int col = minColNum; col >= maxColNum; col--)
            {
                var position = new Vector3Int(row, col, 1);
                var color = colours[Random.Range(0, colours.Length - 1)];
                var tile = prefabs[Random.Range(0, 3)];

                BricksTileMap.SetTile(position, tile);
                //Bricks.SetTileFlags(position, TileFlags.None);
                //Bricks.SetColor(position, color);// new Color(0.9820799f, 0.6273585f, 1));

                

                //Bricks.SetColor(v3, Color.green);
            }
        }



        //First:
        //Bricks.SetTile(new Vector3Int(-10, 8, 1), Tile1);

        //Last:
        //Bricks.SetTile(new Vector3Int(8, -2, 1), Tile1);

    }
}
