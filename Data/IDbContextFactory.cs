﻿namespace Data
{
    public interface IDbContextFactory<T>
    {
        T GetContext();
    }
}
