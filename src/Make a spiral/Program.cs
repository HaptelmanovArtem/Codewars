using System;

namespace Make_a_spiral
{
  internal class Program
  {
    private const int Empty = 0;
    private const int Element = 1;

    private static void Main(string[] args)
    {
      var spiral = Spiralize(5);

      Print(spiral);
    }

    private static void Print(int[,] spiral)
    {
      for (var i = 0; i < 5; i++)
      {
        for (var j = 0; j < 5; j++)
        {
          Console.Write($" {spiral[i, j]} ");
        }

        Console.WriteLine();
      }

      Console.WriteLine();
      Console.WriteLine();
    }

    public static int[,] Spiralize(int size)
    {
      if (size <= 0)
        return null;

      var currentDirection = Direction.Right;

      var result = new int[size, size];

      var i = 0;
      var j = 0;

      while (true)
      {
        if (!IsAnyPathAvailable(result, i, j, size))
        {
          if (CanSetElement(result, i, j, size, currentDirection))
          {
            result[i, j] = 1;
          }
          
          break;
        }

        if (currentDirection == Direction.Right)
        {
          if (CanGoRight(result, i, j, size))
          {
            result[i, j] = 1;
            j++;
            continue;
          }

          currentDirection = Direction.Down;
        }
        else if (currentDirection == Direction.Down)
        {
          if (CanGoDown(result, i, j, size))
          {
            result[i, j] = 1;
            i++;
            continue;
          }

          currentDirection = Direction.Left;
        }
        else if (currentDirection == Direction.Left)
        {
          if (CanGoLeft(result, i, j))
          {
            result[i, j] = 1;
            j--;
            continue;
          }

          currentDirection = Direction.Top;
        }
        else if (currentDirection == Direction.Top)
        {
          if (CanGoTop(result, i, j))
          {
            result[i, j] = 1;
            i--;
            continue;
          }


          currentDirection = Direction.Right;
        }
      }

      return result;  
    }

    private static bool CanSetElement(int[,] arr, int i, int j, int size, Direction direction)
    {
      var isTop = i - 1 < 0 || arr[i - 1, j] == 0;
      var isDown = i + 1 >= size || arr[i + 1, j] == 0;
      var isLeft = j - 1 < 0 || arr[i, j - 1] == 0;
      var isRight = j + 1 >= size || arr[i, j + 1] == 0;

      return direction switch
      {
        Direction.Left => isTop && isDown && isLeft,
        Direction.Down => isDown && isLeft && isRight,
        Direction.Right => isTop && isDown && isRight,
        Direction.Top => isTop && isLeft && isRight,
        _ => throw new ArgumentOutOfRangeException(nameof(direction))
      };
    }

    private static bool IsAnyPathAvailable(int[,] arr, int i, int j, int size)
    {
      return
        CanGoRight(arr, i, j, size) ||
        CanGoDown(arr, i, j, size) ||
        CanGoLeft(arr, i, j) ||
        CanGoTop(arr, i, j);
    }

    private static bool CanGoRight(int[,] array, int currentIndexI, int currentIndexJ, int size)
    {
      var isNextEmpty = currentIndexJ + 1 < size &&
                        array[currentIndexI, currentIndexJ + 1] == Empty;

      var isNextNextHasElement = currentIndexJ + 2 <= size - 1 &&
                                 array[currentIndexI, currentIndexJ + 2] != Empty;

      return isNextEmpty && !isNextNextHasElement;
    }

    private static bool CanGoDown(int[,] array, int currentIndexI, int currentIndexJ, int size)
    {
      var isHasNextElement = currentIndexI + 1 < size &&
                             array[currentIndexI + 1, currentIndexJ] == Empty;

      var isNextNextHasElement = currentIndexI + 2 <= size - 1 &&
                                 array[currentIndexI + 2, currentIndexJ] != Empty;

      return isHasNextElement && !isNextNextHasElement;
    }

    private static bool CanGoLeft(int[,] array, int currentIndexI, int currentIndexJ)
    {
      var isHasNextElement = currentIndexJ - 1 >= 0 &&
                             array[currentIndexI, currentIndexJ - 1] == Empty;

      var isNextNextHasElement = currentIndexJ - 2 >= 0 &&
                                 array[currentIndexI, currentIndexJ - 2] != Empty;

      return isHasNextElement && !isNextNextHasElement;
    }

    private static bool CanGoTop(int[,] array, int currentIndexI, int currentIndexJ)
    {
      var isHasNextElement = currentIndexI - 1 >= 0 &&
                             array[currentIndexI - 1, currentIndexJ] == Empty;

      var isNextNextHasElement = currentIndexI - 2 >= 0 &&
                                 array[currentIndexI - 2, currentIndexJ] != Empty;

      return isHasNextElement && !isNextNextHasElement;
    }

    private enum Direction
    {
      Left = 1,
      Down = 2,
      Right = 3,
      Top = 4,
    }
  }
}
