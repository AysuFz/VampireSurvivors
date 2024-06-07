using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldScrolling : MonoBehaviour
{
    [SerializeField]
    Transform playerTransform;
    Vector2Int currentTilePosition = new Vector2Int(0,0);
    [SerializeField] Vector2Int playerTilePOs;
    Vector2Int onTileGridPlayerPos; 
    [SerializeField] float TileSize = 20f;
    GameObject[,] terrainTiles;

    [SerializeField] int terHorizontalCount;
    [SerializeField] int terVerticalCount;

    [SerializeField] int fieldOfVisionHeight = 3;
    [SerializeField] int fieldOfVisionWidth = 3;

    private void Awake()
    {
        terrainTiles = new GameObject[terHorizontalCount, terVerticalCount];
    }
    private void Update()
    {
        playerTilePOs.x = (int)(playerTransform.position.x / TileSize);
        playerTilePOs.y = (int)(playerTransform.position.y / TileSize);

        playerTilePOs.x -= playerTransform.position.x < 0 ? 1 : 0;
        playerTilePOs.y -= playerTransform.position.y < 0 ? 1 : 0;

        if (currentTilePosition != playerTilePOs)
        {
            currentTilePosition = playerTilePOs;

            onTileGridPlayerPos.x = CalculatePositionOnAxis(onTileGridPlayerPos.x, true);
            onTileGridPlayerPos.y = CalculatePositionOnAxis(onTileGridPlayerPos.y, false);
            UpdateTileOnScreen();

        }
    }

    public void Add(GameObject TileGameObject, Vector2Int tilePos)
    {
        terrainTiles[tilePos.x, tilePos.y] = TileGameObject;    
    }
    private void UpdateTileOnScreen()
    {
        for(int povX = -(fieldOfVisionWidth/2); povX <= fieldOfVisionWidth/2; povX++)
        {
            for(int povY = -(fieldOfVisionHeight / 2); povY <= fieldOfVisionHeight/2; povY++)
            {
                int tileToUpdate_x = CalculatePositionOnAxis(playerTilePOs.x + povX, true);

                int tileToUpdate_y = CalculatePositionOnAxis(playerTilePOs.y + povY, false);

         
                GameObject tile = terrainTiles[tileToUpdate_x, tileToUpdate_y];
                tile.transform.position = CalculateTilePosition(playerTilePOs.x + povX, playerTilePOs.y + povY);
            }
        }
    }
    private Vector3 CalculateTilePosition(int x , int y)
    {
        return new Vector3(x * TileSize, y * TileSize , 0f);
    }
    private void Start()
    {
        UpdateTileOnScreen();
    }

    private int CalculatePositionOnAxis(float currentValue, bool horizontal)
    {
        if (horizontal)
        {
            if(currentValue >= 0)
            {
                currentValue = currentValue % terHorizontalCount;
            }
            else
            {
                currentValue += 1;
                currentValue = terHorizontalCount - 1 + currentValue % terHorizontalCount;
            }
        }
        else
        {
            if (currentValue >= 0)
            {
                currentValue = currentValue % terVerticalCount;
            }
            else
            {
                currentValue += 1;
                currentValue = terVerticalCount - 1 + currentValue % terVerticalCount;
            }
        }
        return (int)currentValue;
    }
}
