﻿namespace Ztp.Shared.Abstractions.Queries;

public interface IQuery
{
}

public interface IQuery<out TResult> : IQuery
{
}