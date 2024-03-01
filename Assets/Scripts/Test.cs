using CodeMonkey.Utils;
using UnityEngine;

public class Test : MonoBehaviour
{

    private Grid<StringGridObject> _stringGrid;
    void Start()
    {
        _stringGrid = new Grid<StringGridObject>(20,15, 10f, Vector3.zero,(g, x, y) => new StringGridObject(g,x,y));
    }

    private void Update()
    {
        var position = UtilsClass.GetMouseWorldPosition();
        if (Input.GetKeyDown(KeyCode.A)) _stringGrid.GetGridObject(position).AddLetter("A");
        if (Input.GetKeyDown(KeyCode.S)) _stringGrid.GetGridObject(position).AddLetter("S");
        if (Input.GetKeyDown(KeyCode.D)) _stringGrid.GetGridObject(position).AddLetter("D");
        
        if (Input.GetKeyDown(KeyCode.Alpha1)) _stringGrid.GetGridObject(position).AddNumber("1");
        if (Input.GetKeyDown(KeyCode.Alpha2)) _stringGrid.GetGridObject(position).AddNumber("2");
        if (Input.GetKeyDown(KeyCode.Alpha3)) _stringGrid.GetGridObject(position).AddNumber("3");
    }
}

public class StringGridObject
{
    private Grid<StringGridObject> _grid;
    private int _x;
    private int _y;

    private string _letters;
    private string _numbers;

    public StringGridObject(Grid<StringGridObject> grid, int x, int y)
    {
        _grid = grid;
        _x = x;
        _y = y;
        
        _letters = "";
        _numbers = "";
    }

    public void AddLetter(string letter)
    {
        _letters += letter;
        _grid.TriggerGridObjectChange(_x,_y);
    }
    
    public void AddNumber(string number)
    {
        _numbers += number;
        _grid.TriggerGridObjectChange(_x,_y);
    }

    public override string ToString()
    {
        return _letters + "\n" + _numbers;
    }
}
