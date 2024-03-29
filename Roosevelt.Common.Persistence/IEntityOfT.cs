﻿namespace Roosevelt.Common.Persistence;

public interface IEntity<TKey> : IEntity
{
    public new TKey Id { get; set; }
}