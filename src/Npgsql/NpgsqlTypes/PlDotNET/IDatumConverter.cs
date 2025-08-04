using System;

namespace NpgsqlTypes;

/// <summary>
/// Defines methods for converting between PostgreSQL data types (represented by OIDs)
/// and .NET types, including handling nullable values and type-specific conversions.
/// </summary>
public interface IDatumConversion
{
    /// <summary>
    /// Gets the .NET type corresponding to the specified PostgreSQL object identifier (OID).
    /// </summary>
    /// <param name="oid">The PostgreSQL object identifier (OID) of the type.</param>
    /// <returns>The .NET <see cref="Type"/> that corresponds to the specified OID.</returns>
    Type GetFieldType(OID oid);

    /// <summary>
    /// Converts a PostgreSQL datum to its .NET representation.
    /// </summary>
    /// <param name="datum">A pointer to the PostgreSQL datum.</param>
    /// <param name="type">The PostgreSQL object identifier (OID) of the type.</param>
    /// <param name="arrayAllowsNullElements">Indicates whether arrays allow null elements.</param>
    /// <returns>The .NET object representation of the datum.</returns>
    object InputValue(IntPtr datum, OID type, bool arrayAllowsNullElements = false);

    /// <summary>
    /// Converts a PostgreSQL datum to its nullable .NET representation.
    /// </summary>
    /// <param name="datum">A pointer to the PostgreSQL datum.</param>
    /// <param name="type">The PostgreSQL object identifier (OID) of the type.</param>
    /// <param name="isNull">Indicates whether the datum is null.</param>
    /// <param name="arrayAllowsNullElements">Indicates whether arrays allow null elements.</param>
    /// <returns>The nullable .NET object representation of the datum, or <c>null</c> if the datum is null.</returns>
    object? InputNullableValue(IntPtr datum, OID type, bool isNull, bool arrayAllowsNullElements = false);

    /// <summary>
    /// Converts a nullable .NET object to its PostgreSQL datum representation.
    /// </summary>
    /// <param name="type">The PostgreSQL object identifier (OID) of the type.</param>
    /// <param name="value">The nullable .NET object to convert.</param>
    /// <returns>A pointer to the PostgreSQL datum representing the value.</returns>
    IntPtr OutputNullableValue(OID type, object? value);

    /// <summary>
    /// Gets the name of the type handler for the specified PostgreSQL object identifier (OID).
    /// </summary>
    /// <param name="oid">The PostgreSQL object identifier (OID) of the type.</param>
    /// <returns>The name of the type handler for the specified OID.</returns>
    string GetTypeHandlerName(uint oid);
}
