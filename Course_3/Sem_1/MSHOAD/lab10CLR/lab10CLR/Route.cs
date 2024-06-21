using System;
using System.Data.SqlTypes;
using Microsoft.SqlServer.Server;
using System.Runtime.InteropServices;
using System.IO;

[Serializable]
[SqlUserDefinedType(Format.UserDefined, IsByteOrdered = true)]
public class Route : INullable, IBinarySerialize
{
    [SqlFacet(MaxSize = 7000)]
    private SqlString routeInfo;

    public bool IsNull { get; private set; }

    public static Route Null
    {
        get
        {
            Route route = new Route();
            route.IsNull = true;
            return route;
        }
    }

    public static Route Parse(SqlString s)
    {
        if (s.IsNull)
            return Null;

        Route route = new Route();
        route.routeInfo = s;
        return route;
    }

    public void Write(BinaryWriter writer)
    {
        writer.Write(routeInfo.IsNull ? string.Empty : routeInfo.Value);
    }

    public void Read(BinaryReader reader)
    {
        string value = reader.ReadString();
        routeInfo = new SqlString(value);
    }

    public override string ToString()
    {
        return IsNull ? "NULL" : routeInfo.IsNull ? string.Empty : routeInfo.Value;
    }

    // Add other methods and properties as needed
}