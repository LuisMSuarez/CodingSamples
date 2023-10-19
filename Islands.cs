// find number of islands in a 2-dimensional array, where 1 represents land, and 0 represents water

int[,] input = {
                {1, 0, 1, 1},
                {1, 1, 0, 0},
                {1, 1, 0, 1}
};

int[,] visited = new int[input.GetLength(0), input.GetLength(1)];

int findIslands(int[,] input)
{
    int numIslands = 0;
    for (int row = 0; row< input.GetLength(0); row ++)
    {
        for (int col = 0; col < input.GetLength(1); col ++)
        {
            if (visited[row, col] == 1)
            { 
                continue;
            }
            if (input[row,col] == 1)
            {
                numIslands++;
                exploreIsland(row, col);
            }
            visited[row, col] = 1;
        }
    }
    return numIslands;
}

void exploreIsland(int row, int col)
{
    if ((row >= input.GetLength(0)) ||
        (row < 0) ||
        (col >= input.GetLength(1)) ||
        (col < 0))
    {
        return;
    }

    if (visited[row, col] == 1)
    {
        return;
    }

    visited[row, col] = 1;
    if (input[row, col] == 0 )
    {
        return;
    }
    exploreIsland(row, col + 1);
    exploreIsland(row + 1, col + 1);
    exploreIsland(row + 1, col);
    exploreIsland(row + 1, col -1 );
    exploreIsland(row, col - 1);
    exploreIsland(row-1, col - 1);
    exploreIsland(row - 1, col);
    exploreIsland(row - 1, col + 1);
}

int numIslands = findIslands(input);
Console.WriteLine($"number of islands: {numIslands}");