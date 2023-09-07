using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(RectTransform))]
public class AutoExpandingGrid : LayoutGroup
{
    public int columns = 5;
    public RectOffset padding;
    public Vector2 spacing;


    private RectTransform rectTransform;

    public override void CalculateLayoutInputHorizontal()
    {
        Refresh();
    }

    public override void CalculateLayoutInputVertical()
    {
        Refresh();
    }

    public override void SetLayoutHorizontal()
    {
        Refresh();
    }

    public override void SetLayoutVertical()
    {
        Refresh();
    }

    public void Refresh()
    {
        if (columns <= 0)
        {
            return;
        }


        rectTransform = GetComponent<RectTransform>();
        int cells = rectTransform.childCount;
        Vector2 cellSize;
        int rows = Mathf.CeilToInt(cells / columns);

        cellSize.x = (rectTransform.rect.width - padding.left - padding.right - (spacing.x * (columns - 1))) / columns;
        cellSize.y = (rectTransform.rect.height - padding.top - padding.bottom - (spacing.y * (rows - 1))) / rows;
        cellSize.y = cellSize.x;
        for (int i = 0; i < rectTransform.childCount; i++)
        {
            RectTransform child = (RectTransform)rectTransform.GetChild(i);
            var y = i / columns;
            var x = i - y * columns;
            var positionY = padding.top + (cellSize.y * y) + (y * spacing.y) + (cellSize.y) / 2;
            var positionX = padding.left + (cellSize.x * x) + (x * spacing.x) + (cellSize.x) / 2;

            var position = new Vector2(positionX, -positionY);
            child.anchoredPosition = position;
            child.sizeDelta = cellSize;


            print("position: " + position);
            print("cellSize: " + cellSize);
        }
    }

    // {
    //     rectTransform = GetComponent<RectTransform>();
    //     gridLayout = GetComponent<GridLayoutGroup>();
    //     gridLayout.constraintCount = coumnCount;


    //     float margin = gridLayout.spacing.x;
    //     float horizontalPadding = gridLayout.padding.left + gridLayout.padding.right;

    //     float cellWidth = (rectTransform.rect.width - (coumnCount  - 1) * margin - horizontalPadding)/coumnCount;
    //     gridLayout.cellSize = new Vector2(cellWidth, cellWidth);
    // }
}