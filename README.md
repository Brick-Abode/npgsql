# Npgsql for PL/.NET

This fork of **Npgsql** is maintained as a submodule of the [**PL/.NET**](https://github.com/Brick-Abode/pldotnet) project.
It is built on top of **Npgsql version 9.0.3**.

## What is PL/.NET?

**PL/.NET** extends PostgreSQL to support functions, stored procedures, and `DO` blocks using the .NET platform — including both **C#** and **F#**.

### Where can I find the source code for PL/.NET?

The official PL/.NET repository is hosted at:
👉 [https://github.com/Brick-Abode/pldotnet](https://github.com/Brick-Abode/pldotnet)

### Where can I read the documentation?

Full documentation is available on our wiki:
📚 [https://github.com/Brick-Abode/pldotnet/wiki](https://github.com/Brick-Abode/pldotnet/wiki)

### Is there a white paper explaining the project?

Yes! You can find it here:
📄 [PL/.NET White Paper](https://github.com/Brick-Abode/pldotnet/wiki/pldotnet:-White-Paper)

## What is Npgsql?

**Npgsql** is an open-source .NET data provider for PostgreSQL. It enables applications to connect to and interact with PostgreSQL servers using the .NET ecosystem.

For official documentation, visit:
🌐 [https://www.npgsql.org](https://www.npgsql.org)

## How does PL/.NET use Npgsql?

PL/.NET leverages Npgsql as its PostgreSQL compatibility layer, offering:

* 🔄 Seamless mapping between PostgreSQL and .NET data types
* 🧪 A shared testing foundation using Npgsql's own regression test suite
* 🛠️ Low-level modifications to support server-side execution via PostgreSQL’s SPI (Server Programming Interface)

This fork is based on **Npgsql v9.0.3**, with minimal changes tailored for server-side use in PL/.NET.

We are deeply grateful to the Npgsql contributors — their work forms a foundational component of PL/.NET. 🙏
