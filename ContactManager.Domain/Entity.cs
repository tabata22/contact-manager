﻿namespace ContactManager.Domain;

public abstract class Entity
{
    public Guid Id { get; protected set; }
}