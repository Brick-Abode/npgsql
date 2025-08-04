using System;
using System.Threading.Tasks;

namespace Npgsql;

/// <summary>
/// Represents a modified version of the NpgsqlDataSourceBuilder class that inherits from the original NpgsqlDataSourceBuilder class
/// (<see cref="NpgsqlDataSourceBuilder"/>) provided by Npgsql to work with pldotnet procedural language.
/// </summary>
public class NpgsqlDataSourceBuilder : NpgsqlDataSourceBuilderOrig
{
    /// <summary>
    /// Constructor
    /// </summary>
    public NpgsqlDataSourceBuilder(string? connectionString = null) : base() { }

    /// <summary>
    /// Builds and returns an <see cref="NpgsqlDataSource" />
    /// </summary>
    public new NpgsqlDataSource Build()
        => new NpgsqlDataSource();

    /// <summary>
    /// Builds and returns a <see cref="NpgsqlMultiHostDataSource" />
    /// </summary>
    public new NpgsqlMultiHostDataSource BuildMultiHost()
        => (NpgsqlMultiHostDataSource)new NpgsqlDataSource();

}
