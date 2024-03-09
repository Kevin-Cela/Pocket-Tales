using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDataHandler<T>
{
    void SaveData(T gameData);
    void LoadData(T gameData); 
}
