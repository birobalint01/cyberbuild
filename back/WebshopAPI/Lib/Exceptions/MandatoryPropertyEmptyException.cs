﻿namespace WebshopAPI.Lib.Exceptions
{
    public class MandatoryPropertyEmptyException : Exception
    {
        public MandatoryPropertyEmptyException(string propertyName) : base($"A(z) {propertyName} mező megadása kötelező!")
        {
        }
    }
}
