using System;

namespace NpgsqlTypes;

/// <summary>
/// Provides a mechanism to register and retrieve a singleton instance of an <see cref="IDatumConversion"/> implementation.
/// </summary>
public static class DatumConversionProvider
{
    private static IDatumConversion? _instance;

    /// <summary>
    /// Registers an implementation of <see cref="IDatumConversion"/> to be used as the singleton instance.
    /// </summary>
    /// <param name="conversion">The <see cref="IDatumConversion"/> implementation to register.</param>
    public static void Register(IDatumConversion conversion)
    {
        _instance = conversion;
    }

    /// <summary>
    /// Retrieves the registered <see cref="IDatumConversion"/> singleton instance.
    /// </summary>
    /// <returns>The registered <see cref="IDatumConversion"/> instance.</returns>
    /// <exception cref="InvalidOperationException">Thrown if no <see cref="IDatumConversion"/> has been registered.</exception>
    public static IDatumConversion Get()
    {
        if (_instance is null)
            throw new InvalidOperationException("No IDatumConversion has been registered.");
        return _instance;
    }
}
