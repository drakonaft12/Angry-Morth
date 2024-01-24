using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ITransfotm // Сам интерфейс, и он имеет лишь один метод, поэтому поддерживает принцип разделения интерфейсов
{
    public Vector2 transforms { get; set; }
}
