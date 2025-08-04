using System;
using System.Collections.Concurrent;
using Npgsql;

namespace NpgsqlTypes;

/// <summary>
/// Contains helper methods related to Npgsql.
/// </summary>
public static class NpgsqlHelper
{
    /// <summary>
    /// A mapping of <see cref="NpgsqlDbType"/> to OID in PostgreSQL.
    /// </summary>
    private static readonly ConcurrentDictionary<NpgsqlDbType, uint> _typeOids
        = new ConcurrentDictionary<NpgsqlDbType, uint>();

    /// <summary>
    /// The default <see cref="PostgresMinimalDatabaseInfo"/> used to find OIDs.
    /// </summary>
    private static readonly PostgresMinimalDatabaseInfo _databaseInfo = PostgresMinimalDatabaseInfo.DefaultTypeCatalog;

    /// <summary>
    /// Static constructor to prepare global mappings for Npgsql.
    /// </summary>
    static NpgsqlHelper()
        => NpgsqlDataSourceBuilder.ResetGlobalMappings(false);

    /// <summary>
    /// Returns the OID according to the provided (<see cref="NpgsqlDbType"/>)
    /// </summary>
    public static uint FindOid(NpgsqlDbType type)
    => _typeOids.GetOrAdd(type, t =>
    {
        var dataType = type.ToDataTypeName();
        return dataType != null ?
            _databaseInfo.GetPostgresType(dataType).OID :
            throw new InvalidOperationException(
                $"Could not find OID for {t} (typname: {dataType?.UnqualifiedName})"
            );
    });

    /// <summary>
    /// Takes an object and returns its corresponding NpgsqlDbType and value.
    /// </summary>
    public static (NpgsqlDbType, object?) GetNpgsqlTypeAndValue(object obj)
    {
        // If it's already an NpgsqlParameter, use it; otherwise wrap in a new one and let Npgsql handle it.
        var param = obj as NpgsqlParameter ?? new NpgsqlParameter("name", obj);
        return (param.NpgsqlDbType, param.Value);
    }
}
